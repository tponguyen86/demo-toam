using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace web_client.Models.Data.Contexts.Entities;

public class RoleInformation
{
    public string Key { get; set; } = default!;

    public Guid ParentId { get; set; } = default!;

    public byte Level { get; set; }

    [Required]
    public string Status { get; set; } = default!;

    [Column(TypeName = "jsonb")]
    public JsonDocument Configuration { get; set; } = default!;

}
