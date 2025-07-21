namespace web_client.Models.Request.GroupProductSettings.Children;

public class BaseGroupProductSettingPropertyModel
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<BasePropertySelectModel>? Properties { get; set; }
    public bool? Selected { get; set; } = false;
    public bool? ShowInPageList { get; set; } = false;
}
