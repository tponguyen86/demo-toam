using web_client.Models.Base;
using web_client.Models.Request.Categories;
using web_client.Models.Response.Categories;
using web_client.Models.Response.Categories.Products;
using web_client.Models.Responses.Categories;

namespace web_client.Domain.IServices;

public interface ICategoryService
{
    Task<BaseProcess<List<CategoryItemResponse>>> GetAllAsync(BaseGetCategoryAllRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<GetCategoryAllIdResponse>> GetAllIdAsync(GetCategoryAllIdRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<GetGroupProductSettingByProductCategoryIdResponse>> GetGroupProductSettingByProductCategoryId(Guid categoryId, CancellationToken cancellationToken);
}