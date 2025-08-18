using web_client.Models.Base;
using web_client.Models.Request.Categories.Details;
using web_client.Models.Request.Products;
using web_client.Models.Response.Products;

namespace web_client.Application.IServices;

public interface IProductAppService
{
    Task<BaseProcess<IEnumerable<ProductItemResponse>>> GetFeatureAsync(int? take, CancellationToken cancellationToken);
    Task<BaseProcess<BasePagingModel<ProductItemResponse>>> GetPagingAsync(ProductPagingRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<ProductDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
    Task<BaseProcess<List<ProductItemResponse>>> GetRelativeAsync(GetCategoryDetailRelativeRequest request, CancellationToken cancellationToken);
}