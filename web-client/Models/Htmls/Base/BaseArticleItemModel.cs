using web_client.Models.Base;

namespace web_client.Models.Htmls.Base;

public class BaseArticleItemModel : BaseMediaLinkModel
{
    public Guid Id { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public BaseMediaLinkModel? CreatedBy { get; set; }
    public string ShortDescription { get; set; }

    //category
    public BaseMediaLinkModel? Group { get; set; }

    public BaseArticleItemModel() : base()
    {
    }
    public BaseArticleItemModel(string title, string href) : base(title, href)
    {
    }
    public BaseArticleItemModel(string title, string href, string media) : base(title, href, media)
    {
    }
    public BaseArticleItemModel(Guid id, string title, string href, string media, DateTimeOffset? createdAt, BaseMediaLinkModel? createdBy = null) : base(title, href, media)
    {
        Id = id;
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }
}
