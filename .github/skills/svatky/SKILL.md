---
name: svatky
description: Poskytne seznam českých státních a ostatních svátků pro zadaný rok včetně data, názvu, typu a dne v týdnu. Použij vždy, když uživatel žádá seznam státních či veřejných svátků, dnů pracovního klidu nebo českých svátků pro konkrétní rok.
compatibility: Vyžaduje .NET 10 nebo novější a síťový přístup k tomasmotl.cz.
---

# České státní svátky

Použij přibalený skript k získání aktuálních dat pro požadovaný kalendářní rok.

## Postup

1. Urči rok z požadavku uživatele. Relativní výrazy jako „letos“ nebo „příští rok“ převeď podle aktuálního data. Pokud rok nelze určit, vyžádej si jej.
2. Z kořene tohoto skillu spusť:

   ```bash
   dotnet run --file scripts/svatky.cs -- <YYYY>
   ```

   Nahraď `<YYYY>` čtyřmístným rokem, například `2027`.
3. Převeď CSV výstup do přehledného seznamu nebo Markdown tabulky se sloupci **Datum**, **Název**, **Typ** a **Den**. Zachovej pořadí i hodnoty vrácené skriptem.
4. V odpovědi vždy uveď rok, ke kterému seznam patří.

## Chybové stavy

- Nevymýšlej ani nedoplňuj svátky z paměti.
- Pokud skript, síťové volání nebo vzdálené API selže, sděl uživateli konkrétní chybu a nabídni opakování požadavku.
- Nezaměňuj data za jiný rok a při neplatném formátu roku spusť skript až po jeho opravě.

## Dostupný skript

- `scripts/svatky.cs` — načte české svátky pro rok předaný jako argument a vypíše je jako UTF-8 CSV.
