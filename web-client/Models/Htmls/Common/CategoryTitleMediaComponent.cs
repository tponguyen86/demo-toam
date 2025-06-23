using web_client.Models.Base;

namespace web_client.Models.Htmls.Common;

public class CategoryTitleMediaComponent : BaseMediaLinkModel
{
    public Guid Id { get; set; }
    //parent category
    public BaseMediaLinkModel? Group { get; set; }

    public CategoryTitleMediaComponent() { }
}
