using web_client.Models.Data.Contexts.Entities;

namespace web_client.Models.Response.SystemConfigurations;

public class SystemConfigurationDetailResponse : SystemConfigurationItemResponse
{
    public SystemConfigurationDetailResponse() : base()
    {
    }
    public SystemConfigurationDetailResponse(SystemConfiguration systemConfiguration) : base(systemConfiguration)
    {
    }
}