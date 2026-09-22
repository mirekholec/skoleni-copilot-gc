# CAL-016: Náhled měsíce v postranním panelu

**Summary:** Kontextový mini kalendář aktuálního měsíce pod seznamem kategorií
**Priorita:** Medium
**Story points:** 3
**Labels:** feature, ux, sidebar

## Popis

Pod seznam kategorií v levém postranním panelu přidat kompaktní náhled měsíce. Náhled má uživateli ukázat, kde se vybraný týden nachází v rámci měsíce, a současně vizuálně označit dnešní datum.

Nejde o samostatný plnohodnotný měsíční pohled ani o další navigaci. Náhled je pouze kontextová pomůcka pro aktuálně zobrazený týden.

## Požadavky

- V `src/index.html` přidat pod `#categoryList` samostatnou sekci náhledu měsíce s nadpisem a kontejnerem pro mřížku.
- Zobrazit název měsíce a rok v češtině podle vybraného týdne.
- Mřížka musí mít sedm sloupců v pořadí pondělí až neděle a musí obsahovat všechny dny daného měsíce.
- Pro zachování úplných týdnů zobrazit také dny z předchozího a následujícího měsíce; tyto dny musí být vizuálně potlačené.
- Za měsíc vybraného týdne považovat měsíc pondělního dne uloženého v `state.currentWeekStart`. Toto pravidlo musí být stejné i pro týdny, které zasahují do dvou měsíců.
- Všech sedm dnů aktuálně vybraného týdne označit společným stavem zvýraznění, včetně dnů z okolních měsíců, pokud jsou v mřížce viditelné.
- Dnešní datum označit samostatným výrazným stavem. Pokud je dnešek součástí vybraného týdne, musí být patrné oba stavy současně.
- Po navigaci na předchozí nebo následující týden a po návratu na dnešní týden náhled okamžitě překreslit.
- Náhled musí respektovat stávající responzivní chování sidebaru a při skrytí sidebaru na malých obrazovkách se nesmí zobrazovat jinde.
- Náhled je pouze pro čtení: nepřidávat vlastní navigaci měsíců, změnu dat ani nový formát ukládání do `localStorage`.
- Zachovat možnost otevřít aplikaci přímo přes `src/index.html` bez serveru.

## Technické poznámky

- V `src/app.js` znovu použít `state.currentWeekStart`, `getDateString()` a stávající pondělní pořadí dnů; nevytvářet paralelní stav pro měsíc.
- Vykreslování náhledu zapojit do stejné renderovací cesty jako týdenní kalendář, aby se aktualizovalo při každém volání `renderCalendar()`.
- Pro buňky použít sémantické třídy například pro běžný den, den mimo aktuální měsíc, vybraný týden a dnešek. Kombinaci stavů řešit pomocí CSS tříd, ne inline styly.
- V `src/styles.css` definovat kompaktní rozměry vhodné pro šířku sidebaru, mřížku přes CSS Grid a dostatečný kontrast stavů. Dnešek musí zůstat rozpoznatelný i tehdy, když je zároveň zvýrazněn vybraný týden.
- Buňkám doplnit dostupný popisek celého data; buňka dnešního dne má nést `aria-current="date"`. Protože náhled není interaktivní, datum nemá být prezentováno jako tlačítko.
- Přípravu dat a případné pomocné funkce navrhnout tak, aby je bylo možné později sdílet s plnohodnotným měsíčním pohledem z CAL-001.

## Implementační plán

1. Doplnit do `src/index.html` sémantickou sekci náhledu měsíce umístěnou bezprostředně pod seznamem kategorií a připravit potřebné DOM reference.
2. V `src/app.js` spočítat rozsah mřížky pro měsíc odvozený z `state.currentWeekStart`, generovat dny po týdnech od pondělí do neděle a označit dny podle příslušných stavů.
3. Napojit vykreslení náhledu na `renderCalendar()` a ověřit, že se náhled aktualizuje při všech existujících akcích měnících vybraný týden.
4. V `src/styles.css` nastavit vzhled sekce, sedmisloupcovou mřížku, potlačení okolních měsíců a současné zvýraznění vybraného týdne a dneška bez inline CSS.
5. Ručně ověřit běžný měsíc, měsíc začínající v neděli, přestupný únor, týdny přes hranici měsíců a navigaci na dnešní týden při otevření `src/index.html`.

## Akceptační kritéria

- [ ] Náhled měsíce je na desktopu viditelný bezprostředně pod seznamem kategorií.
- [ ] Náhled zobrazuje správný měsíc a rok podle pondělí vybraného týdne.
- [ ] Mřížka má sedm sloupců Po–Ne, správný počet týdnů a obsahuje všechny dny měsíce.
- [ ] Dny předchozího a následujícího měsíce jsou zobrazené pouze jako doplnění týdnů a jsou vizuálně odlišené.
- [ ] Všech sedm dnů vybraného týdne je zvýrazněno i při přechodu týdne přes hranici měsíce.
- [ ] Dnešní datum je v náhledu výrazně zvýrazněné a při souběhu s vybraným týdnem jsou rozlišitelné oba stavy.
- [ ] Náhled se po kliknutí na „Dnes“ a po navigaci mezi týdny okamžitě synchronizuje s hlavním kalendářem.
- [ ] Náhled se na malých obrazovkách skryje společně se sidebarom a neovlivní rozložení hlavního kalendáře.
- [ ] Implementace nemění datový model událostí ani nastavení ukládaná v `localStorage`.
- [ ] Buňky mají dostupné popisky celého data a dnešní den používá `aria-current="date"`.
