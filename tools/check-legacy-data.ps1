[CmdletBinding()]
param(
    [string]$IniPath,
    [string[]]$Modules,
    [string]$ReportPath = (Join-Path $env:LOCALAPPDATA 'LancioNET10-Debug\data-check.csv')
)
$ErrorActionPreference = 'Stop'
$repo = Split-Path $PSScriptRoot -Parent
if (-not $IniPath) {
    if ($env:LANCIO_INI) { $IniPath = $env:LANCIO_INI }
    else { $IniPath = Join-Path $repo 'LancioNET.ini' }
}
if (-not (Test-Path -LiteralPath $IniPath -PathType Leaf)) { throw "INI missing: $IniPath. Pass -IniPath with the actual configuration file." }
$paths = @{}
$section = ''
foreach ($line in Get-Content -LiteralPath $IniPath) {
    $text = $line.Trim()
    if ($text -match '^\[(.+)\]$') { $section = $Matches[1]; continue }
    if ($section -eq 'Percorsi' -and $text -match '^([^=]+)=(.*)$') { $paths[$Matches[1].Trim()] = $Matches[2].Trim() }
}
foreach ($key in @('ArchDir', 'DatiDir')) {
    if (-not $paths.ContainsKey($key) -or [string]::IsNullOrWhiteSpace($paths[$key])) { throw "INI missing [Percorsi] $key: $IniPath" }
    if (-not [System.IO.Path]::IsPathRooted($paths[$key])) { throw "INI $key must be absolute: $($paths[$key])" }
}
$rows = [System.Collections.Generic.List[object]]::new()
$sourceModules = @(Get-ChildItem -LiteralPath (Join-Path $repo 'src') -Directory)
if ($Modules) {
    foreach ($module in $Modules) {
        if ($module -notin $sourceModules.Name) { throw "Unknown module: $module" }
    }
    $sourceModules = @($sourceModules | Where-Object { $_.Name -in $Modules })
}
foreach ($module in $sourceModules) {
    foreach ($area in @('Arch', 'Dati')) {
        $sourceRoot = Join-Path $module.FullName $area
        if (-not (Test-Path -LiteralPath $sourceRoot -PathType Container)) { continue }
        $destinationRoot = if ($area -eq 'Arch') { $paths['ArchDir'] } else { $paths['DatiDir'] }
        foreach ($file in Get-ChildItem -LiteralPath $sourceRoot -Recurse -File) {
            if ($file.Extension -notin @('.mdb', '.dat')) { continue }
            $relative = $file.FullName.Substring($sourceRoot.Length).TrimStart([char[]]'\/')
            $target = Join-Path $destinationRoot $relative
            $status = if (Test-Path -LiteralPath $target -PathType Leaf) {
                if ((Get-Item -LiteralPath $target).Length -eq 0) { 'EMPTY' } else { 'PRESENT' }
            } else { 'MISSING' }
            $rows.Add([pscustomobject]@{ Module=$module.Name; Area=$area; File=$relative; Status=$status; Target=$target; Source=$file.FullName })
        }
    }
}
if ($rows.Count -eq 0) { throw 'No supplied MDB/DAT files found for the selected modules.' }
Write-Host "INI: $IniPath"
Write-Host "ARCH: $($paths['ArchDir'])"
Write-Host "DATI: $($paths['DatiDir'])"
$summary = foreach ($group in $rows | Group-Object Module) {
    [pscustomobject]@{
        Module = $group.Name
        Present = @($group.Group | Where-Object Status -eq 'PRESENT').Count
        Missing = @($group.Group | Where-Object Status -eq 'MISSING').Count
        Empty = @($group.Group | Where-Object Status -eq 'EMPTY').Count
    }
}
$summary | Format-Table -AutoSize | Out-Host
$issues = @($rows | Where-Object Status -ne 'PRESENT')
if ($issues.Count) {
    Write-Host 'Missing or empty files:'
    $issues | Select-Object Module, Status, Target | Format-Table -AutoSize -Wrap | Out-Host
}
# Report only: never copy, edit or overwrite databases. Presence does not prove schema or provider compatibility.
$reportFullPath = [System.IO.Path]::GetFullPath($ReportPath)
if ([System.IO.Path]::GetExtension($reportFullPath) -ne '.csv') { throw 'ReportPath must end with .csv.' }
if (Test-Path -LiteralPath $reportFullPath) { throw "Report already exists; choose another -ReportPath: $reportFullPath" }
[System.IO.Directory]::CreateDirectory((Split-Path $reportFullPath -Parent)) | Out-Null
$rows | Export-Csv -LiteralPath $reportFullPath -NoTypeInformation -Encoding UTF8
Write-Host "Report: $reportFullPath"
Write-Host 'Checks supplied src/Arch and src/Dati MDB/DAT files only. Optional modules may be missing; PRESENT does not validate contents, formulas or database providers.'
if ($issues.Count) { exit 2 }
exit 0
