using System.ComponentModel.DataAnnotations.Schema;
using ToamManage.Infrastructure.Persistence.Models;

namespace web_client.Models.Data.Contexts.Entities.Base;

public abstract class BaseSeo : BaseTitleSeo
{
    public string MetaTitle { get; set; } = default!;
    public string? MetaShortDescription { get; set; }
    [Column(TypeName = "jsonb")]
    public BaseFileModel? Image { get; set; }
}
