using Microsoft.Extensions.DependencyInjection;
using CatFactsLogger.Services;

// 1. Konfiguracja Dependency Injection
var services = new ServiceCollection();

// Rejestrujemy HttpClient od razu powiązany z naszym serwisem
services.AddHttpClient<ICatFactService, CatFactService>();
// Rejestrujemy serwis do zapisu plików
services.AddTransient<IFileWriterService, FileWriterService>();

// Budujemy kontener DI
var serviceProvider = services.BuildServiceProvider();

// 2. Wyciągamy z kontenera gotowe do pracy serwisy
var catFactService = serviceProvider.GetRequiredService<ICatFactService>();
var fileWriterService = serviceProvider.GetRequiredService<IFileWriterService>();

// 3. Logika aplikacji (Główna pętla)
Console.WriteLine("=== Witaj w aplikacji CatFactsLogger! ===");
Console.WriteLine("Naciśnij ENTER, aby pobrać nowy fakt o kotach. Wpisz 'exit', aby wyjść.");

while (true)
{
    var input = Console.ReadLine();
    if (input?.ToLower() == "exit") break;

    Console.WriteLine("Pobieranie danych z API...");
    
    var response = await catFactService.GetRandomFactAsync();

    if (response != null)
    {
        Console.WriteLine($"Fakt: {response.Fact}");
        Console.WriteLine($"Długość: {response.Length}");
        
        // Zapis do pliku
        string logLine = $"[{DateTime.Now:HH:mm:ss}] Fakt: {response.Fact} | Długość: {response.Length}";
        await fileWriterService.AppendFactToFileAsync(logLine);
        
        Console.WriteLine("-> Zapisano pomyślnie do pliku CatFacts.txt");
    }
    else
    {
        Console.WriteLine("Błąd: Nie udało się pobrać danych z API.");
    }
    
    Console.WriteLine("\nNaciśnij ENTER, aby pobrać kolejny fakt (lub wpisz 'exit').");
}