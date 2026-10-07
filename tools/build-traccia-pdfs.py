#!/usr/bin/env python3
"""Genera i tre manuali A4 di Traccia dal documento tecnico principale."""

from __future__ import annotations

import re
import shutil
import subprocess
import tempfile
from pathlib import Path

from docx import Document
from docx.enum.section import WD_SECTION
from docx.enum.text import WD_ALIGN_PARAGRAPH
from docx.oxml import OxmlElement
from docx.oxml.ns import qn
from docx.shared import Mm, Pt


ROOT = Path(__file__).resolve().parents[1]
DOCS = ROOT / "docs"
MASTER = DOCS / "tracciatura-algoritmi.md"
SYMBOLS = DOCS / "tracciatura-simboli.md"
MASKS = DOCS / "tracciatura-maschere.md"
CONTROLS = DOCS / "tracciatura-controlli-processo.md"
AUTHOR = "dott. ing. Gian-Luca ANFOSSI"


def run(*args: str) -> None:
    subprocess.run(args, cwd=ROOT, check=True)


def split_h1(markdown: str) -> tuple[str, dict[str, str]]:
    markdown = re.sub(r"\A---\n.*?\n---\n", "", markdown, flags=re.S)
    matches = list(re.finditer(r"(?m)^# (.+)$", markdown))
    preamble = markdown[: matches[0].start()] if matches else markdown
    sections: dict[str, str] = {}
    for pos, match in enumerate(matches):
        end = matches[pos + 1].start() if pos + 1 < len(matches) else len(markdown)
        sections[match.group(1)] = markdown[match.start() : end].strip() + "\n"
    return preamble, sections


def only_h2(section: str, wanted: tuple[str, ...]) -> str:
    title = re.match(r"(?m)^# .+$", section).group(0)
    matches = list(re.finditer(r"(?m)^## (.+)$", section))
    chunks = [title, ""]
    for pos, match in enumerate(matches):
        end = matches[pos + 1].start() if pos + 1 < len(matches) else len(section)
        if any(match.group(1).startswith(prefix) for prefix in wanted):
            chunks.append(section[match.start() : end].strip())
            chunks.append("")
    return "\n".join(chunks)


def add_field(paragraph, instruction: str) -> None:
    run_element = OxmlElement("w:r")
    begin = OxmlElement("w:fldChar")
    begin.set(qn("w:fldCharType"), "begin")
    code = OxmlElement("w:instrText")
    code.set(qn("xml:space"), "preserve")
    code.text = instruction
    separate = OxmlElement("w:fldChar")
    separate.set(qn("w:fldCharType"), "separate")
    value = OxmlElement("w:t")
    value.text = "1"
    end = OxmlElement("w:fldChar")
    end.set(qn("w:fldCharType"), "end")
    for element in (begin, code, separate, value, end):
        run_element.append(element)
    paragraph._p.append(run_element)


def format_docx(path: Path) -> None:
    document = Document(path)
    for section in document.sections:
        section.page_width = Mm(210)
        section.page_height = Mm(297)
        section.top_margin = Mm(22)
        section.bottom_margin = Mm(20)
        section.left_margin = Mm(18)
        section.right_margin = Mm(18)
        section.header_distance = Mm(8)
        section.footer_distance = Mm(9)

        header = section.header
        hp = header.paragraphs[0]
        hp.alignment = WD_ALIGN_PARAGRAPH.CENTER
        hr = hp.add_run(AUTHOR)
        hr.font.size = Pt(9)

        footer = section.footer
        fp = footer.paragraphs[0]
        fp.alignment = WD_ALIGN_PARAGRAPH.CENTER
        fr = fp.add_run("Pagina ")
        fr.font.size = Pt(9)
        add_field(fp, "PAGE")
        fp.add_run(" di ").font.size = Pt(9)
        add_field(fp, "NUMPAGES")

    normal = document.styles["Normal"]
    normal.font.name = "Liberation Sans"
    normal.font.size = Pt(9.5)
    normal.paragraph_format.space_after = Pt(5)
    heading_one = None
    for style in document.styles:
        if style.style_id in ("Heading1", "Heading2", "Heading3"):
            style.font.name = "Liberation Sans"
            style.paragraph_format.keep_with_next = True
            if style.style_id == "Heading1":
                heading_one = style
    if heading_one is not None:
        heading_one.paragraph_format.page_break_before = True

    max_width = Mm(166)
    max_height = Mm(205)
    for shape in document.inline_shapes:
        ratio = min(max_width / shape.width, max_height / shape.height, 1.0)
        shape.width = int(shape.width * ratio)
        shape.height = int(shape.height * ratio)

    for table in document.tables:
        table.autofit = True
        for row in table.rows:
            for cell in row.cells:
                for paragraph in cell.paragraphs:
                    for text_run in paragraph.runs:
                        text_run.font.size = Pt(8)

    settings = document.settings._element
    update = OxmlElement("w:updateFields")
    update.set(qn("w:val"), "true")
    settings.append(update)
    document.save(path)


