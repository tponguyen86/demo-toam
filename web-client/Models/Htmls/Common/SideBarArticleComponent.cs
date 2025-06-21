using web_client.Models.Base;

namespace web_client.Models.Htmls.Common;

public class SideBarArticleComponent : BaseTitleLinksComponent<BaseMediaLinkContentModel>
{
    public SideBarArticleComponent() : base()
    {
    }
    public SideBarArticleComponent(string title, List<BaseMediaLinkContentModel> links) : base(title, links)
    {
    }
}

