using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Request.Categories;
using web_client.Models.Request.Categories.Details;
using web_client.Models.Request.News;
using web_client.Models.Response.News;

namespace web_client.Application.Services;

public class NewsAppService : INewsAppService
{
    private readonly INewsService _service;
    private readonly ICategoryService _categoryServices;

    public NewsAppService(INewsService service, ICategoryService categoryServices)
    {
        _service = service;
        _categoryServices = categoryServices;
    }

    public Task<BaseProcess<NewsDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    => _service.GetDetailAsync(request, cancellationToken);

    public async Task<BaseProcess<IEnumerable<NewsItemResponse>>> GetFeatureAsync(int? take, CancellationToken cancellationToken = default)
    {
        var request = new NewsPagingRequest();
        var categoryDetailRequest = new GetCategoryAllIdRequest(PredefineDataConst.CategoryParentId.Key.News.GetGuid());
        var getCategoryDetail = await _categoryServices.GetAllIdAsync(categoryDetailRequest, cancellationToken);
        if (getCategoryDetail?.Data != null)
        {
            var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
            if (categoryIds?.Any() == true)
                request.SetCategory(categoryIds);
        }

        //request.AddCategory(PredefineDataConst.CategoryParentId.Key.News.GetGuid());
        request.PageSize = take ?? 5;
        request.Featured = true;
        var result = await _service.GetPagingAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<NewsItemResponse>>(result?.Data?.Items, result?.Errors);
    }

    public Task<BaseProcess<BasePagingModel<NewsItemResponse>>> GetPagingAsync(NewsPagingRequest request, CancellationToken cancellationToken)
    => _service.GetPagingAsync(request, cancellationToken);

    public async Task<BaseProcess<List<NewsItemResponse>>> GetRelativeAsync(GetCategoryDetailRelativeRequest request, CancellationToken cancellationToken)
    {
        var categoryDetailRequest = new GetCategoryAllIdRequest(PredefineDataConst.CategoryParentId.Key.News.GetGuid());
        //Discriminator ="Category" ( optionnal ) because get by idCategory
        categoryDetailRequest.SetDiscriminator(PredefineDataConst.CategoryDiscriminator.Key.Category);
        var getCategoryDetail = await _categoryServices.GetAllIdAsync(categoryDetailRequest, cancellationToken);
        if (getCategoryDetail?.Data != null)
        {
            var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
            if (categoryIds?.Any() == true)
                request.SetCategory(categoryIds);
        }

        var result = await _service.GetRelativeAsync(request, cancellationToken);
        return new BaseProcess<List<NewsItemResponse>>(result?.Data, result?.Errors);
    }
}
