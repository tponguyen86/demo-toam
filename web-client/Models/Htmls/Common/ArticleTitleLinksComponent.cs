using web_client.Models.Htmls.Base;

namespace web_client.Models.Htmls.Common;

public class ArticleTitleLinksComponent : TitleLinksComponent<BaseArticleItemModel>
{
    public ArticleTitleLinksComponent() : base()
    {
    }
    public ArticleTitleLinksComponent(string title, List<BaseArticleItemModel> links) : base(title, links)
    {
    }
}

