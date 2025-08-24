using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Base.Properties;
using web_client.Models.Data.Contexts;
using web_client.Models.Data.Contexts.Entities;

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
        await LookUpCategoryChild(request, cancellationToken);
        await LookUpCategory(request, cancellationToken);
        await LookUpProductCategory(request, cancellationToken);
        await LookUpGroupProductSetting(request, cancellationToken);
        await LookUpProperty(request, cancellationToken);
        await LookUpPropertyValue(request, cancellationToken);
        await LookUpManager(request, cancellationToken);
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

    private async Task LookUpManager(List<BaseSelectModel> request, CancellationToken cancellationToken)
    {
        var keyValues = request?.Where(x => x is ManagerSelectModel).Select(x => x as ManagerSelectModel);
        if (keyValues?.Any() != true) return;
        var keys = keyValues.Select(x => x.GetKeyFilter())?.Distinct()?.ToList();
        if (keys?.Any() != true) return;

        var datas = await _context.Managers.Where(x => keys.Contains(x.Id.ToString())).ToListAsync(cancellationToken);
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
                item.Label = selected.FullName;
                item.SetData(new
                {
                    selected.UserName,
                    selected.Email,
                    selected.PhoneNumber,
                });
            }
        }
    }

    private async Task LookUpCategory(List<BaseSelectModel> request, CancellationToken cancellationToken)
    {
        var keyValues = request?.Where(x => x is CategorySelectModel).Select(x => x as CategorySelectModel);
        if (keyValues?.Any() != true) return;
        var keys = keyValues.Select(x => x.GetKeyFilter())?.Distinct()?.ToList();
        if (keys?.Any() != true) return;
        var categories = await _context.Categories.ToListAsync(cancellationToken);
        var datas = categories.Where(x => keys.Contains(x.Id.ToString())).ToList();
        if (datas?.Any() != true)
            return;
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
                item.SetData(new CategoryDataSelectModel
                {
                    Sort = selected.Sort,
                    ParentId = selected.ParentId,
                    ShowHome = selected.ShowHome,
                    ShowMenu = selected.ShowMenu,
                    PageKeyName = selected.PageKeyName,
                    ShortDescription = selected.ShortDescription,
                    Image = selected.Image,
                    Banner = selected.Banner,
                    Id = selected.Id,
                });

            }
        }
    }

    private async Task LookUpProductCategory(List<BaseSelectModel> request, CancellationToken cancellationToken)
    {
        var keyValues = request?.Where(x => x is ProductCategorySelectModel).Select(x => x as ProductCategorySelectModel);
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
    #region Category Child
    public List<Category> GetAllDescendants(List<Category> allItems, Guid parentId)
    {
        var children = allItems
            .Where(item => item.ParentId == parentId)
            .ToList();

        var descendants = new List<Category>(children);

        foreach (var child in children)
        {
            var subDescendants = GetAllDescendants(allItems, child.Id);
            descendants.AddRange(subDescendants);
        }

        return descendants;
    }

    private async Task LookUpCategoryChild(List<BaseSelectModel> request, CancellationToken cancellationToken)
    {
        var keyValues = request?.Where(x => x is CategoryChildrenSelectModel).Select(x => x as CategoryChildrenSelectModel);
        if (keyValues?.Any() != true) return;
        var keys = keyValues.Select(x => x.GetKeyFilter())?.Distinct()?.ToList();
        if (keys?.Any() != true) return;
        var categories = await _context.Categories.ToListAsync(cancellationToken);
        var datas = categories.Where(x => keys.Contains(x.Id.ToString())).ToList();
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
                item.SetData(new CategoryDataSelectModel
                {
                    Sort = selected.Sort,
                    ParentId = selected.ParentId,
                    ShowHome = selected.ShowHome,
                    ShowMenu = selected.ShowMenu,
                    PageKeyName = selected.PageKeyName,
                    ShortDescription = selected.ShortDescription,
                    Image = selected.Image,
                    Banner = selected.Banner,
                    Id = selected.Id,
                });
                //get child 
                var allChildren = GetAllDescendants(categories, selected.Id);
                item.Child = allChildren.Select(x => new CategorySelectModel(x.Id)
                {
                    Value = $"{x.Id}",
                    Key = $"{x.PageKeyName}",
                    Label = x.Name,
                    Data = new CategoryDataSelectModel
                    {
                        Sort = x.Sort,
                        ParentId = x.ParentId,
                        ShowHome = x.ShowHome,
                        ShowMenu = x.ShowMenu,
                        PageKeyName = x.PageKeyName,
                        ShortDescription = x.ShortDescription,
                        Image = x.Image,
                        Banner = x.Banner,
                        Id = x.Id,
                    }
                }).ToList();
            }
        }
    }
    #endregion

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
    private async Task LookUpProperty(List<BaseSelectModel> request, CancellationToken cancellationToken)
    {
        var keyValues = request?.Where(x => x is PropertySelectModel).Select(x => x as PropertySelectModel);
        if (keyValues?.Any() != true) return;
        var keys = keyValues.Select(x => x.GetKeyFilter())?.Distinct()?.ToArray();
        if (keys?.Any() != true) return;
        var jsonKeys = keys.Select(x => $"[{{\"Code\":\"{x}\"}}]");
        //    var datas1 = await _context.GroupProductSettings
        //.FromSqlInterpolated($@"
        //    SELECT * 
        //    FROM ""GroupProductSettings""
        //    WHERE jsonb_path_exists(""Properties"", '$[*] ? (@.Code in (""hang-san-xuat""))')")
        //.ToListAsync(cancellationToken);
        var dataList = await _context.GroupProductSettings.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete).ToListAsync(cancellationToken);
        var datas3 = await _context.GroupProductSettings.Where(x => EF.Functions.JsonContains(x.Properties, jsonKeys)).ToListAsync(cancellationToken);
        var datas4 = await _context.GroupProductSettings.Where(x => keys.Any(k => EF.Functions.JsonExists(x.Properties.Select(x => x.Code), k))).ToListAsync(cancellationToken);
        var datas = await _context.GroupProductSettings.Where(x => keys.Contains(x.Id.ToString()) ||
        (x.Properties != null && keys.Any(k => EF.Functions.JsonContains(x.Properties, jsonKeys)))).ToListAsync(cancellationToken);
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

    private async Task LookUpPropertyValue(List<BaseSelectModel> request, CancellationToken cancellationToken)
    {
        var keyValues = request?.Where(x => x is PropertyValueSelectModel).Select(x => x as PropertyValueSelectModel);
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

}