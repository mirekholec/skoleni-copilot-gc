# CAL-013: Implementace počítadla událostí

## Provedené změny

- Do hlavičky byl přidán badge `#eventCount` za `#weekRange`.
- Badge má červené kulaté pozadí, bílý text a zobrazí se pouze při nenulovém počtu.
- Element je uložen v `dom.eventCount`.
- `renderEventCount()` počítá viditelné výskyty událostí v aktuálním týdnu a respektuje aktivní kategorie.
- Počítadlo se překresluje společně s kalendářem, takže se aktualizuje při navigaci, změně filtrů i změnách událostí.

## Omezení

Aktuální aplikace obsahuje pouze týdenní pohled. Měsíční pohled je samostatné zadání CAL-001; po jeho implementaci je potřeba napojit `renderEventCount()` také na jeho renderovací cestu.

## Ověření

- `node --check src/app.js`
- Browserové ověření nebylo provedeno na žádost uživatele.
