using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Request.Pages;
using web_client.Models.Response.Pages;
using web_client.Models.Response.Pages.PageConfigurations;

namespace web_client.Application.Services;

public class PageAppService : IPageAppService
{
    private readonly IPageService _service;
    private readonly IPageConfigurationService _pageConfigurationService;

    public PageAppService(IPageService service, IPageConfigurationService pageConfigurationService)
    {
        _service = service;
        _pageConfigurationService = pageConfigurationService;
    }

    public Task<BaseProcess<List<PageItemResponse>>> GetAllAsync(GetPageAllRequest request, CancellationToken cancellationToken)
    => _service.GetAllAsync(request, cancellationToken);

    public Task<BaseProcess<PageDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    => _service.GetDetailAsync(request, cancellationToken);

    public Task<BaseProcess<IEnumerable<PageItemResponse>>> GetGroupAsync(GetByGroupRequest request, CancellationToken cancellationToken)
    {
        //var requestAll = new GetPageAllRequest();
        ////requestAll.Group = request.PageKey;
        //var result =  _service.GetAllAsync(requestAll, cancellationToken);
        //return result;
        return null;
    }

    public Task<BaseProcess<List<BasePageConfigurationResponse>>> GetConfigByPageAsync(Guid pageId)
    => _pageConfigurationService.GetConfigByPageAsync(pageId, CancellationToken.None);
}
