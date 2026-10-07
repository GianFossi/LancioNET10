[CmdletBinding()]
param(
    [string]$ArchiveDirectory = (Join-Path $env:LOCALAPPDATA 'LancioNET10-Debug\ARCH')
)
$ErrorActionPreference = 'Stop'
$repo = Split-Path $PSScriptRoot -Parent
$destinationRoot = [System.IO.Path]::GetFullPath($ArchiveDirectory)
$plan = @{}
foreach ($module in @('LibMat', 'Grafic2', 'RoutBase', 'Traccia', 'Wrcb')) {
    $sourceRoot = Join-Path $repo "src\$module\Arch"
    if (-not (Test-Path -LiteralPath $sourceRoot -PathType Container)) { throw "Missing source archive: $sourceRoot" }
    foreach ($file in Get-ChildItem -LiteralPath $sourceRoot -File -Recurse) {
        $relative = $file.FullName.Substring($sourceRoot.Length).TrimStart([char[]]'\/')
        $hash = (Get-FileHash -LiteralPath $file.FullName -Algorithm SHA256).Hash
        if ($plan.ContainsKey($relative)) {
            if ($plan[$relative].Hash -ne $hash) { throw "Conflicting source archives: $relative" }
        } else {
            $plan[$relative] = @{ Source = $file.FullName; Hash = $hash }
        }
    }
}
foreach ($required in @('Flange.mdb', 'tabelle.mdb', 'Mat200400.mdb', 'STRI04.DAT', 'WR\WRCBDATA.DAT')) {
    if (-not $plan.ContainsKey($required)) { throw "Missing required archive: $required" }
}
# Check every existing target before copying anything. Never replace user data.
foreach ($relative in $plan.Keys) {
    $target = Join-Path $destinationRoot $relative
    if (Test-Path -LiteralPath $target) {
        if (-not (Test-Path -LiteralPath $target -PathType Leaf)) { throw "Target is not a file: $target" }
        if ((Get-FileHash -LiteralPath $target -Algorithm SHA256).Hash -ne $plan[$relative].Hash) {
            throw "Existing archive differs; nothing copied. Preserve it and choose a separate directory: $target"
        }
    }
}
$copied = 0
foreach ($relative in $plan.Keys) {
    $target = Join-Path $destinationRoot $relative
    if (-not (Test-Path -LiteralPath $target)) {
        [System.IO.Directory]::CreateDirectory((Split-Path $target -Parent)) | Out-Null
        [System.IO.File]::Copy($plan[$relative].Source, $target, $false)
        $copied++
    }
    if ((Get-FileHash -LiteralPath $target -Algorithm SHA256).Hash -ne $plan[$relative].Hash) { throw "Copy verification failed: $target" }
}
Write-Host "Verified $($plan.Count) library archive files; copied $copied."
Write-Host "Archive directory: $destinationRoot"
Write-Host 'LibMat/Grafic2/RoutBase/Traccia/Wrcb archives prepared. Other modules, Office and database runtime access require separate verification.'
