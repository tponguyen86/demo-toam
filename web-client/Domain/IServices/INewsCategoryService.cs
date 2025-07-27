using web_client.Models.Base;
using web_client.Models.Request.Categories.News;
using web_client.Models.Responses.Categories.News;

namespace web_client.Domain.IServices;

public interface INewsCategoryService
{
    Task<BaseProcess<List<NewsCategoryItemResponse>>> GetAllAsync(GetNewsCategoryAllRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<NewsCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
}