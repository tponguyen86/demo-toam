using web_client.Models.Base;
using web_client.Models.Responses.Categories.Products;

namespace web_client.Application.IServices;

public interface IProductCategoryAppService
{
    Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetAllAsync(CancellationToken cancellationToken);
    Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetByShowHomeAsync(CancellationToken cancellationToken);
    Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetByShowMenuAsync(CancellationToken cancellationToken);
    Task<BaseProcess<ProductCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
}
