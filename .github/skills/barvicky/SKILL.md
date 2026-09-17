---
name: barvicky
description: 'Nabídne a aplikuje barevné schéma při redesignu HTML prvků a práci s barvami webu. Použij vždy při změně barev, palety, motivu, vzhledu, designu nebo redesignu HTML/CSS, webových komponent, stránek a uživatelského rozhraní. Před úpravami musí uživateli vždy nabídnout všechna tři schémata a vyžádat jeho volbu.'
argument-hint: 'Popiš redesign nebo úpravu barev'
---

# Barvičky

Použij tento workflow při každém požadavku, který zahrnuje barvy webu nebo vizuální redesign HTML prvků, CSS, komponent či celé stránky.

## Povinný postup

1. Než navrhneš nebo upravíš kód, nabídni uživateli vždy přesně tato tři schémata:
   - **1. Trust & Clarity** – světlé, klidné a profesionální; vhodné pro SaaS, produktivitu, kalendáře, finance a B2B.
   - **2. Nature & Wellbeing** – světlé, přirozené a harmonické; vhodné pro zdraví, wellness, ekologii, vzdělávání a outdoor.
   - **3. Energy & Innovation** – tmavé, výrazné a kreativní; vhodné pro startupy, technologie, kreativní produkty a gaming.
2. Požádej uživatele, aby vybral jednu možnost. Je-li dostupný nástroj pro otázky, použij jej jako výběr jedné ze tří možností.
3. Na volbu vždy počkej. Před jejím obdržením neprováděj redesign, neměň barvy a nevybírej schéma za uživatele, ani když se jedna varianta jeví jako vhodnější.
4. Po výběru aplikuj odpovídající paletu pomocí CSS proměnných. Zachovej existující designové konvence projektu a neměň nesouvisející části rozhraní.
5. Rozděl barvy přibližně podle pravidla 60-30-10: 60 % pozadí a velké plochy, 30 % sekundární prvky a 10 % primární či akcentové prvky.
6. Ověř konkrétní kombinace textu a pozadí. Dodrž minimální kontrast WCAG 4,5:1 pro běžný text a 3:1 pro velký text; samotná paleta nezaručuje přístupnost každého použití.

## Barevná schémata

### 1. Trust & Clarity

```css
:root {
    --color-primary: #2563EB;
    --color-secondary: #64748B;
    --color-accent: #38BDF8;
    --color-background: #F8FAFC;
    --color-text: #0F172A;
    --color-surface: #FFFFFF;
    --color-border: #E2E8F0;
}
```

### 2. Nature & Wellbeing

```css
:root {
    --color-primary: #16A34A;
    --color-secondary: #84CC16;
    --color-accent: #F59E0B;
    --color-background: #FAFAF5;
    --color-text: #1C1917;
    --color-surface: #FFFFFF;
    --color-border: #E7E5E4;
}
```

### 3. Energy & Innovation

```css
:root {
    --color-primary: #6366F1;
    --color-secondary: #8B5CF6;
    --color-accent: #F97316;
    --color-background: #0F0F1A;
    --color-text: #F1F0FF;
    --color-surface: #1A1A2E;
    --color-border: #2D2B55;
}
```

Schémata vycházejí z rešerše `docs/research/color-schemes-web.md`. Uživatelova volba určuje základ palety, ne povinnost použít každou barvu bez ohledu na kontext.