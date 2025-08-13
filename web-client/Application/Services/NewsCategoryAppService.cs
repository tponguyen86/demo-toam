using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Models.Base;
using web_client.Models.Request.Categories;
using web_client.Models.Request.Categories.News;
using web_client.Models.Responses.Categories.News;
using static web_client.Helpers.Shared.PredefineDataConst;

namespace web_client.Application.Services;

public class NewsCategoryAppService : INewsCategoryAppService
{
    private readonly INewsCategoryService _service;

    public NewsCategoryAppService(INewsCategoryService service)
    {
        _service = service;
    }

    public async Task<BaseProcess<IEnumerable<NewsCategoryItemResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var request = new GetNewsCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.Category);
        request.ParentId = CategoryParentId.Key.News.GetGuid();
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<NewsCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<IEnumerable<NewsCategoryItemResponse>>> GetByShowHomeAsync(CancellationToken cancellationToken)
    {
        var request = new GetNewsCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.Category);
        request.ParentId = CategoryParentId.Key.News.GetGuid();
        request.ShowHome = true;
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<NewsCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<IEnumerable<NewsCategoryItemResponse>>> GetByShowMenuAsync(CancellationToken cancellationToken)
    {
        var request = new GetNewsCategoryAllRequest();
        request.SetDiscriminator(CategoryDiscriminator.Key.Category);
        request.ParentId = CategoryParentId.Key.News.GetGuid();
        request.ShowMenu = true;
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<NewsCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<NewsCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request)
    {
        var requestCategory = new CategoryDetailRequestDto(request);
        requestCategory.SetDiscriminator(CategoryDiscriminator.Key.Category);
        requestCategory.SetParentId(CategoryParentId.Key.News.GetGuid());
        var result = await _service.GetDetailAsync(requestCategory, CancellationToken.None);
        return new BaseProcess<NewsCategoryDetailResponse>(result.Data, result?.Errors);
    }
}
