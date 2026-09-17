# CAL-002: Vyhledávání událostí

**Jira:** CAL-2
**Summary:** Vyhledávání událostí
**Typ:** Úkol
**Priorita:** Medium
**Stav:** K řešení
**Story points:** neuvedeno v Jira
**Štítky:** neuvedeny v Jira

## Cíl

Přidat do hlavičky kalendáře rychlé vyhledávání, které prohledá všechny události načtené aplikací podle názvu, popisu nebo místa a umožní uživateli otevřít odpovídající týden i detail události.

## Výchozí stav a integrační body

- `src/index.html` obsahuje hlavičku `.header` rozdělenou na `.header-left` a `.header-right`; vyhledávání patří do hlavičky jako samostatný wrapper s inputem a dropdownem výsledků.
- `src/app.js` načítá události do `state.events` z localStorage a aktuální týden filtruje až ve funkci `getEventsForDate()`. Vyhledávání proto nesmí používat pouze události vykresleného týdne ani filtrovat podle `activeCategories`.
- `showEventDetail(eventId)` už umí otevřít detail podle ID a `navigateWeek()`/`getMonday()` poskytují existující logiku pro změnu týdne.
- `DEFAULT_CATEGORIES` obsahuje názvy, ikony a barvy kategorií; kategorii ve výsledku lze vykreslit barevnou tečkou bez nové mapy barev.
- `src/styles.css` obsahuje společný vizuální systém, responzivní breakpoint pro šířku 768 px a stylování hlavičky, tlačítek a stínů, na které má dropdown navázat.
- Repo neobsahuje testovací framework. Ověření bude proto tvořit sada ručních scénářů v prohlížeči, případně malé izolované testovatelné helpery v konzoli.

## Implementační plán

### 1. Doplnit strukturu hlavičky

V `src/index.html`:

- Přidat do hlavičky wrapper například `event-search`, který bude obsahovat ikonu lupy, `input type="search"` a kontejner výsledků.
- Input opatřit stabilním ID, placeholderem a přístupným názvem (`aria-label` nebo vizuálně skrytý label).
- Dropdown opatřit stabilním ID a vhodnými ARIA atributy (`role="listbox"`, jednotlivé výsledky jako `role="option"`). Ve výchozím stavu má být skrytý.
- Zachovat existující navigační tlačítka i pořadí hlavičky; na mobilu musí být možné hlavičku zalomit bez překrytí výsledků.

### 2. Přidat vyhledávací logiku

V `src/app.js`:

- Rozšířit `cacheDomReferences()` o wrapper vyhledávání, input a dropdown výsledků.
- Přidat vlastní helper `debounce(callback, delay)` s `setTimeout`/`clearTimeout` a použít prodlevu přesně 300 ms pro událost `input`.
- Přidat normalizaci dotazu pro case-insensitive porovnání. Pro každý event prohledávat `title`, `description` a `location`; chybějící hodnoty brát jako prázdný řetězec.
- Vyhledávat nad celým `state.events`, bez omezení aktuálním týdnem nebo zaškrtnutými kategoriemi.
- Výsledky seřadit chronologicky podle `date` a následně podle `startTime`, omezit na prvních 10 položek a zachovat stabilní pořadí při shodném datu a čase.
- Vytvořit samostatné funkce pro filtrování a vykreslení výsledků, aby šlo logiku ověřit bez vazby na konkrétní kliknutí v kalendáři. Vykreslovat uživatelský text přes `textContent`, ne přes HTML interpolaci.
- Každý výsledek zobrazit jako jednu položku s názvem, datem, časem a barevnou tečkou kategorie. Barvu primárně převzít z `event.color`, případně z odpovídající položky v `DEFAULT_CATEGORIES`.
- Pro neprázdný dotaz bez shody zobrazit přesný stav `Žádné výsledky`. Pro prázdný dotaz dropdown skrýt.

### 3. Napojit výsledek na navigaci a detail

Při kliknutí na výsledek:

1. Najít aktuální event podle jeho ID ve `state.events`.
2. Nastavit `state.currentWeekStart` na pondělí týdne, do kterého spadá datum eventu.
3. Zavolat `renderCalendar()` a tím překreslit kalendář na správný týden.
4. Zavolat `showEventDetail(event.id)` a otevřít existující detail.
5. Dropdown zavřít a podle potřeby vyčistit jeho výsledek, aby nezůstal otevřený přes modal.

