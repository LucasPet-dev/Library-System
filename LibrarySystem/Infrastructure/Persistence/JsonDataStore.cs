using System.Text.Json;

namespace LibrarySystem.Api.Infrastructure.Persistence;

public class JsonDataStore<T> where T : class
{
    private readonly string _filePath;

    public JsonDataStore(string fileName)
    {
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        _filePath = Path.Combine(directory, fileName);

        if (!File.Exists(_filePath))
            File.WriteAllText(_filePath, "[]");
    }

    public List<T> GetAll()
    {
        var json = File.ReadAllText(_filePath);

        return JsonSerializer.Deserialize<List<T>>(json)
               ?? new List<T>();
    }

    public void SaveAll(List<T> data)
    {
        var json = JsonSerializer.Serialize(data,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(_filePath, json);
    }
}
