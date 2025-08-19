using web_client.Models.Base;
using web_client.Models.Request.GroupProductSettings;
using web_client.Models.Response.GroupProductSettings;

namespace web_client.Application.IServices;

public interface IGroupSettingAppService
{
    Task<BaseProcess<GroupProductSettingDetailResponse>> GetGroupProductSettingDetailByCategoryId(Guid categoryId);
}
