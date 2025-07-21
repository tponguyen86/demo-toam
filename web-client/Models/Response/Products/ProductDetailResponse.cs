using web_client.Models.Base;
using web_client.Models.Base.Properties;
using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Response.Products;

public class ProductDetailResponse : ProductItemResponse
{
    public List<BaseFileModel>? Medias { get; set; }

    public string? Description { get; set; }

    public ProductDetailResponse() { }
    public ProductDetailResponse(Product product) : base(product)
    {
        Description = product.Description;
        Medias = product.Medias;

    }
}
