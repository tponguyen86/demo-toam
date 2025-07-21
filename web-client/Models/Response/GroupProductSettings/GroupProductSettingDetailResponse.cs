using web_client.Models.Request.GroupProductSettings.Children;

namespace web_client.Models.Response.GroupProductSettings;

public class GroupProductSettingDetailResponse : GroupProductSettingItemResponse
{
    public List<BaseGroupProductSettingPropertyModel>? Properties { get; set; }
}
