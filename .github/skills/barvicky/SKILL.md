---
name: barvicky
description: Navrhuje a aplikuje barevné palety při redesignu HTML, CSS a UI prvků. Použij vždy při požadavku na redesign rozhraní, změnu barev webu, HTML, CSS nebo UI, vizuální refresh, nové téma či úpravu vzhledu. Před jakoukoli změnou vždy nabídne výzkumem podložená schémata a vyžádá si výslovnou volbu uživatele.
version: "1.0"
---

# Redesign s povinnou volbou barev

## Povinný postup

1. Zjisti z požadavku typ produktu, cílové uživatele, účel rozhraní a zda má být výsledkem světlý nebo tmavý vzhled.
2. **Před jakoukoli změnou HTML, CSS, komponent nebo jiných UI prvků** nabídni všechna tři schémata níže. U každého stručně uveď, pro jaké použití je vhodné, jeho náladu a barvy podle rolí.
3. Podle kontextu označ jedno schéma jako doporučené, ale nevybírej ho za uživatele.
4. Vyžádej si výslovnou volbu názvu nebo čísla schématu. Je-li k dispozici nástroj pro položení jediné otázky, použij jej.
5. Neprováděj redesign, negeneruj implementační CSS ani neměň existující UI, dokud uživatel nezvolí schéma.
6. Pokud uživatel odpoví neurčitě (například „vyber ty“, „je mi to jedno“ nebo „něco jiného“), znovu zobraz volby a vysvětli, že pro pokračování musí zvolit jedno z nabízených schémat.
7. Po volbě použij barvy vybraného schématu jako základ všech upravovaných UI prvků. Zachovej konvence projektu a jeho organizaci stylů; nevnášej inline styly do projektu, který používá samostatný stylesheet.

## Nabízená schémata

### 1. Trust & Clarity — důvěra a přehlednost

**Vhodné pro:** SaaS, produktivitu, kalendáře, finance a B2B.  
**Nálada:** klid, profesionalita, spolehlivost a důvěra.  
**Doporuč pro:** rozhraní, které pracuje s organizací, důležitými údaji nebo pracovními postupy.

| Role | Barva | HEX |
| --- | --- | --- |
| Primární | Ocean Blue | `#2563EB` |
| Sekundární | Slate | `#64748B` |
| Akcentová | Sky | `#38BDF8` |
| Pozadí | White | `#F8FAFC` |
| Text | Dark Navy | `#0F172A` |
| Plocha | White | `#FFFFFF` |
| Ohraničení | Light Slate | `#E2E8F0` |

Použij přibližně 60 % pozadí, 30 % sekundárních prvků a 10 % primárních s akcentovými prvky.

### 2. Nature & Wellbeing — příroda a pohoda

**Vhodné pro:** zdraví, wellness, ekologii, vzdělávání a outdoor.  
**Nálada:** svěžest, růst, harmonie a klid.  
**Doporuč pro:** rozhraní, které má působit přirozeně, pečujícím nebo udržitelným dojmem.

| Role | Barva | HEX |
| --- | --- | --- |
| Primární | Forest Green | `#16A34A` |
| Sekundární | Sage | `#84CC16` |
| Akcentová | Amber | `#F59E0B` |
| Pozadí | Cream | `#FAFAF5` |
| Text | Earth | `#1C1917` |
| Plocha | White | `#FFFFFF` |
| Ohraničení | Stone | `#E7E5E4` |

Použij přibližně 60 % teplého pozadí, 30 % zelených prvků a 10 % jantarových akcentů.

### 3. Energy & Innovation — energie a inovace

**Vhodné pro:** startupy, kreativní agentury, technologické produkty, gaming a mladé značky.  
**Nálada:** kreativita, ambice, odvaha a modernost.  
**Doporuč pro:** rozhraní, které se má výrazně odlišit a působit energicky.

#### Tmavá varianta

| Role | Barva | HEX |
| --- | --- | --- |
| Primární | Indigo | `#6366F1` |
| Sekundární | Violet | `#8B5CF6` |
| Akcentová | Coral | `#F97316` |
| Pozadí | Near Black | `#0F0F1A` |
| Text | Off White | `#F1F0FF` |
| Plocha | Dark Surface | `#1A1A2E` |
| Ohraničení | Dark Violet | `#312E81` |

#### Světlá varianta

| Role | Barva | HEX |
| --- | --- | --- |
| Primární | Indigo | `#4F46E5` |
| Sekundární | Violet | `#7C3AED` |
| Akcentová | Burnt Orange | `#EA580C` |
| Pozadí | Soft White | `#FAFAFE` |
| Text | Deep Indigo | `#1E1B4B` |
| Plocha | White | `#FFFFFF` |
| Ohraničení | Light Indigo | `#E0E7FF` |

U schématu 3 musí uživatel zároveň zvolit tmavou nebo světlou variantu, pokud to zadání jednoznačně neurčuje. Použij přibližně 60 % pozadí, 30 % indiga a 10 % korálových nebo oranžových akcentů.

## Formát nabídky

Při aktivaci prezentuj nabídku stručně v tomto pořadí:

1. **Trust & Clarity** — modrá paleta pro důvěru a produktivitu.
2. **Nature & Wellbeing** — zelená paleta pro klid a přirozenost.
3. **Energy & Innovation** — indigo-fialová paleta s oranžovým akcentem; uveď tmavou i světlou variantu.

Pak polož jedinou otázku: **„Které schéma zvolíte: 1, 2, nebo 3 (u schématu 3 také tmavou či světlou variantu)?“**

## Kontrola po volbě

- Zachovej určené role barev: pozadí, plocha, text, primární, sekundární, akcent a ohraničení.
- Dodržuj pravidlo 60–30–10 jako vodítko, ne jako neodůvodněný pevný limit.
- Ověř kontrast textu vůči pozadí: alespoň 4,5:1 pro běžný text a 3:1 pro velký text.
- Nevyměňuj zvolené schéma za jiné bez nové výslovné volby uživatele.
