using web_client.Models.Base;
using web_client.Models.Request.Categories.Details;
using web_client.Models.Request.Services;
using web_client.Models.Response.Services;

namespace web_client.Application.IServices;

public interface IServiceAppService
{
    Task<BaseProcess<IEnumerable<ServiceItemResponse>>> GetFeatureAsync(int? take, CancellationToken cancellationToken);
    Task<BaseProcess<IEnumerable<ServiceItemResponse>>> GetAllAsync(CancellationToken cancellationToken);
    Task<BaseProcess<BasePagingModel<ServiceItemResponse>>> GetPagingAsync(ServicePagingRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<ServiceDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
    Task<BaseProcess<List<ServiceItemResponse>>> GetRelativeAsync(GetCategoryDetailRelativeRequest request, CancellationToken cancellationToken);
}