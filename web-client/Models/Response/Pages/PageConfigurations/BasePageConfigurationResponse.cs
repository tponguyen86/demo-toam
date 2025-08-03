using System.Text.Json;
using web_client.Models.Request.Pages.PageConfigurations;

namespace web_client.Models.Response.Pages.PageConfigurations;

public class BasePageConfigurationResponse<TValue> : BasePageConfigurationModel<TValue>
{
}
public class BasePageConfigurationResponse : BasePageConfigurationModel<JsonDocument>
{
}
