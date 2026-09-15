#!/usr/bin/env -S dotnet --

using System.Globalization;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

if (args.Length > 1)
{
    throw new ArgumentException("Expected zero or one argument in yyyy format.");
}

var year = 2026;

if (args.Length == 1 &&
    (args[0].Length != 4 ||
     !int.TryParse(args[0], NumberStyles.None, CultureInfo.InvariantCulture, out year) ||
     year < 1))
{
    throw new ArgumentException("The year must be a four-digit value in yyyy format.");
}

var endpoint = $"https://tomasmotl.cz/api/svatky/{year:D4}";

using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("skoleni-copilot-svatky/1.0");

var response = await httpClient.GetFromJsonAsync(endpoint, AppJsonContext.Default.HolidayResponse)
    ?? throw new InvalidDataException("API returned an empty response.");

var holidays = response.Holidays
    ?? throw new InvalidDataException("API response does not contain the 'svatky' collection.");

await using var output = new StreamWriter(
    Console.OpenStandardOutput(),
    new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

await output.WriteLineAsync("datum,nazev,typ,den");

foreach (var holiday in holidays)
{
    if (holiday.Date is null ||
        holiday.Name is null ||
        holiday.Type is null ||
        holiday.Day is null)
    {
        throw new InvalidDataException("API response contains an incomplete holiday.");
    }

    await output.WriteLineAsync(string.Join(",",
        EscapeCsv(holiday.Date),
        EscapeCsv(holiday.Name),
        EscapeCsv(holiday.Type),
        EscapeCsv(holiday.Day)));
}

static string EscapeCsv(string value)
{
    if (!value.Contains('"') &&
        !value.Contains(',') &&
        !value.Contains('\r') &&
        !value.Contains('\n'))
    {
        return value;
    }

    return $"\"{value.Replace("\"", "\"\"")}\"";
}

sealed class HolidayResponse
{
    [JsonPropertyName("svatky")]
    public List<Holiday>? Holidays { get; init; }
}

sealed class Holiday
{
    [JsonPropertyName("datum")]
    public string? Date { get; init; }

    [JsonPropertyName("nazev")]
    public string? Name { get; init; }

    [JsonPropertyName("typ")]
    public string? Type { get; init; }

    [JsonPropertyName("den")]
    public string? Day { get; init; }
}

[JsonSerializable(typeof(HolidayResponse))]
partial class AppJsonContext : JsonSerializerContext
{
}
