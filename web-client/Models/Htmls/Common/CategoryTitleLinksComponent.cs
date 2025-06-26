using web_client.Models.Base;
using web_client.Models.Htmls.Base;

namespace web_client.Models.Htmls.Common;

public class CategoryTitleLinksComponent : TitleLinksComponent<BaseCategoryItemModel>
{
    public BaseLinkModel? Link { get; set; }
    public CategoryTitleLinksComponent() : base()
    {
    }
    public CategoryTitleLinksComponent(string title, List<BaseCategoryItemModel> links) : base(title, links)
    {
    }
}

