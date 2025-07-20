using System.ComponentModel.DataAnnotations.Schema;
using ToamManage.Infrastructure.Persistence.Models;
using web_client.Models.Data.Entities.Base;

namespace web_client.Models.Data.Contexts.Entities;

public class GroupProductSetting : BaseStatusEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    [Column(TypeName = "jsonb")]
    public List<PropertyGroupProductSetting>? Properties { get; set; }
}
