using Microsoft.Extensions.DependencyInjection;
using CatFactsLogger.Services;

var services = new ServiceCollection();

services.AddHttpClient<ICatFactService, CatFactService>();
services.AddTransient<IFileWriterService, FileWriterService>();

var serviceProvider = services.BuildServiceProvider();

var catFactService = serviceProvider.GetRequiredService<ICatFactService>();
var fileWriterService = serviceProvider.GetRequiredService<IFileWriterService>();

Console.WriteLine("=== Welcome to CatFactsLogger! ===");
Console.WriteLine("Press ENTER to fetch a new cat fact. Type 'exit' to quit.");

while (true)
{
    var input = Console.ReadLine();
    if (input?.ToLower() == "exit") break;

    Console.WriteLine("Fetching data from API...");
    
    var response = await catFactService.GetRandomFactAsync();

    if (response != null)
    {
        Console.WriteLine($"Fact: {response.Fact}");
        Console.WriteLine($"Length: {response.Length}");
        
        string logLine = $"[{DateTime.Now:HH:mm:ss}] Fact: {response.Fact} | Length: {response.Length}";
        await fileWriterService.AppendFactToFileAsync(logLine);
        
        Console.WriteLine("-> Successfully saved to CatFacts.txt");
    }
    else
    {
        Console.WriteLine("Error: Failed to fetch data from API.");
    }
    
    Console.WriteLine("\nPress ENTER to fetch another fact (or type 'exit').");
}