using web_client.Models.Base;
using web_client.Models.Request.Pages;
using web_client.Models.Response.Pages;
using web_client.Models.Response.Pages.PageConfigurations;

namespace web_client.Application.IServices;

public interface IPageAppService
{
    Task<BaseProcess<List<PageItemResponse>>> GetAllAsync(GetPageAllRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<IEnumerable<PageItemResponse>>> GetGroupAsync(GetByGroupRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<PageDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);

    #region Page Config
    Task<BaseProcess<List<BasePageConfigurationResponse>>> GetConfigByPageAsync(Guid pageId);
    #endregion
}