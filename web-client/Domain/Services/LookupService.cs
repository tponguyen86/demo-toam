using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Base.Properties;
using web_client.Models.Data.Contexts;

namespace web_client.Domain.Services;

public class LookupService : ILookupService
{
    private readonly NetectManageContext _context;
    public LookupService(NetectManageContext context)
    {
        _context = context;
    }
    public async Task<BaseProcess<int>> GetLookUpAsync(List<BaseSelectModel> request, CancellationToken cancellationToken)
    {
        await LookUpProductCategory(request, cancellationToken);
        await LookUpGroupProductSetting(request, cancellationToken);
        await LookUpPredefineData(request, cancellationToken);

        return BaseProcess<int>.Success(1);
    }
    private async Task LookUpPredefineData(List<BaseSelectModel> request, CancellationToken cancellationToken)
    {
        var keyValues = request?.Where(x => x is PredefineDataSelectModel).Select(x => x as PredefineDataSelectModel);
        if (keyValues?.Any() != true) return;
        //group_key
        var keys = keyValues.Select(x => x.GetKeyFilter())?.Distinct()?.ToList();
        if (keys?.Any() != true) return;

        var datas = await _context.PredefinesData.Where(x => keys.Contains(x.Group + x.Key) || keys.Contains(x.Id.ToString())).ToListAsync(cancellationToken);
        if (datas?.Any() != true)
            return;

        foreach (var item in keyValues)
        {
            if (item == null) continue;
            var selected = datas.FirstOrDefault(x => item.GetKeyFilter() == $"{x.Id}" || item.GetKeyFilter() == $"{x.Group}{x.Key}");
            if (selected == null)
                item.Value = item.Key = item.GetKeyFilter();
            else
            {
                item.Value = $"{selected.Id}";
                item.Key = selected.Key;
                item.Label = selected.Value;
                item.SetData(new
                {
                    selected.PrivateSetting,
                    selected.PublicSetting,
                    selected.Group,
                    selected.Status,
                });
            }
        }
    }
    private async Task LookUpGroupProductSetting(List<BaseSelectModel> request, CancellationToken cancellationToken)
    {
        var keyValues = request?.Where(x => x is GroupProductSettingSelectModel).Select(x => x as GroupProductSettingSelectModel);
        if (keyValues?.Any() != true) return;
        var keys = keyValues.Select(x => x.GetKeyFilter())?.Distinct()?.ToList();
        if (keys?.Any() != true) return;

        var datas = await _context.GroupProductSettings.Where(x => keys.Contains(x.Id.ToString())).ToListAsync(cancellationToken);
        if (datas?.Any() != true)
            return;

        foreach (var item in keyValues)
        {
            if (item == null) continue;
            var selected = datas.FirstOrDefault(x => item.GetKeyFilter() == $"{x.Id}");
            if (selected == null)
                item.Value = item.Key = item.GetKeyFilter();
            else
            {
                item.Value = $"{selected.Id}";
                item.Key = $"{selected.Id}";
                item.Label = selected.Name;
                item.SetData(new
                {
                    selected.Status
                });
            }
        }
    }
    private async Task LookUpProductCategory(List<BaseSelectModel> request, CancellationToken cancellationToken)
    {
        var keyValues = request?.Where(x => x is CategoryProductSelectModel).Select(x => x as CategoryProductSelectModel);
        if (keyValues?.Any() != true) return;
        var keys = keyValues.Select(x => x.GetKeyFilter())?.Distinct()?.ToList();
        if (keys?.Any() != true) return;

        var datas = await _context.ProductCategories.Where(x => keys.Contains(x.Id.ToString())).ToListAsync(cancellationToken);
        if (datas?.Any() != true)
            return;

        foreach (var item in keyValues)
        {
            if (item == null) continue;
            var selected = datas.FirstOrDefault(x => item.GetKeyFilter() == $"{x.Id}");
            if (selected == null)
                item.Value = item.Key = item.GetKeyFilter();
            else
            {
                item.Value = $"{selected.Id}";
                item.Key = $"{selected.PageKeyName}";
                item.Label = selected.Name;
                item.SetData(new
                {
                    Sort = selected.Sort ?? 0,
                    selected.ParentId,
                    selected.ShowHome,
                    selected.GroupProductSetting,
                    selected.ShowMenu,
                    selected.PageKeyName,
                    selected.Status,
                });
            }
        }
    }
}