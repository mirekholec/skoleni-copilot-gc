## Klíčové instrukce

Základní informace o projektu jsou v souboru `README.md`. 

- webová aplikace je napsaná v HTML, CSS a JS (JavaScript)
- aplikace musí být spustitelná vždy pouhým otevřením souboru `index.html` bez serveru
- data se uchovávají výhradně v localstorage webového prohlížeče
- čistota, udržitelnost a srozumitelnost kódu má prioritu i před výkonností


## Jazyková nastavení a komunikace

- komunikace probíhá v českém jazyce
- zdrojový kód je psán v anglickém jazyce
- komentáře ve zdrojovém kódu jsou česky

## Kód (HTML, CSS, JS)

- CSS styly piš výhradně do CSS souborů, nikdy nepoužívej inline CSS v HTML
- Uchovávej všechny CSS styly v jednom souboru styles.css

## Task Management

Pokud implementuješ task z `tasks` a úkol dokončíš, vždy automaticky přesuneš tento task do podsložky `tasks/completed` 

K dokončenému tasku vytvoř soubor, do kterého vložíš informace o implementaci. Název souboru bude vycházet z původního, například pokud implementuješ: `X-01-nazev-feature.md` tak název komplementárního souboru bude `X-01-nazev-feature-IMPL.md`.