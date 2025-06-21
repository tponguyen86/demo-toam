using web_client.Models.Base;

namespace web_client.Models.Htmls.Common;

public class SideBarCategoryComponent : BaseTitleLinksComponent<BaseLinkModel>
{
    public SideBarCategoryComponent() : base()
    {
    }
    public SideBarCategoryComponent(string title, List<BaseLinkModel> links) : base(title, links)
    {
    }
}

