using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Models.Base;
using web_client.Models.Request.Categories;
using web_client.Models.Request.Categories.Services;
using web_client.Models.Response.Categories.Services;
using static web_client.Helpers.Shared.PredefineDataConst;

namespace web_client.Application.Services;

public class ServiceCategoryAppService : IServiceCategoryAppService
{
    private readonly IServiceCategoryService _service;

    public ServiceCategoryAppService(IServiceCategoryService service)
    {
        _service = service;
    }

    public async Task<BaseProcess<IEnumerable<ServiceCategoryItemResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var request = new GetServiceCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.Category);
        request.SetParentId(CategoryParentId.Key.Service.GetGuid());
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ServiceCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<IEnumerable<ServiceCategoryItemResponse>>> GetByShowHomeAsync(CancellationToken cancellationToken)
    {
        var request = new GetServiceCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.Category);
        request.SetParentId(CategoryParentId.Key.Service.GetGuid());
        request.ShowHome = true;
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ServiceCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<IEnumerable<ServiceCategoryItemResponse>>> GetByShowMenuAsync(CancellationToken cancellationToken)
    {
        var request = new GetServiceCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.Category);
        request.ParentId = CategoryParentId.Key.Service.GetGuid();
        request.ShowMenu = true;
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ServiceCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<ServiceCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request)
    {
        var requestCategory = new CategoryDetailRequestDto(request);
        requestCategory.SetDiscriminator(CategoryDiscriminator.Key.Category);
        requestCategory.SetParentId(CategoryParentId.Key.Service.GetGuid());
        var result = await _service.GetDetailAsync(requestCategory, CancellationToken.None);
        return new BaseProcess<ServiceCategoryDetailResponse>(result.Data, result?.Errors);
    }
}
