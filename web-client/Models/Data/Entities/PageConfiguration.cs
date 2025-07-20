using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using web_client.Models.Data.Entities.Base;

namespace web_client.Models.Data.Contexts.Entities;

public class PageConfiguration : BaseStatusEntity
{
    public Guid PageId { get; set; }
    public string Name { get; set; } = default!;
    public string ConfigType { get; set; } = default!;
    [Column(TypeName = "jsonb")]
    public JsonDocument Value { get; set; } = default!;
    [Column(TypeName = "jsonb")]
    public JsonDocument? PublicSetting { get; set; }
    [Column(TypeName = "jsonb")]
    public JsonDocument? PrivateSetting { get; set; }
    public int Sort { get; set; } = default!;
}
