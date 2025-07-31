using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Request.Pages;
using web_client.Models.Response.Pages;

namespace web_client.Application.Services;

public class PageAppService : IPageAppService
{
    private readonly IPageService _service;

    public PageAppService(IPageService service)
    {
        _service = service;
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
}
