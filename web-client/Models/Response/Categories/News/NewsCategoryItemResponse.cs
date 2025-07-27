using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Response.Categories;

namespace web_client.Models.Responses.Categories.News;

public class NewsCategoryItemResponse : BaseCategoryResponse
{
    public NewsCategoryItemResponse() { }
    public NewsCategoryItemResponse(Category category) : base(category)
    {
    }
}