#:property TargetFramework=net10.0

using System;
using System.Collections.Generic;
using System.Globalization;

return HolidayProgram.Run(args);

internal static class HolidayProgram
{
    private static readonly CultureInfo CzechCulture = CultureInfo.GetCultureInfo("cs-CZ");

    public static int Run(string[] arguments)
    {
        if (arguments.Length == 1 && (arguments[0] == "-h" || arguments[0] == "--help"))
        {
            PrintUsage();
            return 0;
        }

        if (arguments.Length != 1)
        {
            Console.Error.WriteLine("Chyba: Zadejte právě jeden rok.");
            PrintUsage();
            return 2;
        }

        if (!int.TryParse(arguments[0], NumberStyles.None, CultureInfo.InvariantCulture, out var year)
            || year < DateOnly.MinValue.Year
            || year > DateOnly.MaxValue.Year)
        {
            Console.Error.WriteLine("Chyba: Rok musí být celé číslo v rozsahu 1 až 9999.");
            return 2;
        }

        Console.WriteLine($"Svátky České republiky v roce {year}:");

        foreach (var holiday in GetHolidays(year))
        {
            var date = holiday.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            var weekday = holiday.Date.ToString("dddd", CzechCulture);
            Console.WriteLine($"{date} ({weekday}) - {holiday.Name}");
        }

        return 0;
    }

    private static List<Holiday> GetHolidays(int year)
    {
        var easterSunday = CalculateEasterSunday(year);
        var holidays = new List<Holiday>
        {
            new(new DateOnly(year, 1, 1), "Den obnovy samostatného českého státu a Nový rok"),
            new(easterSunday.AddDays(-2), "Velký pátek"),
            new(easterSunday.AddDays(1), "Velikonoční pondělí"),
            new(new DateOnly(year, 5, 1), "Svátek práce"),
            new(new DateOnly(year, 5, 8), "Den vítězství"),
            new(new DateOnly(year, 7, 5), "Den slovanských věrozvěstů Cyrila a Metoděje"),
            new(new DateOnly(year, 7, 6), "Den upálení mistra Jana Husa"),
            new(new DateOnly(year, 9, 28), "Den české státnosti"),
            new(new DateOnly(year, 10, 28), "Den vzniku samostatného československého státu"),
            new(new DateOnly(year, 11, 17), "Den boje za svobodu a demokracii a Mezinárodní den studentstva"),
            new(new DateOnly(year, 12, 24), "Štědrý den"),
            new(new DateOnly(year, 12, 25), "1. svátek vánoční"),
            new(new DateOnly(year, 12, 26), "2. svátek vánoční"),
        };

        holidays.Sort((left, right) => left.Date.CompareTo(right.Date));
        return holidays;
    }

    private static DateOnly CalculateEasterSunday(int year)
    {
        var metonicCycle = year % 19;
        var century = year / 100;
        var yearInCentury = year % 100;
        var leapCenturies = century / 4;
        var centuryRemainder = century % 4;
        var correction = (century + 8) / 25;
        var moonCorrection = (century - correction + 1) / 3;
        var epact = (19 * metonicCycle + century - leapCenturies - moonCorrection + 15) % 30;
        var yearQuarter = yearInCentury / 4;
        var yearRemainder = yearInCentury % 4;
        var weekdayCorrection = (32 + 2 * centuryRemainder + 2 * yearQuarter - epact - yearRemainder) % 7;
        var monthCorrection = (metonicCycle + 11 * epact + 22 * weekdayCorrection) / 451;
        var month = (epact + weekdayCorrection - 7 * monthCorrection + 114) / 31;
        var day = (epact + weekdayCorrection - 7 * monthCorrection + 114) % 31 + 1;

        return new DateOnly(year, month, day);
    }

    private static void PrintUsage()
    {
        Console.WriteLine("Použití: dotnet svatky.cs <rok>");
    }

    private sealed record Holiday(DateOnly Date, string Name);
}
