using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Request.News;
using web_client.Models.Response.News;

namespace web_client.Application.Services;

public class NewsAppService : INewsAppService
{
    private readonly INewsService _service;

    public NewsAppService(INewsService service)
    {
        _service = service;
    }

    public Task<BaseProcess<NewsDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    => _service.GetDetailAsync(request, cancellationToken);

    public async Task<BaseProcess<IEnumerable<NewsItemResponse>>> GetFeatureAsync(int? take, CancellationToken cancellationToken = default)
    {
        var request = new NewsPagingRequest();
        request.Category = PredefineDataConst.CategoryParentId.Key.News.GetGuid();
        request.PageSize = take ?? 5;
        request.Featured = true;
        var result = await _service.GetPagingAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<NewsItemResponse>>(result?.Data?.Items, result?.Errors);
    }

    public Task<BaseProcess<BasePagingModel<NewsItemResponse>>> GetPagingAsync(NewsPagingRequest request, CancellationToken cancellationToken)
    => _service.GetPagingAsync(request, cancellationToken);

    public Task<BaseProcess<List<NewsItemResponse>>> GetRelativeAsync(Guid serviceId, CancellationToken cancellationToken)
   => _service.GetRelativeAsync(serviceId, cancellationToken);
}
