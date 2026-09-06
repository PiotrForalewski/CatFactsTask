using System.Net.Http.Json;
using CatFactsLogger.Models;

namespace CatFactsLogger.Services;

public class CatFactService : ICatFactService
{
    private readonly HttpClient _httpClient;

    // Przekazujemy HttpClient przez konstruktor - to jest właśnie Dependency Injection!
    public CatFactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFactResponse?> GetRandomFactAsync()
    {
        // Ta jedna linijka wysyła zapytanie GET i od razu konwertuje odpowiedź JSON na nasz obiekt C#
        var response = await _httpClient.GetFromJsonAsync<CatFactResponse>("https://catfact.ninja/fact");
        
        return response;
    }
}