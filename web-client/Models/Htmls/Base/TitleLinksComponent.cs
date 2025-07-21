using web_client.Models.Base;

namespace web_client.Models.Htmls.Common;

public class TitleLinksComponent<TLink> : BaseTitleModel
{
    public List<TLink>? Links { get; set; }
    public TitleLinksComponent()
    {
    }
    public TitleLinksComponent(string title, List<TLink> links)
    {
        Title = title;
        Links = links;
    }
}

public class TitleLinksComponent : TitleLinksComponent<BaseLinkModel>
{
    public new List<BaseLinkModel>? Links { get; set; }
    public TitleLinksComponent():base()
    {
    }
    public TitleLinksComponent(string title, List<BaseLinkModel> links):base(title,links)
    {
    }
}