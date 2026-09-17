# CAL-013: Implementace počítadla událostí

## Implementace

- Do hlavičky byl přidán badge `#eventCount` se stylem `.event-count`.
- Reference na badge se ukládá do `dom.eventCount`.
- `renderEventCount()` počítá události všech sedmi dnů aktuálního týdne a respektuje aktivní kategorie.
- Badge se skryje atributem `hidden`, pokud je počet událostí nulový.
- Počet se překresluje při každém `renderCalendar()`, tedy při navigaci, změně filtru i změně událostí.

## Rozsah

Repozitář v době implementace obsahuje pouze týdenní pohled. Podpora měsíčního pohledu zůstává součástí tasku CAL-001.

## Upravené soubory

- [index.html](../../src/index.html)
- [styles.css](../../src/styles.css)
- [app.js](../../src/app.js)
