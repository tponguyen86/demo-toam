namespace web_client.Models.Request.GroupProductSettings.Properties;

public class BaseAttributePropertyValue
{
    /// <summary>
    /// value ex: Omron
    /// </summary>
    public string? Value { get; set; }
    //string , number , array, object..... default null => string
    public string? Type { get; set; } = "";
}
