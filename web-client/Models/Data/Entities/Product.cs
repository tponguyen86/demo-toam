using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using web_client.Models.Base;
using web_client.Models.Data.Contexts.Entities.Base;
using web_client.Models.Request.GroupProductSettings.Properties;

namespace web_client.Models.Data.Contexts.Entities;

public class Product : BaseSeo
{
    public string Name { get; set; } = null!;
    public string? Sku { get; set; }
    //public string? Unit { get; set; }

    public Guid GroupProductSetting { get; set; }
    //BaseAttribute
    [Column(TypeName = "jsonb")]
    public BaseAttribute? Attribute { get; set; }
    //public PropertyAttribute? Attribute { get; set; }

    public Guid ProductCategory { get; set; }
    //[Column(TypeName = "jsonb")]
    //public BaseFileModel Image { get; set; }

    [Column(TypeName = "jsonb")]
    public List<BaseFileModel>? Medias { get; set; }

    public decimal? Price { get; set; }
    public bool PriceHidden { get; set; }
    public bool Featured { get; set; }

    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public string? Technical { get; set; }
    public string? Datasheet { get; set; }
}
