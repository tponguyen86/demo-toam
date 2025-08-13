using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Response.Products;

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
    public BaseProductItemModel(ProductItemResponse productItem)
    {
        if (productItem == null) return;
        Id = productItem.Id;
        Title = productItem.Name;
        Href = string.Format(RouteConst.ProductDetail, productItem.PageKeyName);
        Media = productItem.Image?.Path;
        Sku = productItem.Sku;
        Price = productItem.Price;
        Sale = productItem.Sale;
        DisplayPrice = !productItem.PriceHidden;
        DisplaySale = !productItem.SaleHidden;
        DisplayContact = productItem.PriceHidden;
        CreatedAt = productItem.CreatedAt;
        if (productItem.ProductCategoryModel != null)
        {
            Group = new BaseMediaLinkModel(productItem.ProductCategoryModel.Label, string.Format(RouteConst.ProductCategory, productItem.ProductCategoryModel.Key));
        }
        //Attributes = productItem.Attribute?.Select(a => new BaseAttributeItemModel(a.Label, a.Title, a.Key)).ToList();
    }
}
