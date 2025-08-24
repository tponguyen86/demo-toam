using System.Linq;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Htmls.Base;
using web_client.Models.Response.Products;

namespace web_client.Models.Htmls.Common;

public class ProductTitleMediaComponent : BaseProductItemModel
{
    public string ShortDescription { get; set; }
    public ProductTitleMediaComponent()
    {
    }
    public ProductTitleMediaComponent(ProductItemResponse productItem)
    {
        ToViewModel(productItem);
    }
    public void ToViewModel(ProductItemResponse productItem)
    {
        if (productItem == null) return;
        Id = productItem.Id;
        Title = productItem.Name;

        Sku = productItem.Sku;
        Price = productItem.Price;
        DisplayPrice = !productItem.PriceHidden;
        DisplayContact = productItem.PriceHidden;
        ShortDescription = productItem.ShortDescription;

        Sale = productItem.Sale;
        DisplaySale = !productItem.SaleHidden;

        Href = string.Format(RouteConst.GetRoute(RouteConst.ProductDetail), productItem.PageKeyName);
        CreatedAt = productItem.CreatedAt;

        if (productItem.ProductCategoryModel != null)
        {
            Group = new BaseMediaLinkModel($"{productItem.ProductCategoryModel?.Label}", $"{productItem.ProductCategoryModel?.Key}");
        }

        Media = productItem?.Image?.Path;

        if (productItem?.AttributeModel?.Properties != null)
        {
            Attributes = productItem.AttributeModel?.PropertiesModel?.Select(x => new BaseAttributeItemModel
            {
                Key = x.Key,
                Label = x.Value?.PropertiesModelKey?.Label,//get label from key
                Title = x.Value?.PropertiesModelKey?.ValueModel?.Any() != true ? "" : string.Join(",", x.Value?.PropertiesModelKey?.ValueModel?.Select(x => $"{x?.Label}"))
            }).ToList();

        }

    }
}
