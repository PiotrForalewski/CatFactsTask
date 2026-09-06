using CatFactsLogger.Models;

namespace CatFactsLogger.Services;

public interface ICatFactService
{
    Task<CatFactResponse?> GetRandomFactAsync();
}