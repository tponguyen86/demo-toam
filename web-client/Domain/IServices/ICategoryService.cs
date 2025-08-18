using web_client.Models.Base;
using web_client.Models.Request.Categories;
using web_client.Models.Response.Categories;

namespace web_client.Domain.IServices;

public interface ICategoryService
{
    Task<BaseProcess<GetCategoryAllIdResponse>> GetAllIdAsync(GetCategoryAllIdRequest request, CancellationToken cancellationToken);
}