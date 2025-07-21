using web_client.Models.Request.GroupProductSettings;

namespace web_client.Models.Response.GroupProductSettings;

public class GroupProductSettingItemResponse : BaseGroupProductSettingModel
{
    public Guid Id { get; set; }
    public string Status { get; set; }
}
