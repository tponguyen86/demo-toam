using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Responses.Categories.News;

public class NewsCategoryDetailResponse : NewsCategoryItemResponse
{
    public NewsCategoryDetailResponse() { }
    public NewsCategoryDetailResponse(Category category) : base(category)
    {
    }
}
