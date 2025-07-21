using web_client.Models.Base;

namespace ToamManage.Infrastructure.Dto.Requests.Categories;

public class FilterCategoryRequest : BaseSearchRequest
{
    public Guid ParentId { get; set; }
}
