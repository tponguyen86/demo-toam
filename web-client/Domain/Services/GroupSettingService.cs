using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Request.GroupProductSettings;
using web_client.Models.Request.GroupProductSettings.Children;
using web_client.Models.Response.GroupProductSettings;

namespace web_client.Domain.Services;

public class GroupSettingService : IGroupSettingService
{
    private readonly NetectManageContext _context;
    private readonly ILookupService _lookup;

    public GroupSettingService(NetectManageContext context, ILookupService lookup)
    {
        _context = context;
        _lookup = lookup;
    }
    public async Task<BaseProcess<GroupProductSettingDetailResponse>> GetGroupProductSettingDetail(GroupProductSettingDetailRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request?.ValidateId() != true)
            return BaseProcess<GroupProductSettingDetailResponse>.Success(null);

        var query = _context.GroupProductSettings.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete).AsQueryable();
        if (request?.ValidateId() == true)
            query = query.Where(x => x.Id == request.Id);

        if (request?.StatusHasValue() == true)
            query = query.Where(x => x.Status == request.Status);

        var result = await query.FirstOrDefaultAsync(cancellationToken);
        if (result == null) return BaseProcess<GroupProductSettingDetailResponse>.Success(null);

        var properties = result.Properties?.Select(x => new BaseGroupProductSettingPropertyModel()
        {
            Code = x.Code,
            Name = x.Name,
            Selected = x.Selected,
            ShowInPageList = x.ShowInPageList,
            Properties = x.Properties?.Select(x1 => new BasePropertySelectModel()
            {
                Id = x1.Id,
                Name = x1.Name,
                Number = x1.Number,
                NumberValue = x1.NumberValue,
                Value = x1.Value,
            }).ToList()
        });

        if (properties?.Any() == true && request?.PropertySelectedHasValue() == true)
            properties = properties?.Where(x => x.Selected == request?.PropertySelected);

        var response = new GroupProductSettingDetailResponse()
        {
            Name = result.Name,
            Code = result.Code,
            Id = result.Id,
            Status = result.Status,
            Properties = properties?.ToList()
        };
        return BaseProcess<GroupProductSettingDetailResponse>.Success(response);
    }
}
