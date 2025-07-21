using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using web_client.Models.Data.Entities.Base;

namespace web_client.Models.Data.Entities;

public class PredefineData : BaseStatusEntity
{
    [Required]
    public string Group { get; set; } = default!;

    public string Key { get; set; } = default!;
    public string Value { get; set; } = default!;
    public int Sort { get; set; }

    [Column(TypeName = "jsonb")]
    public JsonDocument? PublicSetting { get; set; }

    [Column(TypeName = "jsonb")]
    public JsonDocument? PrivateSetting { get; set; }

    public bool AllowAll { get; set; }

    public PredefineData? DeepClone()
    {
        return this.MemberwiseClone() as PredefineData;
    }
}