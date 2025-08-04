using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Models.Base;
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
        request.Discriminator = CategoryDiscriminator.Key.Category;
        request.ParentId = CategoryParentId.Key.News.GetGuid();
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<NewsCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<IEnumerable<NewsCategoryItemResponse>>> GetByShowHomeAsync(CancellationToken cancellationToken)
    {
        var request = new GetNewsCategoryAllRequest();
        request.Discriminator = CategoryDiscriminator.Key.Category;
        request.ParentId = CategoryParentId.Key.News.GetGuid();
        request.ShowHome = true;
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<NewsCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<IEnumerable<NewsCategoryItemResponse>>> GetByShowMenuAsync(CancellationToken cancellationToken)
    {
        var request = new GetNewsCategoryAllRequest();
        request.Discriminator = CategoryDiscriminator.Key.Category;
        request.ParentId = CategoryParentId.Key.News.GetGuid();
        request.ShowMenu = true;
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<NewsCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public Task<BaseProcess<NewsCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request)
   => _service.GetDetailAsync(request, CancellationToken.None);
}
