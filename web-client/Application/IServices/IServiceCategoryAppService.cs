using web_client.Models.Base;
using web_client.Models.Responses.Categories.Services;

namespace web_client.Application.IServices;

public interface IServiceCategoryAppService
{
    Task<BaseProcess<IEnumerable<ServiceCategoryItemResponse>>> GetAllAsync(CancellationToken cancellationToken);
    Task<BaseProcess<IEnumerable<ServiceCategoryItemResponse>>> GetByShowHomeAsync(CancellationToken cancellationToken);
    Task<BaseProcess<IEnumerable<ServiceCategoryItemResponse>>> GetByShowMenuAsync(CancellationToken cancellationToken);
    Task<BaseProcess<ServiceCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
}
