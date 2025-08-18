using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Request.Categories;
using web_client.Models.Request.Categories.Details;
using web_client.Models.Request.Products;
using web_client.Models.Response.Products;
using static web_client.Helpers.Shared.PredefineDataConst;

namespace web_client.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IProductService _service;
    private readonly ICategoryService _categoryServices;
    public ProductAppService(IProductService service, ICategoryService categoryServices)
    {
        _service = service;
        _categoryServices = categoryServices;
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

    //    public Task<BaseProcess<List<ProductItemResponse>>> GetRelativeAsync(GetCategoryDetailRelativeRequest request, CancellationToken cancellationToken)
    //=> _service.GetRelativeAsync(request, cancellationToken);

    public async Task<BaseProcess<List<ProductItemResponse>>> GetRelativeAsync(GetCategoryDetailRelativeRequest request, CancellationToken cancellationToken)
    {
        var categoryDetailRequest = new GetCategoryAllIdRequest();
        categoryDetailRequest.SetDiscriminator(CategoryDiscriminator.Key.ProductCategory);
        var getCategoryDetail = await _categoryServices.GetAllIdAsync(categoryDetailRequest, cancellationToken);
        if (getCategoryDetail?.Data != null)
        {
            var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
            if (categoryIds?.Any() == true)
                request.SetCategory(categoryIds);
        }

        var result = await _service.GetRelativeAsync(request, cancellationToken);
        return new BaseProcess<List<ProductItemResponse>>(result?.Data, result?.Errors);
    }
}
