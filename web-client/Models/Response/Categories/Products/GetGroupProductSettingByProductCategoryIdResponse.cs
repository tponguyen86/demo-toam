
namespace web_client.Models.Responses.Categories.Products;
public class GetGroupProductSettingByProductCategoryIdResponse
{
    public Guid InputCategoryId { get; set; }
    public Guid OutputCategoryId { get; set; }
    public Guid OutputGroupProductSettingId { get; set; }
}
