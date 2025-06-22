using web_client.Models.Htmls.Base;

namespace web_client.Models.Htmls.Common;

public class CategoryTitleLinksComponent : BaseTitleLinksComponent<BaseCategoryItemModel>
{
    public CategoryTitleLinksComponent() : base()
    {
    }
    public CategoryTitleLinksComponent(string title, List<BaseCategoryItemModel> links) : base(title, links)
    {
    }
}

