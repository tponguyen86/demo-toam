using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Request.Categories.Products;
using web_client.Models.Responses.Categories.Products;

namespace web_client.Application.Services;

public class ProductCategoryAppService : IProductCategoryAppService
{
    private readonly IProductCategoryService _service;

    public ProductCategoryAppService(IProductCategoryService service)
    {
        _service = service;
    }

    public async Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetByShowHomeAsync(CancellationToken cancellationToken)
    {
        var request = new FilterProductCategoryRequest();
        request.PageSize = 50;
        request.ShowHome = true;
        var result = await _service.GetPagingAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ProductCategoryItemResponse>>(result?.Data?.Items, result?.Errors);
    }

    public Task<BaseProcess<ProductCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
   => _service.GetDetailAsync(request, cancellationToken);
}
