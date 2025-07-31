using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Response.Services;

public class ServiceDetailResponse : ServiceItemResponse
{
    public string Content { get; set; } = default!;
    public ServiceDetailResponse() : base()
    {
    }
    public ServiceDetailResponse(CategoryDetail categoryDetail) : base(categoryDetail)
    {
        if (categoryDetail is not null)
        {
            Content = categoryDetail.Content ?? string.Empty;
        }
    }
}