def create_pdf(slug: str, title: str, parts: list[str], opening: str, temp: Path) -> None:
    source = temp / f"{slug}.md"
    docx = temp / f"{slug}.docx"
    front = (
        "---\n"
        f'title: "{title}"\n'
        'subtitle: "Modulo Traccia — logica e algoritmi del software legacy"\n'
        f'author: "{AUTHOR}"\n'
        'date: "7 ottobre 2026"\n'
        "lang: it-IT\n"
        "---\n\n"
    )
    source.write_text(front + opening + "\n\n" + "\n\n".join(parts), encoding="utf-8")
    run(
        "pandoc",
        str(source),
        "--from=markdown",
        "--toc",
        "--toc-depth=3",
        f"--resource-path={DOCS}",
        "-o",
        str(docx),
    )
    format_docx(docx)
    profile = temp / f"lo-{slug}"
    profile.mkdir()
    run(
        "soffice",
        f"-env:UserInstallation=file://{profile}",
        "--headless",
        "--convert-to",
        "pdf",
        "--outdir",
        str(temp),
        str(docx),
    )
    shutil.copy2(temp / f"{slug}.pdf", DOCS / f"{slug}.pdf")


def main() -> None:
    _, sections = split_h1(MASTER.read_text(encoding="utf-8"))
    symbols = SYMBOLS.read_text(encoding="utf-8").strip()
    _, mask_sections = split_h1(MASKS.read_text(encoding="utf-8"))
    types = sections["4. Tipologie di fascio"]
    debug = sections["10. Percorso consigliato nel debugger"]

    common = [
        sections["1. Che cosa fa il modulo"],
        sections["2. Dati in ingresso, stato e risultati"],
        sections["3. Algoritmo comune di generazione del layout"],
    ]
    tail = [
        sections["8. Sequenza, raggi X e output"],
        sections["11. Mappa del codice"],
        sections["12. Rischi tecnici da preservare nella futura riscrittura"],
        sections["Appendice A — Fonti analizzate"],
    ]

    with tempfile.TemporaryDirectory(prefix="traccia-pdf-") as directory:
        temp = Path(directory)
        create_pdf(
            "Tracciatura-tubi-diritti",
            "Tracciatura dei tubi diritti",
            common
            + [only_h2(types, ("4.1 ", "4.2 "))]
            + [only_h2(debug, ("Layout ordinario",))]
            + tail,
            symbols + "\n\n" + only_h2(mask_sections["Mappa fra maschere di input e simboli"], ("Campi comuni", "Tubi diritti e dati generali", "Diaframmi e dati finali")),
            temp,
        )
        create_pdf(
            "Tracciatura-tubi-U",
            "Tracciatura dei tubi a U",
            common
            + [only_h2(types, ("4.3 ",))]
            + [only_h2(debug, ("Layout ordinario",))]
            + tail,
            symbols + "\n\n" + only_h2(mask_sections["Mappa fra maschere di input e simboli"], ("Campi comuni", "Tubi diritti e dati generali", "Tubi a U", "Diaframmi e dati finali")),
            temp,
        )
        create_pdf(
            "Tracciatura-tubi-fontana",
            "Tracciatura dei tubi a fontana",
            common
            + [only_h2(types, ("4.4 ",))]
            + [
                sections["5. Fontana: generazione e bilanciamento"],
                sections["6. Fontana: algoritmo di aggancio, in dettaglio"],
                sections["7. Fontana: algoritmo di infilaggio"],
                sections["8. Sequenza, raggi X e output"],
                sections["9. Come migliorare l'algoritmo"],
                only_h2(debug, ("Fontana",)),
                sections["11. Mappa del codice"],
                sections["12. Rischi tecnici da preservare nella futura riscrittura"],
                sections["Appendice A — Fonti analizzate"],
            ],
            symbols + "\n\n" + mask_sections["Mappa fra maschere di input e simboli"],
            temp,
        )
        create_pdf(
            "Tracciatura-controlli-processo",
            "Controlli di processo del modulo Traccia",
            [CONTROLS.read_text(encoding="utf-8")],
            symbols + "\n\n" + mask_sections["Mappa fra maschere di input e simboli"],
            temp,
        )


if __name__ == "__main__":
    main()
