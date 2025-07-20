using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using web_client.Models.Data.Entities.Base;

namespace web_client.Models.Data.Contexts.Entities;

public class RoleFeature : BaseStatusEntity
{
    public string AppName { get; set; } = default!;
    public string Key { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int Level { get; set; }
    public string? Parent { get; set; }

    [Column(TypeName = "jsonb")]
    public JsonDocument? Configuration { get; set; }
}