namespace web_client.Models.Request.Pages.PageConfigurations;

public class BasePageConfigurationModel<TValue>
{
    public string Name { get; set; }
    public TValue? Value { get; set; }
    //public JsonDocument? PublicSetting { get; set; }
}
