"""Materialize SDK project metadata/copies; never overwrite migrated source.

Reads the inventory produced by inventory_legacy.py. Existing SDK projects
are retained. New generated SDK manifests use original explicit file lists.
"""
import json
import re
from pathlib import Path
import xml.etree.ElementTree as ET

ROOT = Path(__file__).resolve().parents[1]
records = json.loads((ROOT / 'docs/inventory/projects.json').read_text())['vb_projects']
special = {'FormulaParser': 'FormulaParser', 'LibMat': 'LibMat',
           'Orecchia': 'Orecchia', 'AsmeVip': 'AsmeVip', 'RoutBase1': 'RoutBase'}
destinations = {Path(r['path']).stem.casefold(): ROOT / 'src' /
                special.get(Path(r['path']).stem, Path(r['path']).stem) /
                Path(r['path']).name for r in records}
standard = {'system', 'system.core', 'system.data', 'system.drawing',
            'system.windows.forms', 'system.xml', 'system.configuration',
            'system.data.datasetextensions', 'microsoft.visualbasic', 'mscorlib'}
wrappers = {p.stem.casefold(): p for p in (ROOT / 'legacy/DLL Extra').glob('*.dll')}
report = []

def parse_original(path):
    raw = path.read_bytes()
    try:
        text = raw.decode('utf-8-sig')
    except UnicodeDecodeError:
        text = raw.decode('cp1252')
    text = re.sub(r'&(?!#\d+;|#x[0-9a-fA-F]+;\w+;)', '&amp;', text)
    tree = ET.fromstring(text)
    for e in tree.iter():
        e.tag = e.tag.split('}')[-1]
    return tree

def write_xml(tree, path):
    ET.indent(tree, space='  ')
    path.write_text(ET.tostring(tree, encoding='unicode') + '\n', encoding='utf-8')

