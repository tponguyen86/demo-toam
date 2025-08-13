using web_client.Models.Base;
using web_client.Models.Request.Products;
using web_client.Models.Response.Products;

namespace web_client.Domain.IServices;

public interface IProductService
{
    Task<BaseProcess<BasePagingModel<ProductItemResponse>>> GetPagingAsync(ProductPagingRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<ProductDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
    Task<BaseProcess<List<ProductItemResponse>>> GetRelativeAsync(Guid productId, CancellationToken cancellationToken);
}