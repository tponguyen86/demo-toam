using System.Text.Json.Serialization;

namespace web_client.Models.Base;

public class CategorySelectModel : BaseSelectCustomModel
{
    public CategorySelectModel(Guid id) : base(id) { }
    public CategoryDataSelectModel? GetDataSelectModel()
    {
        return GetData<CategoryDataSelectModel>();
    }
}
public class CategoryDataSelectModel : BaseSelectDataModel
{
    public BaseFileModel? Image { get; set; }
    [JsonIgnore]
    public string? PageKeyName { get; set; }

    public Guid? ParentId { get; set; }

    public int? Sort { get; set; }
    public bool ShowMenu { get; set; }

    public string? ShortDescription { get; set; }

    public BaseFileModel? Banner { get; set; }
    public bool ShowHome { get; set; }

}