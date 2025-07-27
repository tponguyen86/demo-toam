using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Response.Categories;

namespace web_client.Models.Responses.Categories.Services;

public class ServiceCategoryItemResponse : BaseCategoryResponse
{
    public ServiceCategoryItemResponse() { }
    public ServiceCategoryItemResponse(Category category) : base(category)
    {
    }
}