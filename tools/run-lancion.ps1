[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string]$IniPath,
    [switch]$NoBuild,
    [switch]$EnableTrustedLegacySerialization
)
$ErrorActionPreference = 'Stop'
if ($env:OS -ne 'Windows_NT') { throw 'Lancion richiede Windows.' }
$repository = Split-Path -Parent $PSScriptRoot
$resolvedIni = (Resolve-Path -LiteralPath $IniPath).Path
if (-not (Test-Path -LiteralPath $resolvedIni -PathType Leaf)) { throw 'Indicare un file INI della propria installazione.' }
Push-Location $repository
$previousIni = $env:LANCIO_INI
$previousSerialization = $env:LANCIO_ENABLE_LEGACY_BINARY_FORMATTER
try {
    if (-not $NoBuild) {
        & dotnet build LancioNET10.App.slnx -c Debug
        if ($LASTEXITCODE -ne 0) { throw 'Compilazione Lancion fallita.' }
    }
    $executable = Join-Path $repository 'src/Lancion/bin/Debug/net10.0-windows/win-x86/Lancio.exe'
    if (-not (Test-Path -LiteralPath $executable)) { throw 'Lancio.exe manca: compilare prima in Debug.' }
    foreach ($library in @('AsmeLib.dll', 'MathAV.dll', 'Dforrt.dll')) {
        if (-not (Test-Path -LiteralPath (Join-Path (Split-Path $executable) $library))) { throw "Dipendenza nativa mancante: $library" }
    }
    $env:LANCIO_INI = $resolvedIni
    if ($EnableTrustedLegacySerialization) { $env:LANCIO_ENABLE_LEGACY_BINARY_FORMATTER = '1' }
    # The child inherits the selected INI. Original license checks remain active.
    & $executable
    if ($LASTEXITCODE -ne 0) { throw "Lancion terminato con codice $LASTEXITCODE. Verificare .NET 10 Desktop Runtime x86 e il messaggio dell'applicazione." }
} finally {
    $env:LANCIO_INI = $previousIni
    $env:LANCIO_ENABLE_LEGACY_BINARY_FORMATTER = $previousSerialization
    Pop-Location
}
