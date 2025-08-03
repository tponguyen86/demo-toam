using System.Text.Json.Serialization;

namespace web_client.Models.Base;

public class BaseSelectModel<TData> where TData : class
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
    public TData? Data { get; set; }
    public void SetData(TData? data)
    {
        if (data == null) return;
        Data = data;
    }
    //public TData? GetData<TData>() where TData : class
    //{
    //    return Data as TData;
    //}

    //public bool TryGetData<TData>(out TData? result) where TData : class
    //{
    //    result = Data as TData;
    //    return result != null;
    //}
}

public class BaseSelectModel : BaseSelectModel<object>
{
    public BaseSelectModel() : base() { }
    public BaseSelectModel(string value) : base(value) { }

    public BaseSelectModel(Guid value) : base(value) { }
    public BaseSelectModel(Guid? value) : base(value) { }
    public BaseSelectModel(string value, string label) : base(value, label) { }

    public BaseSelectModel(string value, string label, string key) : base(value, label, key) { }
    public TData? GetData<TData>() where TData : class
    {
        return Data as TData;
    }

    public bool TryGetData<TData>(out TData? result) where TData : class
    {
        result = Data as TData;
        return result != null;
    }
}

#region Data item
public class BaseSelectDataModel
{
    [JsonIgnore]
    public Guid? Id { get; set; }
}
public class SelectDataSeoModel: BaseSelectDataModel
{
    [JsonIgnore]
    public string? PageKeyName { get; set; }
}
#endregion