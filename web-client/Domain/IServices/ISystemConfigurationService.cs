using web_client.Models.Base;
using web_client.Models.Request.SystemConfigurations;
using web_client.Models.Response.SystemConfigurations;

namespace web_client.Domain.IServices;

public interface ISystemConfigurationService
{
    Task<BaseProcess<List<SystemConfigurationItemResponse>>> GetAllAsync(GetAllSystemConfigurationRequest request,CancellationToken cancellationToken);
    Task<BaseProcess<SystemConfigurationDetailResponse>> GetDetailAsync(BaseDetailRequestDto request,CancellationToken cancellationToken);
}
