namespace web_client.Models.Base;

public class BaseMediaLinkContentModel : BaseMediaLinkModel
{
    public DateTimeOffset? CreatedAt { get; set; }
    public string? Author { get; set; }
    public BaseMediaLinkContentModel() : base()
    {
    }
    public BaseMediaLinkContentModel(string title, string href) : base(title, href)
    {
    }
    public BaseMediaLinkContentModel(string title, string href, string media) : base(title, href, media)
    {
    }
    public BaseMediaLinkContentModel(string title, string href, string media, DateTimeOffset? createdAt, string? author = "") : base(title, href, media)
    {
        CreatedAt = createdAt;
        Author = author;
    }
}
