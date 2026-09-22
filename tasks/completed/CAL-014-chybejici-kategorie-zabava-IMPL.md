# CAL-014: Implementace kategorie Zábava ve formuláři

## Provedené změny

- Do `#inputCategory` byly doplněny všechny kategorie ve stejném pořadí jako v `DEFAULT_CATEGORIES`, včetně `🎬 Zábava` na konci.
- Do `DEFAULT_CATEGORIES` byla doplněna kategorie `entertainment` s barvou `#06B6D4`.
- Kategorie `entertainment` byla přidána mezi výchozí aktivní kategorie, takže se zobrazuje v sidebaru a události s ní používají cyan barvu.

## Ověření

- `node --check src/app.js`
- Browserové ověření nebylo provedeno, protože nebylo vyžádáno.
