using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Request.Categories;
using web_client.Models.Request.Categories.Products;
using web_client.Models.Responses.Categories.Products;
using static web_client.Helpers.Shared.PredefineDataConst;

namespace web_client.Application.Services;

public class ProductCategoryAppService : IProductCategoryAppService
{
    private readonly IProductCategoryService _service;

    public ProductCategoryAppService(IProductCategoryService service)
    {
        _service = service;
    }

    public async Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetAllAsync()
    {
        var request = new GetProductCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.ProductCategory);
        var result = await _service.GetAllAsync(request, CancellationToken.None);
        return new BaseProcess<IEnumerable<ProductCategoryItemResponse>>(result.Data, result?.Errors);
    }
    public async Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetAllTopLevelAsync()
    {
        var request = new GetProductCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.ProductCategory);
        request.SetTopLevel();
        var result = await _service.GetAllAsync(request, CancellationToken.None);
        return new BaseProcess<IEnumerable<ProductCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetAllTopLevelShowHomeAsync()
    {
        var request = new GetProductCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.ProductCategory);
        request.SetTopLevel();
        request.ShowHome = true;
        var result = await _service.GetAllAsync(request, CancellationToken.None);
        return new BaseProcess<IEnumerable<ProductCategoryItemResponse>>(result.Data, result?.Errors);
    }


    public async Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetByShowHomeAsync()
    {
        var request = new GetProductCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.ProductCategory);
        request.ShowHome = true;
        var result = await _service.GetAllAsync(request, CancellationToken.None);
        return new BaseProcess<IEnumerable<ProductCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetByShowMenuAsync()
    {
        var request = new GetProductCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.ProductCategory);
        request.ShowMenu = true;
        var result = await _service.GetAllAsync(request, CancellationToken.None);
        return new BaseProcess<IEnumerable<ProductCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<ProductCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request)
    {
        var requestCategory = new CategoryDetailRequestDto(request);
        requestCategory.SetDiscriminator(CategoryDiscriminator.Key.ProductCategory);
        var result = await _service.GetDetailAsync(requestCategory, CancellationToken.None);
        return new BaseProcess<ProductCategoryDetailResponse>(result.Data, result?.Errors);
    }
}
