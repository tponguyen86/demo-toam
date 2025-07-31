using web_client.Models.Base;
using web_client.Models.Request.Services;
using web_client.Models.Response.Services;

namespace web_client.Domain.IServices;

public interface IServiceService
{
    Task<BaseProcess<BasePagingModel<ServiceItemResponse>>> GetPagingAsync(ServicePagingRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<ServiceDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
}