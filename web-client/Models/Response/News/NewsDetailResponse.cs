using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Response.News;

public class NewsDetailResponse : NewsItemResponse
{
    public string Content { get; set; } = default!;
    public NewsDetailResponse() : base()
    {
    }
    public NewsDetailResponse(CategoryDetail categoryDetail) : base(categoryDetail)
    {
        if (categoryDetail is not null)
        {
            Content = categoryDetail.Content ?? string.Empty;
        }
    }
}