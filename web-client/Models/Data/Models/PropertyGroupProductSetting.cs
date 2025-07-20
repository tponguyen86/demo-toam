using System.ComponentModel.DataAnnotations.Schema;

namespace ToamManage.Infrastructure.Persistence.Models;

public class PropertyGroupProductSetting
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    [Column(TypeName = "jsonb")]
    public List<PropertySelectModel>? Properties { get; set; }
    public bool Selected { get; set; }
    public bool ShowInPageList { get; set; }
}
