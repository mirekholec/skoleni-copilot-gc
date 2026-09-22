---
name: svatky
description: Vrací chronologický seznam zákonných svátků České republiky pro zvolený rok. Použij, když uživatel potřebuje termíny českých státních svátků, dnů pracovního klidu nebo velikonočních svátků.
compatibility: Vyžaduje .NET SDK 10 nebo novější s podporou C# file-based aplikací.
---

# České svátky

Vrať seznam zákonných svátků České republiky pro rok, který uživatel uvede.

## Postup

1. Zjisti požadovaný rok jako celé číslo.
2. Ve složce tohoto skillu spusť:

   ```bash
   dotnet svatky.cs <rok>
   ```

3. Vrať uživateli výstup skriptu beze změny.

## Vstup

Skript vyžaduje právě jeden argument: rok od `2000` do `2030`.

```bash
dotnet svatky.cs 2026
```

Pro nápovědu lze použít:

```bash
dotnet svatky.cs --help
```

## Výstup

Výstup obsahuje datum ve formátu ISO 8601, český název dne v týdnu a název svátku. Zahrnuje státní i ostatní zákonné svátky a dny pracovního klidu, aby pokryl běžný význam požadavku na seznam státních svátků.
