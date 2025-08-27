namespace web_client.Models.Base;

public class BaseLinkModel : BaseTitleModel
{
    public string? Href { get; set; }
    public string? Target { get; set; }= "_self";
    public BaseLinkModel()
    {
    }
    public BaseLinkModel(string title, string? href="#")
    {
        Title = title;
        Href = href;
    }
}
