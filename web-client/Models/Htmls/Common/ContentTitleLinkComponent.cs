using web_client.Models.Base;

namespace web_client.Models.Htmls.Common;

public class ContentTitleLinkComponent : BaseTitleModel
{
    public string Description { get; set; }
    public BaseLinkModel? Link { get; set; }
    public ContentTitleLinkComponent()
    {
    }
    public ContentTitleLinkComponent(string title, string description, BaseLinkModel? link = null)
    {
        Title = title;
        Description = description;
        Link = link;
    }
}

