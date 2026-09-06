namespace CatFactsLogger.Services;

public interface IFileWriterService
{
    Task AppendFactToFileAsync(string factText);
}