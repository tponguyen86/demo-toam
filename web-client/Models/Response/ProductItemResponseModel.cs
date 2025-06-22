using web_client.Models.Base;

namespace web_client.Models.Response;

public class ProductItemResponseModel : BaseMediaLinkModel
{
    public DateTimeOffset? CreatedAt { get; set; }
    public string? Author { get; set; }
    public ProductItemResponseModel() : base()
    {
    }
    public ProductItemResponseModel(string title, string href) : base(title, href)
    {
    }
    public ProductItemResponseModel(string title, string href, string media) : base(title, href, media)
    {
    }
    public ProductItemResponseModel(string title, string href, string media, DateTimeOffset? createdAt, string? author = "") : base(title, href, media)
    {
        CreatedAt = createdAt;
        Author = author;
    }
}
