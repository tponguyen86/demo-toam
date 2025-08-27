using web_client.Helpers;
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
    public string? ShortDescription { get; set; }
    public List<BaseAttributeItemModel>? Attributes { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }
    public BaseMediaLinkModel? CreatedBy { get; set; }

    //category 
    public BaseMediaLinkModel? Group { get; set; }

    public BaseProductItemModel() { }
    public BaseProductItemModel(ProductItemResponse productItem)
    {
        if (productItem == null) return;
        Id = productItem.Id;
        Title = productItem.Name;
        Sku = productItem.Sku;

        Price = productItem.Price;
        DisplayPrice = !productItem.PriceHidden;
        DisplayContact = productItem.PriceHidden;

        Sale = productItem.Sale;
        DisplaySale = !productItem.SaleHidden;

        Href = string.Format(RouteConst.GetRoute(RouteConst.ProductDetail), productItem.PageKeyName);
        Media = productItem.Image?.Path;

        CreatedAt = productItem.CreatedAt;
        if (productItem.ProductCategoryModel != null)
        {
            Group = new BaseMediaLinkModel(productItem.ProductCategoryModel.Label, string.Format(RouteConst.GetRoute(RouteConst.CategoryOfProductDetail), productItem.ProductCategoryModel.Key));
        }

        if (productItem.CreatedBy.HasValueGuid() == true)
        {
            CreatedBy = new BaseMediaLinkModel($"{productItem.CreatedByModel?.Label}", string.Format(RouteConst.GetRoute(RouteConst.AuthorDetail), productItem.CreatedByModel?.Key));
        }
     
        if (productItem?.AttributeModel?.Properties != null)
        {
            Attributes = productItem.AttributeModel?.PropertiesModel?.Select(x => new BaseAttributeItemModel
            {
                Key = x.Key,
                Label = x.Value?.PropertiesModelKey?.Label,//get label from key
                Title = x.Value?.PropertiesModelKey?.ValueModel?.Any() != true ? "" : string.Join(",", x.Value?.PropertiesModelKey?.ValueModel?.Select(x => $"{x?.Label}")),
                Featured = x.Value?.Featured ?? false
            }).ToList();

        }
    }
}
