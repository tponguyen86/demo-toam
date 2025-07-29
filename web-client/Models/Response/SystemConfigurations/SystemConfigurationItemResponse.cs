using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Request.SystemConfigurations;

namespace web_client.Models.Response.SystemConfigurations;

public class SystemConfigurationItemResponse : BaseSystemConfigurationModel
{
    public Guid Id { get; set; }
    public SystemConfigurationItemResponse()
    {

    }
    public SystemConfigurationItemResponse(SystemConfiguration systemConfiguration)
    {
        Id = systemConfiguration.Id;
        Name = systemConfiguration.Name;
        Key = systemConfiguration.Key;
        Value = systemConfiguration.Value;
        Type = systemConfiguration.Type;
    }
}