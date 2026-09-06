using System.Text.Json.Serialization;

namespace CatFactsLogger.Models;

// Używamy typu 'record', który jest idealny do przechowywania danych (niemutowalny model)
public record CatFactResponse(
    [property: JsonPropertyName("fact")] string Fact,
    [property: JsonPropertyName("length")] int Length
);