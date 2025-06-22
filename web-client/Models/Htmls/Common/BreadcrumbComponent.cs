using web_client.Models.Htmls.Base;

namespace web_client.Models.Htmls.Common;

public class BreadcrumbComponent : CategoryTitleLinksComponent
{
    public string? Description { get; set; }
    public string? Media { get; set; }
    public BreadcrumbComponent() : base() { }

    public BreadcrumbComponent(string title, List<BaseCategoryItemModel> links) : base(title, links) { }
}
