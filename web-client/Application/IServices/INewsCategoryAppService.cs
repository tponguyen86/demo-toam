using web_client.Models.Base;
using web_client.Models.Responses.Categories.News;
using web_client.Models.Responses.Categories.Products;

namespace web_client.Application.IServices;

public interface INewsCategoryAppService
{
    Task<BaseProcess<IEnumerable<NewsCategoryItemResponse>>> GetAllAsync(CancellationToken cancellationToken);
    Task<BaseProcess<IEnumerable<NewsCategoryItemResponse>>> GetByShowHomeAsync(CancellationToken cancellationToken);
    Task<BaseProcess<IEnumerable<NewsCategoryItemResponse>>> GetByShowMenuAsync(CancellationToken cancellationToken);

    Task<BaseProcess<NewsCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
}
