using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Responses.Categories.Products;

public class ProductCategoryDetailResponse : ProductCategoryItemResponse
{
    public ProductCategoryDetailResponse() { }
    public ProductCategoryDetailResponse(ProductCategory category) : base(category)
    {
    }
}
