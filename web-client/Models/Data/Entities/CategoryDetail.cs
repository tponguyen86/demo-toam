using System.ComponentModel.DataAnnotations.Schema;
using web_client.Models.Data.Contexts.Entities.Base;

namespace web_client.Models.Data.Contexts.Entities;

public class CategoryDetail : BaseSeo
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = default!;
    public string NameSearch { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string ShortDescription { get; set; } = default!;
    public int Sort { get; set; }
    public bool Hot { get; set; }

    [Column(TypeName = "jsonb")]
    public List<Guid>? Projects { get; set; }

    [Column(TypeName = "jsonb")]
    public List<Guid>? Products { get; set; }
}