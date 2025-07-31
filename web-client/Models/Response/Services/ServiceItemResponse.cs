using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Responses.Categories;

namespace web_client.Models.Response.Services;

public class ServiceItemResponse : CategoryChildrenResponse
{
    //public List<BaseSelectModel>? Projects { get; set; }
    //[JsonIgnore]
    //public List<Guid>? ProjectKeys { get; set; }
    //public List<BaseSelectModel>? Projects { get; set; }
    //[JsonIgnore]
    //public List<Guid>? ProductKeys { get; set; }
    //public List<ProductSelectModel>? Products { get; set; }

    public ServiceItemResponse():base() { }
    public ServiceItemResponse(CategoryDetail categoryDetail) : base(categoryDetail)
    {
    }
}