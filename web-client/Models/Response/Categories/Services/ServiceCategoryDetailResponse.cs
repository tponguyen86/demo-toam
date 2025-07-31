using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Response.Categories.Services;

public class ServiceCategoryDetailResponse : ServiceCategoryItemResponse
{
    public ServiceCategoryDetailResponse() { }
    public ServiceCategoryDetailResponse(Category category) : base(category)
    {
    }
}
