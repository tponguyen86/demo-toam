using web_client.Models.Base;
using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Response.Products;

public class ProductDetailResponse : ProductItemResponse
{
    public List<BaseFileModel>? Medias { get; set; }

    public string? Description { get; set; }
    public string? Technical { get; set; }
    public string? Datasheet { get; set; }

    public ProductDetailResponse() { }
    public ProductDetailResponse(Product product) : base(product)
    {
        if (product == null) return;
        Medias = product.Medias;
        Description = product.Description;
        Technical = product.Technical;
        Datasheet = product.Datasheet;
    }
}
