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
case_index = {}
for path in files:
    case_index.setdefault(path.relative_to(ROOT).as_posix().casefold(), []).append(
        path.relative_to(ROOT).as_posix())
with (OUT / 'files.csv').open('w', encoding='utf-8', newline='') as stream:
    writer = csv.writer(stream, lineterminator='\n')
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
    for element in tree.iter():
        element.tag = element.tag.split('}')[-1]
    settings_node = tree.find('.//Settings')
    settings = settings_node.attrib if settings_node is not None else {
        child.tag: (child.text or '').strip()
        for group in tree.findall('PropertyGroup') if not group.get('Condition')
        for child in group
    }
    references = []
    for element in tree.iter():
        if element.tag in ('Reference', 'ProjectReference', 'COMReference'):
            entry = dict(element.attrib)
            entry.update({child.tag: (child.text or '').strip() for child in element})
            entry['kind'] = element.tag
            references.append(entry)
    missing = []
    case_differences = []
    def inspect_file(relative, action):
        candidate = path.parent / relative.replace('\\', '/')
        if candidate.exists():
            return
        matches = case_index.get(candidate.relative_to(ROOT).as_posix().casefold(), [])
        if len(matches) == 1:
            case_differences.append({'path': relative, 'actual_path': matches[0],
                                     'build_action': action})
        else:
            missing.append({'path': relative, 'build_action': action})
    for item in tree.findall('.//File'):
        rel = item.get('RelPath')
        if rel:
            inspect_file(rel, item.get('BuildAction'))
    for item in tree.iter():
        if item.tag in ('Compile', 'EmbeddedResource', 'Content', 'None'):
            rel = item.get('Include')
            if rel:
                inspect_file(rel, item.tag)
    manifests.append({'path': path.relative_to(ROOT).as_posix(),
                      'encoding': encoding, 'xml_error': error,
                      'settings': settings,
                      'references': references,
                      'case_differences': case_differences,
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
