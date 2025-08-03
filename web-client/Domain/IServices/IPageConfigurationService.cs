using web_client.Models.Base;
using web_client.Models.Response.Pages.PageConfigurations;

namespace web_client.Domain.IServices;

public interface IPageConfigurationService
{
    Task<BaseProcess<List<BasePageConfigurationResponse>>> GetConfigByPageAsync(Guid pageId, CancellationToken cancellationToken);
}
