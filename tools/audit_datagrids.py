"""Read-only inventory of unsupported DataGrid constructors and related APIs."""
from pathlib import Path
import re
import json

ROOT = Path(__file__).resolve().parents[1]

def code_part(line):
    quoted = False
    i = 0
    while i < len(line):
        if line[i] == '"':
            if quoted and i + 1 < len(line) and line[i + 1] == '"':
                i += 2
                continue
            quoted = not quoted
        elif line[i] == "'" and not quoted:
            return line[:i]
        i += 1
    return line

rows = []
for path in sorted((ROOT / 'src').rglob('*.vb')):
    if 'bin' in path.parts or 'obj' in path.parts:
        continue
    lines = [code_part(line) for line in path.read_bytes().decode('cp1252', errors='replace').splitlines()]
    constructors = [i for i, line in enumerate(lines, 1) if re.search(r'\bNew\s+(?:System\.Windows\.Forms\.)?DataGrid\b', line)]
    legacy_apis = [i for i, line in enumerate(lines, 1) if re.search(r'\b(?:DataGrid|DataGridTableStyle|DataGridTextBoxColumn|DataGridCell)\b', line)]
    modern = sum(bool(re.search(r'\bNew\s+(?:(?:System\.Windows\.Forms\.)?DataGridView|LoadGridView|(?:Global\.)?LancioMigration\.LegacyGridView|LegacyGridView)\b', line)) for line in lines)
    if constructors or legacy_apis or modern:
        rows.append({'file': path.relative_to(ROOT).as_posix(), 'unsupported_constructor_lines': constructors,
                     'legacy_api_lines': legacy_apis, 'modern_constructors': modern})
print(json.dumps({'unsupported_constructors': sum(len(row['unsupported_constructor_lines']) for row in rows),
                  'files_with_unsupported_constructors': sum(bool(row['unsupported_constructor_lines']) for row in rows),
                  'files': rows}, indent=2))
