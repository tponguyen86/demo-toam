using web_client.Models.Base;

namespace web_client.Models.Htmls.Common;

public class BaseTitleLinksComponent<TLink> : BaseTitleModel
{
    public List<TLink>? Links { get; set; }
    public BaseTitleLinksComponent()
    {
    }
    public BaseTitleLinksComponent(string title, List<TLink> links)
    {
        Title = title;
        Links = links;
    }
}