for record in records:
    original = ROOT / record['path']
    name = original.stem
    destination = destinations[name.casefold()]
    destination.parent.mkdir(parents=True, exist_ok=True)
    source_tree = parse_original(original)
    existing = destination.exists()
    missing_refs = []
    project_refs = []
    for ref in record['references']:
        if ref.get('Project') or ref.get('kind') == 'ProjectReference':
            refname = ref.get('Name') or Path(ref.get('Include', '').replace('\\', '/')).stem
            if refname == 'WinWordControl':
                continue  # The Word panel replaces this unused project dependency.
            target = destinations.get(refname.casefold())
            if target:
                project_refs.append(target)
            else:
                missing_refs.append(refname)

    if existing:
        # Extend known project dependencies; preserve the hand-migrated adapters.
        if name != 'FormulaParser':
            tree = ET.parse(destination).getroot()
            # Orecchia's temporary binary dependency is now a real SDK project.
            if name == 'Orecchia':
                for parent in tree.findall('ItemGroup'):
                    for item in list(parent):
                        if item.tag == 'Reference' and item.get('Include') == 'RoutBase1':
                            parent.remove(item)
                for target in list(tree):
                    if target.tag == 'Target' and target.get('Name') == 'CheckMigrationDependencies':
                        tree.remove(target)
                for prop in tree.findall('PropertyGroup/MigrationDependencyDirectory'):
                    for parent in tree.findall('PropertyGroup'):
                        if prop in list(parent):
                            parent.remove(prop)
            group = ET.SubElement(tree, 'ItemGroup')
            known = {e.get('Include') for e in tree.findall('.//ProjectReference')}
            for target in project_refs:
                import os
                rel = os.path.relpath(target, destination.parent).replace('\\', '/')
                if rel not in known:
                    ET.SubElement(group, 'ProjectReference', Include=rel)
            if not list(group):
                tree.remove(group)
            write_xml(tree, destination)
        report.append({'original': record['path'], 'sdk_project': str(destination.relative_to(ROOT)),
                       'retained_existing_sdk': True, 'original_xml_error': record['xml_error'],
                       'unresolved_projects': missing_refs})
        continue

    tree = ET.Element('Project', Sdk='Microsoft.NET.Sdk')
    props = ET.SubElement(tree, 'PropertyGroup')
    settings = record['settings']
    values = {'TargetFramework': 'net10.0-windows', 'EnableWindowsTargeting': 'true',
              'EnableDefaultCompileItems': 'false', 'EnableDefaultEmbeddedResourceItems': 'false',
              'EnableDefaultNoneItems': 'false', 'GenerateAssemblyInfo': 'false',
              'GenerateResourceUsePreserializedResources': 'true', 'CodePage': '1252'}
    for key in ('AssemblyName', 'RootNamespace', 'OutputType', 'OptionStrict',
                'OptionExplicit', 'OptionCompare', 'StartupObject', 'MyType'):
        if settings.get(key) and '(Nessuno)' not in settings[key]:
            values[key] = settings[key]
    if any('windows.forms' in (r.get('AssemblyName') or r.get('Include') or r.get('Name', '')).lower()
           for r in record['references']):
        values['UseWindowsForms'] = 'true'
    values.setdefault('OptionStrict', 'Off')
    values.setdefault('OptionExplicit', 'On')
    for key, value in values.items():
        ET.SubElement(props, key).text = value
    # Preserve configuration-specific symbols and integer checking behavior.
    for config in ('Debug', 'Release'):
        source_config = source_tree.find(f".//Config[@Name='{config}']")
        data = source_config.attrib if source_config is not None else {}
        for pg in source_tree.findall('PropertyGroup'):
            if f'{config}|'.lower() in pg.get('Condition', '').lower():
                data = {e.tag: (e.text or '').strip() for e in pg}
        selected = {k: data[k] for k in ('DefineConstants', 'RemoveIntegerChecks', 'Optimize') if data.get(k)}
        if selected:
            pg = ET.SubElement(tree, 'PropertyGroup', Condition=f"'$(Configuration)' == '{config}'")
            for k, v in selected.items():
                ET.SubElement(pg, k).text = v
    items = ET.SubElement(tree, 'ItemGroup')
    files = []
    for e in source_tree.iter():
        if e.tag == 'File' and e.get('RelPath'):
            action = e.get('BuildAction', 'None')
            if action in ('Compile', 'EmbeddedResource', 'Content', 'None'):
                files.append((action, e.get('RelPath'), {}))
        elif e.tag in ('Compile', 'EmbeddedResource', 'Content', 'None') and e.get('Include'):
            files.append((e.tag, e.get('Include'), {c.tag: (c.text or '').strip() for c in e}))
    all_files = {p.relative_to(original.parent).as_posix().casefold(): p
                 for p in original.parent.rglob('*') if p.is_file()}
    missing_files = []
    for action, relative, metadata in files:
        relative = relative.replace('\\', '/')
        if relative.lower().endswith(('.user', '.suo', '.log')) or any(
                part.lower() in ('bin', 'obj', '.vs') for part in Path(relative).parts):
            continue  # Existing generated/IDE outputs are retained in legacy only.
        source = all_files.get(relative.casefold())
        if source:
            relative = source.relative_to(original.parent).as_posix()
            output = destination.parent / relative
            if not output.exists():
                output.parent.mkdir(parents=True, exist_ok=True)
                content = source.read_bytes()
                if source.name.lower() == 'assemblyinfo.vb':
                    content = re.sub(rb'AssemblyVersion\("([0-9]+\.[0-9]+)\.\*"\)',
                                     rb'AssemblyVersion("\1.0.0")', content)
                output.write_bytes(content)
        else:
            missing_files.append(relative)
        element = ET.SubElement(items, action, Include=relative)
        for k, v in metadata.items():
            if k in ('DependentUpon', 'LogicalName', 'SubType', 'Link') and v:
                ET.SubElement(element, k).text = v
    for e in source_tree.iter():
        namespace = e.get('Include') or e.get('Namespace')
        if e.tag == 'Import' and namespace and namespace.lower().startswith('system.'):
            ET.SubElement(items, 'Import', Include=namespace)
    for package in ('System.Resources.Extensions', 'System.Configuration.ConfigurationManager'):
        ET.SubElement(items, 'PackageReference', Include=package, Version='10.0.0')
    if any('OleDb' in p.read_text(encoding='latin-1') for p in destination.parent.rglob('*.vb')):
        ET.SubElement(items, 'PackageReference', Include='System.Data.OleDb', Version='10.0.0')
    import os
    for target in project_refs:
        ET.SubElement(items, 'ProjectReference', Include=os.path.relpath(target, destination.parent).replace('\\', '/'))
    for refname in missing_refs:
        ET.SubElement(items, 'Reference', Include=refname)
    unresolved_assemblies = []
    for ref in record['references']:
        if ref.get('Project') or ref.get('kind') == 'ProjectReference':
            continue
        refname = ref.get('AssemblyName') or ref.get('Include') or ref.get('Name')
        simple = refname.split(',')[0]
        if simple.casefold() in standard or simple == 'WinWordControl':
            continue
        candidate = wrappers.get(simple.casefold()) or wrappers.get(('interop.' + simple).casefold())
        element = ET.SubElement(items, 'Reference', Include=simple)
        if candidate:
            ET.SubElement(element, 'HintPath').text = os.path.relpath(candidate, destination.parent).replace('\\', '/')
            ET.SubElement(element, 'EmbedInteropTypes').text = 'false'
        else:
            unresolved_assemblies.append(simple)
    if name in ('AsmeVip', 'RoutBase1'):
        target = ROOT / 'src/Lancio.Office.Word.WinForms/Lancio.Office.Word.WinForms.vbproj'
        ET.SubElement(items, 'ProjectReference', Include=os.path.relpath(target, destination.parent).replace('\\', '/'))
    write_xml(tree, destination)
    report.append({'original': record['path'], 'sdk_project': str(destination.relative_to(ROOT)),
                   'retained_existing_sdk': False, 'fixed_original_xml': record['xml_error'],
                   'missing_files': missing_files, 'unresolved_projects': missing_refs,
                   'unresolved_assemblies': unresolved_assemblies})

solution = ET.Element('Solution')
for path in sorted(destinations.values()):
    ET.SubElement(solution, 'Project', Path=str(path.relative_to(ROOT)))
write_xml(solution, ROOT / 'LancioNET10.Full.slnx')
for entry in report:
    manifest = ET.parse(ROOT / entry['sdk_project']).getroot()
    entry['target_framework'] = manifest.findtext('PropertyGroup/TargetFramework')
    entry['unresolved_assemblies'] = [ref.get('Include') for ref in manifest.findall('ItemGroup/Reference') if ref.find('HintPath') is None]
(ROOT / 'docs/inventory/sdk-conversion.json').write_text(json.dumps(report, indent=2) + '\n')
print(f'SDK metadata prepared for {len(report)} VB projects; existing sources preserved.')
