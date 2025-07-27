using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Response.Categories;

namespace web_client.Models.Responses.Categories;
public class CategoryItemResponse : BaseCategoryResponse
{
    public CategoryItemResponse():base() { }
    public CategoryItemResponse(Category category) : base(category)
    {
    }
}
