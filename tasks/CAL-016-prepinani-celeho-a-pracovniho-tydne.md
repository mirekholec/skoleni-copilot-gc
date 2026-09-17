# CAL-016: Přepínání celého a pracovního týdne

**Summary:** Přidat do týdenního kalendáře přepínač mezi zobrazením pondělí–neděle a pracovních dnů pondělí–pátek
**Priorita:** Medium
**Story points:** 3
**Labels:** feature, view, ux

## Popis

Kalendář nyní vždy vykresluje všech sedm dnů týdne. Přidat možnost přepnout zobrazení na pracovní týden, ve kterém se zobrazí pouze pondělí až pátek, aniž by se měnila nebo mazala uložená data událostí.

Výchozí režim musí zůstat zobrazení celého týdne. Přepínač bude dostupný v hlavičce kalendáře a změna režimu se projeví okamžitě bez změny právě zvoleného týdne.

## Požadavky

- Po otevření aplikace se zobrazí celý týden od pondělí do neděle.
- V hlavičce přidat přístupné tlačítko pro přepnutí mezi režimy „Celý týden“ a „Pracovní týden“.
- Režim pracovního týdne zobrazí pouze pondělí, úterý, středu, čtvrtek a pátek.
- Při přepnutí se současně změní záhlaví kalendáře, časová mřížka i vykreslené události; sobotní a nedělní události se pouze skryjí, nemažou se.
- Přepnutí zachová aktuální týden, vybraný filtr kategorií, interakci s časovými sloty a práci s událostmi.
- Navigace na předchozí/další týden a tlačítko „Dnes“ zůstanou založené na pondělním začátku týdne a budou fungovat v obou režimech.
- Počet zobrazených událostí a rozsah data v hlavičce musí odpovídat právě aktivnímu režimu.
- Aktivní režim se uloží do nastavení v `localStorage`; pokud nastavení chybí nebo pochází ze starší verze, použije se výchozí režim celého týdne.
- Tisk musí respektovat aktivní režim včetně počtu sloupců a rozsahu dat.

## Technické poznámky

- Dotčené soubory:
  - [`src/index.html`](../src/index.html) – tlačítko přepínače v hlavičce.
  - [`src/app.js`](../src/app.js) – stav režimu, výběr viditelných dnů, vykreslování a listener.
  - [`src/styles.css`](../src/styles.css) – mřížka pro sedm nebo pět denních sloupců a její responzivní varianta.
- Do `DEFAULT_SETTINGS` přidat samostatné nastavení, například `weekDisplayMode: 'all'`; nepoužívat `defaultView`, protože je určeno pro budoucí přepínání týdenního a měsíčního pohledu.
- Zavést jednu pomocnou funkci nebo datovou strukturu, která podle režimu vrátí indexy/datumy viditelných dnů. Stejný zdroj použít v `renderWeekInfo`, `renderEventCount`, `renderCalendarHeader` a `renderDayColumns`, aby se počet sloupců a rozsah dat nerozešly.
- Vykreslování nesmí mít samostatné pevné smyčky pouze pro sedm dnů; celý týden bude používat indexy 0–6 a pracovní týden 0–4.
- Na element `.calendar` přidat stavovou třídu pro pracovní týden. V CSS podle ní přepnout `grid-template-columns` u `.calendar-header` i `.calendar-body` z `repeat(7, 1fr)` na `repeat(5, 1fr)`, včetně pravidel pro mobilní šířku.
- Tlačítko aktualizovat při každém překreslení nebo přepnutí pomocí textu, `title` a `aria-pressed`, aby bylo zřejmé, zda akce zobrazí celý, nebo pracovní týden.
- Tiskový rozsah generovat přes stejnou pomocnou logiku jako běžnou hlavičku; při tisku pracovního týdne se nesmí vrátit rozsah pondělí–neděle.
- Zachovat pondělní indexaci `DAY_NAMES`/`DAY_KEYS` a stávající logiku opakovaných událostí. Režim pouze omezuje viditelné dny.

## Implementační plán

1. Rozšířit výchozí nastavení a stav aplikace o režim zobrazení celého/pracovního týdne a připravit pomocnou funkci pro získání viditelných dnů s výchozí hodnotou celého týdne.
2. Přidat do [`src/index.html`](../src/index.html) tlačítko přepínače v navigaci hlavičky a v [`src/app.js`](../src/app.js) ho napojit na načtení/uložení nastavení, aktualizaci jeho přístupového stavu a překreslení kalendáře.
3. Refaktorovat výpočet rozsahu týdne, počtu událostí, záhlaví a denních sloupců tak, aby všechny části používaly stejný seznam viditelných dnů; zachovat klikání do slotů, zobrazení dnešního dne, filtrování kategorií a navigaci.
4. Doplnit stavovou CSS třídu a pravidla v [`src/styles.css`](../src/styles.css) pro mřížku se sedmi nebo pěti dny v běžném, responzivním i tiskovém zobrazení.
5. Ověřit chování po otevření [`src/index.html`](../src/index.html) bez serveru: nový/legacy stav `localStorage`, přepínání tam a zpět, navigaci mezi týdny, události o víkendu, opakované události, počítadlo událostí, tlačítko „Dnes“, responzivní šířku a tisk obou režimů.

## Akceptační kritéria

- [ ] Výchozí zobrazení obsahuje sedm sloupců od pondělí do neděle.
- [ ] Tlačítko přepínače je viditelné v hlavičce a má srozumitelný text, `title` a správně aktualizovaný `aria-pressed`.
- [ ] Po přepnutí na pracovní týden je vidět právě pět sloupců pondělí–pátek a víkendové sloupce ani jejich události nejsou zobrazené.
- [ ] Přepnutí zpět obnoví všech sedm dnů bez ztráty událostí nebo aktuálního týdne.
- [ ] Navigace předchozí/další týden, „Dnes“, filtry kategorií, vytváření událostí a detail události fungují v obou režimech.
- [ ] Rozsah data a počet událostí v hlavičce odpovídají aktivnímu režimu.
- [ ] Zvolený režim se po obnovení stránky zachová a chybějící/staré nastavení začne v režimu celého týdne.
- [ ] Tisk zobrazuje stejný počet dnů jako aktivní režim a používá odpovídající rozsah dat.
- [ ] Změna nevyžaduje server ani externí knihovnu a v konzoli prohlížeče nevznikají nové chyby.
