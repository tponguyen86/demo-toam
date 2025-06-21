namespace web_client.Models.Base;

public class BaseLinkModel : BaseTitleModel
{
    public string? Href { get; set; }
    public BaseLinkModel()
    {
    }
    public BaseLinkModel(string title, string href)
    {
        Title = title;
        Href = href;
    }
}
