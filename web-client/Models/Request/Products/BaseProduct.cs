using web_client.Models.Base;

namespace web_client.Models.Request.Products;

public class BaseProduct : BaseSeoModel
{
    public string Name { get; set; } = null!;
    public string? Sku { get; set; }

    public Guid ProductCategory { get; set; }
    //public BaseFileModel Image { get; set; }

    public string? ShortDescription { get; set; }
    public bool Featured { get; set; }

    public decimal? Price { get; set; }
    public bool PriceHidden { get; set; }
    public decimal? Sale { get; set; }
    public bool SaleHidden { get; set; } = true;
    public string? Status { get; set; }

}