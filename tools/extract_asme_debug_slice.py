"""Generate a headless debug slice from original VB methods, with original PDB paths.
No changes to formula bodies; generated sources belong under obj only.
"""
import argparse
import hashlib
from pathlib import Path
import re

root = Path(__file__).resolve().parents[1]
source = root / 'legacy/AsmeVip.NET/Calcoli.vb'
parser = argparse.ArgumentParser()
parser.add_argument('--output', required=True)
args = parser.parse_args()
lines = source.read_bytes().decode('cp1252').splitlines()
blocks = []
for name in ('CylPres', 'Euro', 'ASME1', 'CylThk'):
    starts = [i for i, line in enumerate(lines) if re.match(r'\s*(?:Private\s+)?Sub\s+' + name + r'\(', line, re.I)]
    if len(starts) != 1:
        raise ValueError('Missing or ambiguous method: ' + name)
    start = starts[0]
    end = next(i for i in range(start + 1, len(lines)) if re.match(r'\s*End Sub\s*$', lines[i], re.I))
    # #ExternalSource gives breakpoints and stepping the exact original file/lines.
    path = str(source.resolve()).replace('"', '""')
    blocks.append(f'#ExternalSource("{path}", {start + 1})\n' + '\n'.join(lines[start:end + 1]) + '\n#End ExternalSource')

header = '''Option Strict Off
Option Explicit On
Imports System.Collections.Generic

' Minimal observed environment for the four original routines, NOT the whole application.
Module LegacyAsmeSlice
    Public Structure ConfigurationEntry
        Public DC As Short
    End Structure
    Public Config(0) As ConfigurationEntry
    Public kLato As Short
    Public iMAWP As Short
    Public USStr(1) As String
    Private SWR, Rm, Ri As Single
    Public ReadOnly ErrorCodes As New List(Of Short)
    Public ReadOnly Messages As New List(Of String)
    Public Sub Configure(radiusConvention As Single, Optional code As Short = 0, Optional mawpMode As Short = 0)
        Config(0).DC = code
        kLato = 0
        iMAWP = mawpMode
        SWR = radiusConvention
        Rm = 0 : Ri = 0
        USStr = New String(1) {}
        ErrorCodes.Clear()
        Messages.Clear()
    End Sub
    Private Sub Erro(code As Short)
        ' UI adapter: keep the original error code observable without opening a form.
        ErrorCodes.Add(code)
    End Sub
'''
footer = '''
End Module

Friend NotInheritable Class MessageBox
    Public Shared Sub Show(message As String)
        LegacyAsmeSlice.Messages.Add(message)
    End Sub
End Class
'''
output = Path(args.output)
output.parent.mkdir(parents=True, exist_ok=True)
checksum = hashlib.sha256(source.read_bytes()).hexdigest().upper()
checksum_directive = '#ExternalChecksum("' + str(source.resolve()).replace('"', '""') + '", "{8829d00f-11b8-4213-878b-770e8597ac16}", "' + checksum + '")\n'
output.write_text(header + checksum_directive + '\n\n'.join(blocks) + footer, encoding='utf-8')
print('Generated four unchanged ASME routines for headless debugging.')
