using System.Text.Json.Serialization;

namespace web_client.Models.Base;

public class BaseSelectDataModel
{
    [JsonIgnore]
    public Guid? Id { get; set; }
}

public class SelectDataSeoModel : BaseSelectDataModel
{
    [JsonIgnore]
    public string? PageKeyName { get; set; }
    public BaseFileModel? Image { get; set; }
}

