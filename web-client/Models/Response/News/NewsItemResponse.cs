using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Responses.Categories;

namespace web_client.Models.Response.News;

public class NewsItemResponse : CategoryChildrenResponse
{
    //public List<BaseSelectModel>? Projects { get; set; }
    //[JsonIgnore]
    //public List<Guid>? ProjectKeys { get; set; }
    //public List<BaseSelectModel>? Projects { get; set; }

    public NewsItemResponse():base() { }
    public NewsItemResponse(CategoryDetail categoryDetail) : base(categoryDetail)
    {
    }
}