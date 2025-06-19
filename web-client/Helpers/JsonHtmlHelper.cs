using System.Text.Json;

namespace web_client.Helpers;

public static class JsonHtmlHelper
{
    public static string ToJsonCamelCase(object obj)
    {
        if (obj == null) return string.Empty;
        var json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return json.Replace("\"", "'");
    }
}
