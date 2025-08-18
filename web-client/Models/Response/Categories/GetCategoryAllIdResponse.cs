using web_client.Helpers;
using web_client.Models.Base;
using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Response.Categories;

public class GetCategoryAllIdResponse
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
    public ProductCategorySelectModel? ParentIdModel { get; set; }
    public CategoryChildrenSelectModel? ChildModel { get; set; }

    public GetCategoryAllIdResponse() { }
    public GetCategoryAllIdResponse(Category category)
    {
        Id = category.Id;

        ParentId = category.ParentId;
        if (category.ParentId?.HasValueGuid() == true)
            ParentIdModel = new ProductCategorySelectModel(category.ParentId.Value);

        ChildModel = new CategoryChildrenSelectModel(category.Id);
    }
}