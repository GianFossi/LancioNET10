#!/usr/bin/env python3
"""Genera la tavola geometrica dei simboli principali di Traccia."""

import os
from pathlib import Path

os.environ.setdefault("MPLCONFIGDIR", "/tmp/lancionet-matplotlib")

import matplotlib.pyplot as plt
from matplotlib.patches import Arc, Circle, FancyArrowPatch, Wedge


ROOT = Path(__file__).resolve().parents[1]
OUTPUT = ROOT / "docs/diagrams/traccia-simboli-geometria.png"
BLUE = "#174a7e"
LIGHT_BLUE = "#d9ecff"
LIGHT_GREEN = "#e6f7ee"


def arrow(ax, start, end, label, offset=(0, 0)):
    ax.add_patch(FancyArrowPatch(start, end, arrowstyle="<->", mutation_scale=12, color=BLUE, lw=1.5))
    mx = (start[0] + end[0]) / 2 + offset[0]
    my = (start[1] + end[1]) / 2 + offset[1]
    ax.text(mx, my, label, color=BLUE, fontsize=17, ha="center", va="center",
            bbox=dict(facecolor="white", edgecolor="none", pad=1))


fig, axes = plt.subplots(1, 3, figsize=(15, 6), dpi=180)
fig.patch.set_facecolor("white")

# Piastra e reticolo
ax = axes[0]
ax.set_title("Piastra e reticolo — vista in pianta", fontsize=20, weight="bold")
ax.add_patch(Circle((0, 0), 4.4, fill=False, lw=2, ls="--", color="#667788"))
ax.add_patch(Circle((0, 0), 3.5, fill=False, lw=2, color=BLUE))
ax.text(0, 4.65, "di0 — diametro mantello", ha="center", fontsize=15)
ax.text(0, 3.25, "OTL — limite esterno tubi", ha="center", fontsize=15, color=BLUE)
p, q = (2.1, 1.55), (0.55, 2.25)
for point, name in ((p, "P=(x,y)"), (q, "Q")):
    ax.add_patch(Circle(point, 0.34, facecolor="white", edgecolor=BLUE, lw=2))
    ax.text(point[0], point[1] - 0.62, name, ha="center", fontsize=15)
arrow(ax, (0, 0), p, "r = DistCentro", (0.0, -0.25))
arrow(ax, p, q, "Passo", (0.0, 0.28))
ax.add_patch(Arc((0, 0), 2.0, 2.0, theta1=0, theta2=36, color="#b55a30", lw=2))
ax.text(1.0, 0.28, "θ = Anomal", color="#b55a30", fontsize=15)
ax.annotate("dtubo", xy=(p[0] + 0.34, p[1]), xytext=(3.25, 0.9), fontsize=15,
            arrowprops=dict(arrowstyle="->", color="#b55a30"), color="#b55a30")
ax.scatter([0], [0], color="black", s=22)
ax.set_xlim(-5, 5); ax.set_ylim(-5, 5); ax.set_aspect("equal"); ax.axis("off")

# Forcina U
ax = axes[1]
ax.set_title("Tubo a U — vista laterale", fontsize=20, weight="bold")
ax.plot([-2.2, -2.2], [-3.2, 1.9], color=BLUE, lw=8, solid_capstyle="round")
ax.plot([2.2, 2.2], [-3.2, 1.9], color=BLUE, lw=8, solid_capstyle="round")
ax.add_patch(Arc((0, 1.9), 4.4, 4.4, theta1=0, theta2=180, color=BLUE, lw=8))
arrow(ax, (0, 1.9), (2.2, 1.9), "radiu", (0, 0.3))
arrow(ax, (-3.0, -3.2), (-3.0, 1.9), "Tublu", (-0.35, 0))
ax.annotate("dtubo", xy=(2.2, -0.6), xytext=(3.3, -0.6), fontsize=16,
            arrowprops=dict(arrowstyle="->", color="#b55a30"), color="#b55a30")
ax.text(0, -4.1, "Spmm = spessore della parete", ha="center", fontsize=15)
ax.set_xlim(-5, 5); ax.set_ylim(-5, 5); ax.set_aspect("equal"); ax.axis("off")

# Fontana
ax = axes[2]
ax.set_title("Fontana — accoppiamento in pianta", fontsize=20, weight="bold")
ax.add_patch(Wedge((0, 0), 4.35, 50, 105, width=1.1, facecolor="#fff1c7", edgecolor="#c59a21", ls="--"))
ax.add_patch(Circle((0, 0), 2.0, fill=False, color=BLUE, lw=2))
ax.add_patch(Circle((0, 0), 3.75, fill=False, color="#3a8060", lw=2))
i, e = (1.15, 1.45), (3.35, 0.55)
ax.add_patch(Circle(i, 0.32, facecolor=LIGHT_BLUE, edgecolor=BLUE, lw=2))
ax.add_patch(Circle(e, 0.32, facecolor=LIGHT_GREEN, edgecolor="#3a8060", lw=2))
ax.text(i[0] - 0.4, i[1] + 0.55, "Iᵢ — interno", fontsize=15, ha="center")
ax.text(e[0], e[1] - 0.7, "Eⱼ — esterno", fontsize=15, ha="center")
arrow(ax, i, e, "dᵢⱼ", (0, 0.32))
arrow(ax, (0, 0), i, "rᵢ", (-0.25, 0.15))
ax.add_patch(Arc((0, 0), 1.4, 1.4, theta1=0, theta2=52, color="#b55a30", lw=2))
ax.text(0.7, 0.28, "θᵢ", color="#b55a30", fontsize=15)
ax.text(-2.6, 3.7, "Varco", fontsize=16, weight="bold", color="#8b6800")
ax.text(0, -4.5, "φᵢⱼ = direzione Iᵢ→Eⱼ   •   Δθᵢⱼ = deviazione radiale\nJᵢⱼ = costo di prova della coppia", ha="center", fontsize=14)
ax.scatter([0], [0], color="black", s=22)
ax.set_xlim(-5, 5); ax.set_ylim(-5, 5); ax.set_aspect("equal"); ax.axis("off")

plt.tight_layout(w_pad=2.0)
fig.savefig(OUTPUT, bbox_inches="tight", facecolor="white")
