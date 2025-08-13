using web_client.Models.Htmls.Base;

namespace web_client.Models.Htmls.Common;

public class CategoryTitleLinksDetailComponent : CategoryTitleLinksComponent
{
    public string? Description { get; set; }

    public CategoryTitleLinksDetailComponent(string title, List<BaseCategoryItemModel> links) : base(title, links)
    {
    }
    public CategoryTitleLinksDetailComponent(string title, List<BaseCategoryItemModel> links, string description) : base(title, links)
    {
        Description = description;
    }
}

