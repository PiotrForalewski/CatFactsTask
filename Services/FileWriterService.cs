namespace CatFactsLogger.Services;

public class FileWriterService : IFileWriterService
{
    private readonly string _filePath = "CatFacts.txt";

    public async Task AppendFactToFileAsync(string factText)
    {
        // Ta metoda spełnia wymóg: tworzy plik lokalnie i dopisuje nowy wiersz
        await File.AppendAllTextAsync(_filePath, factText + Environment.NewLine);
    }
}