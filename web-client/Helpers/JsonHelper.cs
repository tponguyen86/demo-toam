using System.Text;
using System.Text.Json;

namespace web_client.Helpers;

public static class JsonHelper
{
    public static string SerializeObject(this object obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }

    public static string SerializeObject<T>(this T obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }

    public static T? DeserializeObject<T>(this Stream json)
    {
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }

    public static T? DeserializeObject<T>(this string json)
    {
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });
    }

    public static string DocumentToString(this JsonDocument source)
    {
        using var stream = new MemoryStream();
        Utf8JsonWriter writer = new(stream, new JsonWriterOptions
        {
            Indented = true
        });
        source.WriteTo(writer);
        writer.Flush();
        return Encoding.UTF8.GetString(stream.ToArray());
    }

    public static async Task<T?> DocumentToObjectAsync<T>(
            this JsonDocument source,
            JsonSerializerOptions? jsonSerializerOptions = default)
    {
        using var stream = new MemoryStream();
        Utf8JsonWriter writer = new(stream, new JsonWriterOptions
        {
            Indented = true
        });
        source.WriteTo(writer);
        await writer.FlushAsync();
        stream.Position = 0;
        jsonSerializerOptions ??= new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        return await JsonSerializer.DeserializeAsync<T>(stream, jsonSerializerOptions);
    }

    public static T? DocumentToObject<T>(
            this JsonDocument source,
            JsonSerializerOptions? jsonSerializerOptions = default)
    {
        using var stream = new MemoryStream();
        Utf8JsonWriter writer = new(stream, new JsonWriterOptions
        {
            Indented = true
        });
        source.WriteTo(writer);
        writer.Flush();
        jsonSerializerOptions ??= new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        return JsonSerializer.Deserialize<T>(stream.ToArray(), jsonSerializerOptions);
    }
    //Note: Call this for response
    public static T? DocumentToObject<T>(this JsonDocument source)
    {
        using var stream = new MemoryStream();
        Utf8JsonWriter writer = new(stream, new JsonWriterOptions
        {
            Indented = true
        });
        source.WriteTo(writer);
        writer.Flush();

        return JsonSerializer.Deserialize<T>(stream.ToArray());
    }

    public static JsonDocument ObjectToDocument(this object obj)
    {
        string jsonString = SerializeObject(obj);
        return JsonDocument.Parse(jsonString);
    }

    public static T ObjectCast<T>(this object input) where T : new()
    {
        if (input == null) return new T();
        return input.SerializeObject().DeserializeObject<T>();
    }
}

