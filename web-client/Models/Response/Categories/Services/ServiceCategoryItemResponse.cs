using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Response.Categories.Services;

public class ServiceCategoryItemResponse : BaseCategoryResponse
{
    public ServiceCategoryItemResponse() { }
    public ServiceCategoryItemResponse(Category category) : base(category)
    {
    }
}