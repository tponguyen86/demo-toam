namespace web_client.Models.Base;

public class BaseMediaLinkModel : BaseLinkModel
{
    public string? Media { get; set; }
    public BaseMediaLinkModel() : base()
    {
    }
    public BaseMediaLinkModel(string title, string href) : base(title, href)
    {
    }
    public BaseMediaLinkModel(string title, string href, string media) : base(title, href)
    {
        Media = media;
    }
}
