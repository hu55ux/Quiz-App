//using System.Text.Json;
//namespace QuizGame.Helper;


//public static class JsonHelper
//{
//    private static readonly JsonSerializerOptions _options = new()
//    {
//        WriteIndented = true,
//        PropertyNameCaseInsensitive = true
//    };

//    public static void SaveToJson<T>(T data, string filepath)
//    {
//        try
//        {
//            string json = JsonSerializer.Serialize(data, _options);
//            File.WriteAllText(filepath, json);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"❌ Error saving data to {filepath}: {ex.Message}");
//        }
//    }

//    public static List<T> LoadListFromJson<T>(string filepath)
//    {
//        if (!File.Exists(filepath))
//        {
//            Console.WriteLine($"⚠️ File not found: {filepath}. Returning empty list.");
//            return new List<T>();
//        }

//        try
//        {
//            string json = File.ReadAllText(filepath);
//            return JsonSerializer.Deserialize<List<T>>(json, _options) ?? new List<T>();
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"❌ Error reading {filepath}: {ex.Message}. Returning empty list.");
//            return new List<T>();
//        }
//    }

//    public static T LoadObjectFromJson<T>(string filepath) where T : new()
//    {
//        if (!File.Exists(filepath))
//        {
//            Console.WriteLine($"⚠️ File not found: {filepath}. Returning default instance.");
//            return new T();
//        }

//        try
//        {
//            string json = File.ReadAllText(filepath);
//            return JsonSerializer.Deserialize<T>(json, _options) ?? new T();
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"❌ Error reading {filepath}: {ex.Message}. Returning default instance.");
//            return new T();
//        }
//    }
//}
