using web_client.Models.Base;
using web_client.Models.Request.Categories.Services;
using web_client.Models.Response.Categories.Services;

namespace web_client.Domain.IServices;

public interface IServiceCategoryService
{
    Task<BaseProcess<List<ServiceCategoryItemResponse>>> GetAllAsync(GetServiceCategoryAllRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<ServiceCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
}