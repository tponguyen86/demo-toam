using web_client.Models.Base;
using web_client.Models.Htmls.Base;

namespace web_client.Models.Htmls.Common;

public class ProductTitleLinksComponent : TitleLinksComponent<BaseProductItemModel>
{
    public BaseLinkModel? Link { get; set; }
    public ProductTitleLinksComponent() : base()
    {
    }
    public ProductTitleLinksComponent(string title, List<BaseProductItemModel> links) : base(title, links)
    {
    }
}

