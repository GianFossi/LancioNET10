[CmdletBinding()]
param(
    [string]$IniPath = (Join-Path (Split-Path -Parent $PSScriptRoot) 'LancioNET.ini'),
    [switch]$NoBuild,
    [switch]$EnableTrustedLegacySerialization
)
$ErrorActionPreference = 'Stop'
$report = Join-Path $env:LOCALAPPDATA ('LancioNET10-Debug/ui-text-' + (Get-Date -Format 'yyyyMMdd-HHmmss') + '.csv')
$previous = $env:LANCIO_TEXT_LAYOUT_REPORT
try {
    $env:LANCIO_TEXT_LAYOUT_REPORT = $report
    Write-Host 'Aprire i moduli, i menu e tutte le schede; poi chiudere Lancio.'
    & (Join-Path $PSScriptRoot 'run-lancion.ps1') -IniPath $IniPath -NoBuild:$NoBuild -EnableTrustedLegacySerialization:$EnableTrustedLegacySerialization
    if (Test-Path -LiteralPath $report) {
        $issues = @(Import-Csv -LiteralPath $report)
        Write-Host "Segnalazioni da verificare: $($issues.Count). Report: $report"
    } else { throw 'Report non generato. Verificare che la build includa il controllo testo.' }
} finally { $env:LANCIO_TEXT_LAYOUT_REPORT = $previous }
