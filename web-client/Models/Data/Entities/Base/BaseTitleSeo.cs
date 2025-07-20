using web_client.Models.Data.Entities.Base;

namespace web_client.Models.Data.Contexts.Entities.Base;

public abstract class BaseTitleSeo : BaseStatusEntity
{
    public string PageKeyName { get; set; } = default!;
    public string MetaKeyword { get; set; } = default!;
    public string? Canonical { get; set; }
}
