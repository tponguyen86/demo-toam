using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Request.SystemConfigurations;
using web_client.Models.Response.SystemConfigurations;

namespace web_client.Application.Services;

public class LayoutAppService : ILayoutAppService
{
    private readonly ILayoutService _layoutService;
    private readonly ISystemConfigurationService _systemConfigurationService;

    public LayoutAppService(ILayoutService layoutService, ISystemConfigurationService systemConfigurationService)
    {
        _layoutService = layoutService;
        _systemConfigurationService = systemConfigurationService;
    }

    public Task<BaseProcess<SystemConfigurationDetailResponse>> GetSystemConfigurationDetailAsync(BaseDetailRequestDto request)
    => _systemConfigurationService.GetDetailAsync(request, CancellationToken.None);

    public Task<BaseProcess<List<SystemConfigurationItemResponse>>> GetSystemConfigurationsAsync(GetAllSystemConfigurationRequest request)
    => _systemConfigurationService.GetAllAsync(request, CancellationToken.None);

    public SystemConfigurationItemResponse? GetSystemConfigurationLocal(List<SystemConfigurationItemResponse>? datas, string key)
    {
        if (string.IsNullOrEmpty(key) || datas?.Any() != true) return null;
        var data = datas?.FirstOrDefault(x => x.Key == key);
        return data;
    }
    public string? GetSystemConfigurationValueLocal(List<SystemConfigurationItemResponse>? datas, string key, string? defaultValue = "")
    {
        return GetSystemConfigurationLocal(datas, key)?.Value ?? defaultValue;
    }
}
