using System.Net.Http.Json;
using CatFactsLogger.Models;

namespace CatFactsLogger.Services;

public class CatFactService : ICatFactService
{
    private readonly HttpClient _httpClient;

    public CatFactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFactResponse?> GetRandomFactAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<CatFactResponse>("https://catfact.ninja/fact");
        
        return response;
    }
}