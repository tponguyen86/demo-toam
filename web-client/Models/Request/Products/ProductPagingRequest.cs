using web_client.Models.Base;

namespace web_client.Models.Request.Products;
public class ProductPagingRequest : BaseSearchRequest
{
    public Guid? Category { get; set; }
    public bool CategoryHasValue() => Category.HasValue && Category != Guid.Empty;

    public bool? Featured { get; set; }
    public bool FeaturedHasValue() => Featured.HasValue;
}
