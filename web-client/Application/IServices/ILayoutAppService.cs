using web_client.Models.Base;
using web_client.Models.Request.SystemConfigurations;
using web_client.Models.Response.SystemConfigurations;

namespace web_client.Application.IServices;
public interface ILayoutAppService
{
    Task<BaseProcess<List<SystemConfigurationItemResponse>>> GetSystemConfigurationsAsync(GetAllSystemConfigurationRequest request);
    Task<BaseProcess<SystemConfigurationDetailResponse>> GetSystemConfigurationDetailAsync(BaseDetailRequestDto request);

    SystemConfigurationItemResponse? GetSystemConfigurationLocal(List<SystemConfigurationItemResponse>? datas, string key);
    string? GetSystemConfigurationValueLocal(List<SystemConfigurationItemResponse>? datas, string key, string? defaultValue = "");
}