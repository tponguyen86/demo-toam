using web_client.Models.Base;
using web_client.Models.Responses.Categories.Products;

namespace web_client.Application.IServices;

public interface IProductCategoryAppService
{
    Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetAllAsync();
    Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetByShowHomeAsync();
    Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetByShowMenuAsync();
    Task<BaseProcess<ProductCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request);
}
