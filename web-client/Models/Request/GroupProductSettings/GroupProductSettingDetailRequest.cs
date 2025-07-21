using web_client.Helpers.Shared;
using web_client.Models.Base;

namespace web_client.Models.Request.GroupProductSettings;

public class GroupProductSettingDetailRequest : BaseDetailRequestDto
{
    public string? Status { get; set; }
    public bool StatusHasValue() => !string.IsNullOrEmpty(Status);
    public void SetStatusActive() => Status = StatusConst.Active;

    public bool? PropertySelected { get; set; }
    public bool PropertySelectedHasValue() => PropertySelected.HasValue;
    public void SetPropertySelectedTrue() => PropertySelected = true;
    public GroupProductSettingDetailRequest(Guid id) : base(id)
    {
    }
}
