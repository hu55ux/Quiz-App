using System.Text.Json;

namespace QuizGame.Helper;

public static class JsonHelper
{
    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public static void SaveToJson<T>(List<T> data, string filepath)
    {
        string json = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(filepath, json);
    }

    public static void SaveToJson<T>(T data, string filepath)
    {
        string json = JsonSerializer.Serialize(data, _options);
        File.WriteAllText(filepath, json);
    }

    public static List<T> LoadListFromJson<T>(string filepath)
    {
        if (!File.Exists(filepath))
        {
            throw new FileNotFoundException($"File not found: {filepath}");
        }
        string json = File.ReadAllText(filepath);
        return JsonSerializer.Deserialize<List<T>>(json, _options)
               ?? throw new InvalidOperationException("Deserialization returned null");
    }

    public static T LoadObjectFromJson<T>(string filepath)
    {
        if (!File.Exists(filepath))
        {
            throw new FileNotFoundException($"File not found: {filepath}");
        }
        string json = File.ReadAllText(filepath);
        return JsonSerializer.Deserialize<T>(json, _options)
               ?? throw new InvalidOperationException("Deserialization returned null");
    }
}