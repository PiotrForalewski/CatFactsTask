using CatFactsLogger.Models;

namespace CatFactsLogger.Services;

public interface ICatFactService
{
    // Metoda asynchroniczna, która zwróci pobrany fakt (lub null w przypadku błędu)
    Task<CatFactResponse?> GetRandomFactAsync();
}