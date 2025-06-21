using web_client.Models.Base;

namespace web_client.Models.Htmls.Common;

public class BreadcrumbComponent : SideBarCategoryComponent
{
    public string? Description { get; set; }
    public string? Media { get; set; }
    public BreadcrumbComponent() : base() { }

    public BreadcrumbComponent(string title, List<BaseLinkModel> links) : base(title, links) { }
}
