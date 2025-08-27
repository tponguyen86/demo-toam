using web_client.Models.Base;
using web_client.Models.Request.SystemConfigurations;
using web_client.Models.Response.SystemConfigurations;
using web_client.Models.Responses.Categories;

namespace web_client.Application.IServices;
public interface ILayoutAppService
{
    Task<BaseProcess<List<SystemConfigurationItemResponse>>> GetSystemConfigurationsAsync(GetAllSystemConfigurationRequest request);
    Task<BaseProcess<List<CategoryItemResponse>>> GetMenuTopAsync();
    Task<BaseProcess<SystemConfigurationDetailResponse>> GetSystemConfigurationDetailAsync(BaseDetailRequestDto request);

    SystemConfigurationItemResponse? GetSystemConfigurationLocal(List<SystemConfigurationItemResponse>? datas, string key);
    string? GetSystemConfigurationValueLocal(List<SystemConfigurationItemResponse>? datas, string key, string? defaultValue = "");
}