namespace web_client.Models.Response.Categories;

public class BaseGroupSettingByCategoryIdResponse
{
    public Guid InputCategoryId { get; set; }
    public Guid OutputCategoryId { get; set; }
    public Guid OutputGroupSettingId { get; set; }
}
