using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace web_client.Models.Data.Contexts.Entities;

public class ProductCategory : Category
{
    public Guid GroupProductSetting { get; set; }
    //BaseAttribute : tạm thời không cần, chỉ cần ở product
    [Column(TypeName = "jsonb")]
    public JsonDocument? Attribute { get; set; }
}
