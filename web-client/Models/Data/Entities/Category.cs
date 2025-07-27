using System.ComponentModel.DataAnnotations.Schema;
using web_client.Models.Base;
using web_client.Models.Data.Contexts.Entities.Base;

namespace web_client.Models.Data.Contexts.Entities;

public class Category : BaseSeo
{
    public string Name { get; set; } = null!;
    public Guid? ParentId { get; set; }
    public Guid Type { get; set; }
    public int? Sort { get; set; }
    public bool ShowMenu { get; set; }
    public bool HasContent { get; set; }
    public string? ShortDescription { get; set; }
    [Column(TypeName = "jsonb")]
    public BaseFileModel? Banner { get; set; }
    public bool ShowHome { get; set; }
    public string? ShowType { get; set; }
    //Phân biệt table ProductCategory
    public string? Discriminator { get; set; }
}
