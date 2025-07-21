using System.ComponentModel.DataAnnotations.Schema;
using web_client.Models.Base;

namespace web_client.Models.Data.Contexts.Entities.Base;

public abstract class BaseSeo : BaseTitleSeo
{
    public string MetaTitle { get; set; } = default!;
    public string? MetaShortDescription { get; set; }
    [Column(TypeName = "jsonb")]
    public BaseFileModel? Image { get; set; }
}
