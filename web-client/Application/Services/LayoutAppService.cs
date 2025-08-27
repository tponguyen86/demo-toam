using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Request.Categories.Services;
using web_client.Models.Request.SystemConfigurations;
using web_client.Models.Response.SystemConfigurations;
using web_client.Models.Responses.Categories;

namespace web_client.Application.Services;

public class LayoutAppService : ILayoutAppService
{
    private readonly ILayoutService _layoutService;
    private readonly ISystemConfigurationService _systemConfigurationService;
    private readonly ICategoryService _categoryService;

    public LayoutAppService(ILayoutService layoutService, ISystemConfigurationService systemConfigurationService, ICategoryService categoryService)
    {
        _layoutService = layoutService;
        _systemConfigurationService = systemConfigurationService;
        _categoryService = categoryService;
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

    public async Task<BaseProcess<List<CategoryItemResponse>>> GetMenuTopAsync()
    {
        var request = new GetServiceCategoryAllRequest();
        request.SetTopLevel();
        request.ShowMenu = true;
        var result = await _categoryService.GetAllAsync(request, CancellationToken.None);
        return new BaseProcess<List<CategoryItemResponse>>(result.Data, result?.Errors);
    }
}
