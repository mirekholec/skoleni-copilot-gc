# CAL-002: Vyhledávání událostí

**Summary:** Vyhledávací pole pro rychlé nalezení události podle textu
**Priorita:** Medium
**Story points:** Neuvedeno v Jira
**Labels:** žádné (Jira)

## Popis

Přidat vyhledávací pole do hlavičky kalendáře, které umožní rychle najít událost podle názvu, popisu nebo místa.

## Požadavky

- Vyhledávací pole v headeru s ikonou lupy a textovým inputem
- Hledání v reálném čase při psaní s debounce prodlevou 300 ms
- Prohledávat pole `title`, `description` a `location` u všech událostí v `state.events`
- Hledání provádět bez rozlišení velikosti písmen
- Výsledky zobrazit jako dropdown pod vyhledávacím polem
- Každý výsledek zobrazí název události, datum, čas a kategorii s barevnou tečkou
- Zobrazit nejvýše 10 výsledků seřazených chronologicky podle data a času začátku
- Kliknutí na výsledek otevře detail události a přepne kalendář na týden odpovídající datu události
- Klávesa Escape nebo kliknutí mimo vyhledávání zavře dropdown
- Pokud vyhledávání nic nenajde, zobrazit stav „Žádné výsledky“

## Technické poznámky

- Upravit `src/index.html`, `src/app.js` a `src/styles.css`; není potřeba měnit formát dat ani přidávat knihovnu.
- Vyhledávání pracuje nad `state.events`, nikoli pouze nad událostmi aktuálně zobrazeného týdne nebo aktivními kategoriemi.
- Debounce implementovat vlastní funkcí v `src/app.js`; při každém novém vstupu zrušit předchozí naplánované vyhodnocení.
- Výsledky vytvářet přes DOM API a vkládat text pomocí `textContent`, aby obsah událostí nebyl interpretován jako HTML.
- Barvu kategorie převzít z `event.color` s případným fallbackem na odpovídající položku v `DEFAULT_CATEGORIES`; kategorii opatřit dostupným názvem.
- Při výběru výsledku využít existující `getMonday()` a `showEventDetail()`; datum výsledku vychází z uloženého `event.date`, včetně opakujících se událostí.
- Klik mimo obal vyhledávání nesmí zavřít dropdown při interakci s inputem ani s položkou výsledků. Stávající obsluhu Escape pro modály rozšířit tak, aby přednostně zavřela otevřený dropdown.
- CSS doplnit o stav viditelnosti, pozici dropdownu, řádky výsledků, prázdný stav, focus/hover a responzivní rozložení v existujícím headeru.

## Implementační plán

1. V `src/index.html` doplnit do headeru obal vyhledávání s ikonou lupy, inputem a prázdným kontejnerem pro dropdown výsledků; přidat potřebné identifikátory a atributy pro přístupnost.
2. V `src/app.js` rozšířit cache DOM referencí a stav o vyhledávání včetně reference na debounce timer a informace, zda je dropdown otevřený.
3. V `src/app.js` vytvořit funkci pro normalizaci dotazu a filtrování `state.events` přes `title`, `description` a `location`; výsledek seřadit podle `date` a `startTime`, omezit na 10 položek a pro prázdný dotaz vracet prázdný seznam.
4. Vykreslit dropdown přes DOM API včetně názvu, formátovaného data, času, barevné tečky kategorie a stavu „Žádné výsledky“; každé položce zachovat `event.id` pro následný výběr.
5. Zaregistrovat input listener s debounce 300 ms a obsluhu výběru výsledku: zavřít dropdown, nastavit týden pomocí `getMonday(new Date(event.date + 'T00:00:00'))`, překreslit kalendář a otevřít detail přes `showEventDetail(event.id)`.
6. Doplnit zavření dropdownu klávesou Escape a kliknutím mimo vyhledávání tak, aby existující zavírání modálů zůstalo funkční; po změně dat zajistit, že otevřený seznam používá aktuální `state.events`.
7. V `src/styles.css` nastavit vzhled a vrstvení dropdownu, čitelné řádky výsledků, focus/hover stavy a chování vyhledávání v mobilním headeru.
8. Ručně ověřit vyhledání podle všech tří polí, case-insensitive shodu, debounce, řazení a limit 10 výsledků, prázdný stav, navigaci na týden, otevření detailu a zavírání přes Escape i kliknutí mimo.

## Akceptační kritéria

- [ ] Vyhledávací pole s ikonou lupy je viditelné v headeru.
- [ ] Výsledky se zobrazují při psaní po debounce prodlevě 300 ms.
- [ ] Hledání bez rozlišení velikosti písmen prohledává název, popis i lokaci všech událostí.
- [ ] Výsledky obsahují název, datum, čas a kategorii s barevnou tečkou, jsou chronologicky seřazené a jejich počet nepřekročí 10.
- [ ] Při nulovém počtu shod se zobrazí „Žádné výsledky“.
- [ ] Kliknutí na výsledek přepne na správný týden a otevře detail vybrané události.
- [ ] Escape i kliknutí mimo vyhledávání zavře dropdown bez narušení práce s modály.