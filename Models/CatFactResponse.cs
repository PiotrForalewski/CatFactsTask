using System.Text.Json.Serialization;

namespace CatFactsLogger.Models;

public record CatFactResponse(
    [property: JsonPropertyName("fact")] string Fact,
    [property: JsonPropertyName("length")] int Length
);