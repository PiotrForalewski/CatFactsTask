namespace CatFactsLogger.Services;

public class FileWriterService : IFileWriterService
{
    private readonly string _filePath = "CatFacts.txt";

    public async Task AppendFactToFileAsync(string factText)
    {
        await File.AppendAllTextAsync(_filePath, factText + Environment.NewLine);
    }
}