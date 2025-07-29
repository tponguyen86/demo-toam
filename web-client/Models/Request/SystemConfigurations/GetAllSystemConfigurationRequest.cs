using web_client.Helpers;
using web_client.Helpers.Shared;

namespace web_client.Models.Request.SystemConfigurations;

public class GetAllSystemConfigurationRequest
{
    public string? Status { get; set; } = PredefineDataConst.SystemStatus.Key.Active;
    public void SetActive()
    {
        Status = PredefineDataConst.SystemStatus.Key.Active;
    }
    public bool HasStatus() { return Status?.HasValueString() == true; }
}
