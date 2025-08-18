using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Request.Categories;
using web_client.Models.Request.Categories.Details;
using web_client.Models.Request.Services;
using web_client.Models.Response.News;
using web_client.Models.Response.Services;

namespace web_client.Application.Services;

public class ServiceAppService : IServiceAppService
{
    private readonly IServiceService _service;
    private readonly ICategoryService _categoryServices;
    public ServiceAppService(IServiceService service, ICategoryService categoryServices)
    {
        _service = service;
        _categoryServices = categoryServices;
    }

    public Task<BaseProcess<ServiceDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    => _service.GetDetailAsync(request, cancellationToken);

    public async Task<BaseProcess<IEnumerable<ServiceItemResponse>>> GetFeatureAsync(int? take, CancellationToken cancellationToken = default)
    {
        var request = new ServicePagingRequest();
        var categoryDetailRequest = new GetCategoryAllIdRequest(PredefineDataConst.CategoryParentId.Key.Service.GetGuid());
        var getCategoryDetail = await _categoryServices.GetAllIdAsync(categoryDetailRequest,cancellationToken);
        if (getCategoryDetail?.Data != null)
        {
            var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
            if (categoryIds?.Any() == true)
                request.SetCategory(categoryIds);
        }
        //request.AddCategory(PredefineDataConst.CategoryParentId.Key.Service.GetGuid());
        request.PageSize = take ?? 5;
        request.Featured = true;
        var result = await _service.GetPagingAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ServiceItemResponse>>(result?.Data?.Items, result?.Errors);
    }
    public async Task<BaseProcess<IEnumerable<ServiceItemResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var request = new ServicePagingRequest();
        request.AddCategory(PredefineDataConst.CategoryParentId.Key.Service.GetGuid());
        request.PageSize = 30;
        var result = await _service.GetPagingAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ServiceItemResponse>>(result?.Data?.Items, result?.Errors);
    }

    public Task<BaseProcess<BasePagingModel<ServiceItemResponse>>> GetPagingAsync(ServicePagingRequest request, CancellationToken cancellationToken)
    => _service.GetPagingAsync(request, cancellationToken);

    public async Task<BaseProcess<List<ServiceItemResponse>>> GetRelativeAsync(GetCategoryDetailRelativeRequest request, CancellationToken cancellationToken)
    {
        var categoryDetailRequest = new GetCategoryAllIdRequest(PredefineDataConst.CategoryParentId.Key.Service.GetGuid());
        var getCategoryDetail = await _categoryServices.GetAllIdAsync(categoryDetailRequest, cancellationToken);
        if (getCategoryDetail?.Data != null)
        {
            var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
            if (categoryIds?.Any() == true)
                request.SetCategory(categoryIds);
        }

        var result = await _service.GetRelativeAsync(request, cancellationToken);
        return new BaseProcess<List<ServiceItemResponse>>(result?.Data, result?.Errors);
    }
}
