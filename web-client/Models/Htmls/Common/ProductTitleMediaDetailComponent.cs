using web_client.Models.Base;
using web_client.Models.Response.Products;

namespace web_client.Models.Htmls.Common;

public class ProductTitleMediaDetailComponent : ProductTitleMediaComponent
{
    public List<BaseFileModel>? Medias { get; set; }

    public string? Description { get; set; }
    public string? Technical { get; set; }
    public string? Datasheet { get; set; }

    public ProductTitleMediaDetailComponent()
    {
    }
    public ProductTitleMediaDetailComponent(ProductDetailResponse productItem) : base(productItem)
    {
        if (productItem == null) return;
        ToViewModel(productItem);
        Description = productItem.Description ?? string.Empty;
        Medias = productItem.Medias;
        Technical = productItem.Technical ?? string.Empty;
        Datasheet = productItem.Datasheet ?? string.Empty;
    }
}
