using web_client.Models.Base;
using web_client.Models.Request.Categories.Products;
using web_client.Models.Responses.Categories.Products;

namespace web_client.Domain.IServices;

public interface IProductCategoryService
{
    Task<BaseProcess<List<ProductCategoryItemResponse>>> GetAllAsync(GetProductCategoryAllRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<ProductCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
}