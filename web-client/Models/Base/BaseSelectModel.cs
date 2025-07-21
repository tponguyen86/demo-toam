using System.Text.Json.Serialization;

namespace web_client.Models.Base;

public class BaseSelectModel
{
    public string? Key { get; set; }
    public string? Value { get; set; }
    public string? Label { get; set; }
    /// <summary>
    /// maybe value or id
    /// </summary>
    /// <returns></returns>
    public virtual string GetKeyFilter()
    {
        return Value ?? Key ?? "";
    }
    public BaseSelectModel()
    {
    }
    public BaseSelectModel(string value)
    {
        Value = value;
        Key = value;
        Label = value;
    }
    public BaseSelectModel(Guid? value) : this($"{value}") { }
    public BaseSelectModel(string value, string label) : this(value)
    {
        Label = label;
    }
    public BaseSelectModel(string value, string label, string key) : this(value, label)
    {
        Key = key;
    }
    [JsonIgnore]
    public object? Data { get; set; }
    public void SetData(object? data)
    {
        if (data == null) return;
        Data = data;
    }
}

public class BaseSelectModel<T> : BaseSelectModel
{
    public T? Settings { get; set; }
}