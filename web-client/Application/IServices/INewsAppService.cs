using web_client.Models.Base;
using web_client.Models.Request.News;
using web_client.Models.Response.News;
using web_client.Models.Response.Services;

namespace web_client.Application.IServices;

public interface INewsAppService
{
    Task<BaseProcess<IEnumerable<NewsItemResponse>>> GetFeatureAsync(int? take, CancellationToken cancellationToken);
    Task<BaseProcess<BasePagingModel<NewsItemResponse>>> GetPagingAsync(NewsPagingRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<NewsDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
    Task<BaseProcess<List<NewsItemResponse>>> GetRelativeAsync(Guid serviceId, CancellationToken cancellationToken);
}