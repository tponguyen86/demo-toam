using web_client.Models.Base;

namespace web_client.Models.Htmls.Base;

public class BaseCategoryItemModel : BaseMediaLinkModel
{
    public Guid Id { get; set; }
    public List<BaseCategoryItemModel> Children { get; set; }
    public BaseCategoryItemModel() : base() { }
    public BaseCategoryItemModel(string title, string href) : base(title, href) { }
    public BaseCategoryItemModel(Guid id, string title, string href) : base(title, href) { Id = id; }
    public BaseCategoryItemModel(Guid id, string title, string href, List<BaseCategoryItemModel> children) : this(id, title, href) { Children = children; }
}
