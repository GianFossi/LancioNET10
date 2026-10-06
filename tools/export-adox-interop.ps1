param(
    [ValidateSet('x86', 'x64')]
    [string]$Architecture = 'x86',
    [string]$TlbImpPath,
    [string]$TypeLibraryPath
)

$ErrorActionPreference = 'Stop'
if ($env:OS -ne 'Windows_NT') {
    throw 'Run this script on Windows with the .NET Framework SDK tools installed.'
}
if (-not $TlbImpPath) {
    $tool = Get-Command tlbimp.exe -ErrorAction SilentlyContinue
    if (-not $tool) {
        throw 'tlbimp.exe is missing. Open a Visual Studio Developer PowerShell with .NET Framework SDK tools, or supply -TlbImpPath.'
    }
    $TlbImpPath = $tool.Source
}
if (-not $TypeLibraryPath) {
    $programFiles = if ($Architecture -eq 'x86' -and ${env:ProgramFiles(x86)}) {
        ${env:ProgramFiles(x86)}
    } else {
        $env:ProgramFiles
    }
    $TypeLibraryPath = Join-Path $programFiles 'Common Files\System\ado\msadox.dll'
}
if (-not (Test-Path -LiteralPath $TypeLibraryPath -PathType Leaf)) {
    throw "ADOX type library not found: $TypeLibraryPath. Supply the path from the Windows installation; do not download an arbitrary DLL."
}
if (-not (Test-Path -LiteralPath $TlbImpPath -PathType Leaf)) {
    throw "tlbimp.exe not found: $TlbImpPath"
}

# Keep binaries and any imported dependent type libraries outside tracked source.
$repoRoot = Split-Path $PSScriptRoot -Parent
$outputDirectory = Join-Path $repoRoot 'local\interop'
New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null
$outputFile = Join-Path $outputDirectory 'Interop.ADOX.dll'
if (Test-Path -LiteralPath $outputFile) {
    throw 'Interop.ADOX.dll already exists. Preserve and inspect it before replacing it.'
}
Push-Location $outputDirectory
try {
    & $TlbImpPath $TypeLibraryPath '/out:Interop.ADOX.dll' '/namespace:ADOX' "/machine:$Architecture"
    if ($LASTEXITCODE -ne 0) {
        throw "tlbimp failed with exit code $LASTEXITCODE. Do not use any partial output."
    }
    if (-not (Test-Path -LiteralPath $outputFile -PathType Leaf)) {
        throw 'tlbimp did not produce Interop.ADOX.dll.'
    }
    [ordered]@{
        source = $TypeLibraryPath
        sourceVersion = (Get-Item -LiteralPath $TypeLibraryPath).VersionInfo.FileVersion
        sourceSHA256 = (Get-FileHash -LiteralPath $TypeLibraryPath -Algorithm SHA256).Hash
        toolSHA256 = (Get-FileHash -LiteralPath $TlbImpPath -Algorithm SHA256).Hash
        architecture = $Architecture
        outputSHA256 = (Get-FileHash -LiteralPath $outputFile -Algorithm SHA256).Hash
    } | ConvertTo-Json | Set-Content -LiteralPath 'adox-provenance.json' -Encoding UTF8
    Write-Host "Generated $outputFile. ADOX execution still requires Windows COM and the required database provider."
} finally {
    Pop-Location
}
