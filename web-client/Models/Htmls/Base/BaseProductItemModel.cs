using web_client.Models.Base;

namespace web_client.Models.Htmls.Base;

public class BaseProductItemModel : BaseMediaLinkModel
{
    public Guid Id { get; set; }
    public string? Sku { get; set; }
    public decimal? Price { get; set; }
    public decimal? Sale { get; set; }
    public bool DisplayPrice { get; set; }
    public bool DisplaySale { get; set; }
    public bool DisplayContact { get; set; }

    public List<BaseAttributeItemModel>? Attributes { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    //category
    public BaseMediaLinkModel? Group { get; set; }

    public BaseProductItemModel() { }
}
