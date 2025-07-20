using System.ComponentModel.DataAnnotations;

namespace web_client.Models.Data.Entities.Base;

public abstract class BaseStatusEntity : BaseEntity
{
    protected BaseStatusEntity() { }

    [Required]
    public string Status { get; set; }
}