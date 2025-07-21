using web_client.Models.Base;
using web_client.Models.Responses.Categories.Products;

namespace web_client.Application.IServices;

public interface IProductCategoryAppService
{
    Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetByShowHomeAsync(CancellationToken cancellationToken);
    //Task<BaseProcess<BasePagingModel<ProductCategoryItemResponse>>> GetPagingAsync(FilterProductCategoryRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<ProductCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
}
