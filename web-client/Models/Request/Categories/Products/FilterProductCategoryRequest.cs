using web_client.Models.Base;

namespace web_client.Models.Request.Categories.Products;

public class FilterProductCategoryRequest : BaseSearchRequest
{
    public Guid? ParentId { get; set; }
    public bool ParentIdHasValue() => ParentId.HasValue && ParentId != Guid.Empty;

    public bool? ShowHome { get; set; }
    public bool ShowHomeHasValue() => ShowHome.HasValue;
}
