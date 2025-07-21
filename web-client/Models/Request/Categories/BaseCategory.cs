using web_client.Helpers.Shared;
using web_client.Models.Base;

namespace web_client.Models.Request.Categories;

public class BaseCategory : BaseSeoModel
{
    public string Name { get; set; } = default!;
    public string ShortDescription { get; set; } = default!;
    public Guid? ParentId { get; set; }
    public bool ShowMenu { get; set; }
    public Guid Type { get; set; } = Guid.Empty;
    public int Sort { get; set; }
    public BaseFileModel? Banner { get; set; }

    public string? Status { get; set; } = StatusConst.Active;
}