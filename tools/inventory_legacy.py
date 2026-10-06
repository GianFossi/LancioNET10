"""Inventory legacy files without executing or changing their contents."""
import csv
import hashlib
import json
import re
from collections import Counter
from pathlib import Path
import xml.etree.ElementTree as ET

ROOT = Path(__file__).resolve().parents[1]
LEGACY = ROOT / 'legacy'
OUT = ROOT / 'docs' / 'inventory'
OUT.mkdir(parents=True, exist_ok=True)
files = sorted(p for p in LEGACY.rglob('*') if p.is_file())
with (OUT / 'files.csv').open('w', encoding='utf-8', newline='') as stream:
    writer = csv.writer(stream)
    writer.writerow(['path', 'bytes', 'sha256'])
    for path in files:
        writer.writerow([path.relative_to(ROOT).as_posix(), path.stat().st_size,
                         hashlib.sha256(path.read_bytes()).hexdigest()])

solution = (LEGACY / 'Lancio.sln').read_text(encoding='utf-8-sig')
projects = []
for name, relative, guid in re.findall(
        r'^Project\([^\n]+? = "([^"]+)", "([^"]+)", "([^"]+)"',
        solution, flags=re.MULTILINE):
    path = LEGACY / relative.replace('\\', '/')
    projects.append({'name': name, 'path': relative, 'guid': guid,
                     'present': path.is_file()})

manifests = []
for path in sorted(LEGACY.rglob('*.vbproj')):
    raw = path.read_bytes()
    try:
        source = raw.decode('utf-8-sig')
        encoding = 'utf-8-sig'
    except UnicodeDecodeError:
        source = raw.decode('cp1252')
        encoding = 'cp1252'
    error = None
    try:
        tree = ET.fromstring(source)
    except ET.ParseError as exc:
        error = str(exc)
        # Analysis only: tolerate bare ampersands without modifying the original.
        tree = ET.fromstring(re.sub(r'&(?!#\d+;|#x[0-9a-fA-F]+;|\w+;)',
                                   '&amp;', source))
    missing = []
    for item in tree.findall('.//File'):
        rel = item.get('RelPath')
        if rel and not (path.parent / rel.replace('\\', '/')).exists():
            missing.append({'path': rel, 'build_action': item.get('BuildAction')})
    manifests.append({'path': path.relative_to(ROOT).as_posix(),
                      'encoding': encoding, 'xml_error': error,
                      'settings': tree.find('.//Settings').attrib,
                      'references': [e.attrib for e in tree.findall('.//Reference')],
                      'missing_files': missing})

patterns = {
    'VB6 compatibility': r'Microsoft\.VisualBasic\.Compatibility',
    'Control arrays': r'\b(?:TextBoxArray|PictureBoxArray|MenuItemArray|\w+Array)\b',
    'stdole': r'\bstdole\b',
    'ADO': r'\b(?:ADODB|ADOX)\b',
    'Office': r'\b(?:Word|Office|WinWordControl|VBIDE)\b',
    'AutoCAD': r'\bAutoCAD\b',
    'ActiveX': r'\b(?:AxListViewArray|AxUpDownArray|AxHost|AxSSRibbonArray)\b',
    'BinaryFormatter': r'\bBinaryFormatter\b',
}
occurrences = {}
for label, pattern in patterns.items():
    hits = []
    for path in files:
        if path.suffix.lower() not in {'.vb', '.vbproj', '.resx'}:
            continue
        # Match ASCII identifiers even in files with mixed legacy encodings.
        for number, line in enumerate(path.read_bytes().decode('latin-1').splitlines(), 1):
            if re.search(pattern, line, re.IGNORECASE):
                hits.append({'path': path.relative_to(ROOT).as_posix(), 'line': number})
    occurrences[label] = hits

report = {'file_count': len(files),
          'extensions': dict(sorted(Counter(p.suffix.lower() for p in files).items())),
          'solution_projects': projects, 'vb_projects': manifests,
          'dependency_occurrences': occurrences}
(OUT / 'projects.json').write_text(json.dumps(report, ensure_ascii=False, indent=2)
                                   + '\n', encoding='utf-8')
print(f'Inventoried {len(files)} files and {len(manifests)} VB projects.')
