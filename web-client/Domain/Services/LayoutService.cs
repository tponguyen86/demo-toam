using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Htmls.Carousels;
using web_client.Models.Request.SystemConfigurations;
using web_client.Models.Response.SystemConfigurations;

namespace web_client.Domain.Services;

public class LayoutService : ILayoutService
{
    private readonly ISystemConfigurationService _systemConfigurationService;
    public LayoutService(ISystemConfigurationService systemConfigurationService)
    {
        _systemConfigurationService = systemConfigurationService;
    }
    public Task<BaseProcess<List<SystemConfigurationItemResponse>>> GetAllSystemConfigurationAsync(GetAllSystemConfigurationRequest request, CancellationToken cancellationToken)
    => _systemConfigurationService.GetAllAsync(request, CancellationToken.None);

    public Task<BaseProcess<SystemConfigurationDetailResponse>> GetSystemConfigurationDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
   => _systemConfigurationService.GetDetailAsync(request, CancellationToken.None);
}