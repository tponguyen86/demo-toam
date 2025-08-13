using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Request.Products;
using web_client.Models.Response.Products;

namespace web_client.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IProductService _service;

    public ProductAppService(IProductService service)
    {
        _service = service;
    }

    public Task<BaseProcess<ProductDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    => _service.GetDetailAsync(request, cancellationToken);

    public async Task<BaseProcess<IEnumerable<ProductItemResponse>>> GetFeatureAsync(int? take, CancellationToken cancellationToken = default)
    {
        var request = new ProductPagingRequest();
        request.PageSize = take ?? 5;
        request.Featured = true;
        var result = await _service.GetPagingAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ProductItemResponse>>(result?.Data?.Items, result?.Errors);
    }

    public Task<BaseProcess<BasePagingModel<ProductItemResponse>>> GetPagingAsync(ProductPagingRequest request, CancellationToken cancellationToken)
    => _service.GetPagingAsync(request, cancellationToken);

    public Task<BaseProcess<List<ProductItemResponse>>> GetRelativeAsync(Guid productId, CancellationToken cancellationToken)
=> _service.GetRelativeAsync(productId, cancellationToken);
}
