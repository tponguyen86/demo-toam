using web_client.Models.Base;
using web_client.Models.Request.GroupProductSettings;
using web_client.Models.Response.GroupProductSettings;

namespace web_client.Domain.IServices;

public interface IGroupSettingService
{
    Task<BaseProcess<GroupProductSettingDetailResponse>> GetGroupProductSettingDetail(GroupProductSettingDetailRequest request, CancellationToken cancellationToken);
}