Opakující se události řešit jako jeden uložený záznam: výsledek používá jeho uložené `date` a `startTime`, zatímco kalendář dál respektuje stávající pravidlo opakování v `getEventsForDate()`. Tím se nemění model nekonečných výskytů; případné vyhledávání konkrétní instance opakované události je mimo rozsah CAL-2.

### 4. Doplnit zavírání a životní cyklus dropdownu

- Rozšířit `setupEventListeners()` o posluchač `input`, který použije debounced vyhledávání.
- Přidat delegovaný nebo jednotlivý click handler pro položky výsledků.
- Kliknutí mimo wrapper vyhledávání má dropdown zavřít; kliknutí uvnitř výsledky nesmí okamžitě zavřít před výběrem.
- Rozšířit stávající globální obsluhu klávesy Escape tak, aby zavřela dropdown a současně zachovala současné zavírání modálů.
- Po vytvoření, úpravě nebo smazání události buď znovu vyhodnotit právě aktivní dotaz, nebo dropdown zavřít; nesmí zobrazovat neaktuální výsledek.
- Při změně kategorie dropdown nezáviset na `activeCategories`, protože vyhledávání má prohledat všechny uložené události.

### 5. Nastylovat vyhledávání

V `src/styles.css`:

- Přidat relativní pozicování wrapperu a absolutní dropdown pod inputem s dostatečným `z-index`, pozadím, ohraničením a existujícím stínem.
- Doplnit styly pro ikonu, input, položku výsledku, název, metadata, barevnou tečku a prázdný stav.
- Přidat hover/focus stav položek a viditelný focus stav inputu.
- V media query do 768 px nastavit šířku vyhledávání tak, aby se vešla do zalomené hlavičky; dropdown musí zůstat zarovnaný s inputem a text výsledku se nesmí překrývat s navigací.
- Zkontrolovat, že hlavička vyhledávání je při tisku skrytá společně s ostatními prvky hlavičky.

## Ověřovací scénáře

- Vyhledávací pole je viditelné v hlavičce na desktopu i mobilní šířce.
- Po zadání dotazu se výsledky objeví až po debounce přibližně 300 ms; při každém dalším psaní se předchozí timer zruší.
- Porovnání ignoruje velikost písmen a hledá samostatně v `title`, `description` i `location`.
- Událost nalezená v jiném týdnu se zobrazí, i když aktuální týden neobsahuje žádný výsledek.
- Výsledky seřadí podle data a času, zobrazí nejvýše 10 položek a barevnou tečku správné kategorie.
- Vypnutá kategorie v sidebaru neodstraní odpovídající výsledek vyhledávání.
- Kliknutí na výsledek přepne na týden uloženého data a otevře správný detail podle ID.
- Escape i kliknutí mimo vyhledávání dropdown zavřou; kliknutí na výsledek ho zavře před otevřením detailu.
- Pro dotaz bez shody se zobrazí `Žádné výsledky`; prázdný input dropdown nezobrazuje.
- Po přidání, úpravě nebo smazání události se výsledky nezobrazují v zastaralém stavu.
- Existující navigace týdnů, kliknutí na událost v kalendáři, modály a tisk zůstanou funkční.

## Rozsah a rizika

- CAL-2 nevyžaduje nový backend, knihovnu ani změnu formátu eventu; zdrojem je již načtený `state.events`.
- Aktuální klíč localStorage obsahuje datum (`copilotcal_events_YYYYMMDD`). Tento plán nepředělává storage model a výraz „všechny události“ interpretuje jako všechny eventy v `state.events`, nikoli jako agregaci napříč historickými date-suffixed klíči. Pokud má Jira požadovat i tuto mezidenní agregaci, je to samostatný storage návrh před implementací.
- Datum opakující se události je uložené datum záznamu; plán negeneruje nekonečné occurrence výsledky.
- Do stávajícího `Escape` handleru je nutné zasáhnout opatrně, aby zavírání vyhledávání nerozbilo zavírání modálů.

## Výstup implementace

- Upravené soubory: `src/index.html`, `src/app.js`, `src/styles.css`.
- Bez změny: localStorage schema, datový formát události, externí závislosti.
- Ověření dokončit ručně podle scénářů výše po otevření `src/index.html` přímo v prohlížeči.
