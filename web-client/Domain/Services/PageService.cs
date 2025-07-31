using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Request.Pages;
using web_client.Models.Response.Pages;

namespace web_client.Domain.Services;

public class PageService : IPageService
{
    private readonly NetectManageContext _context;
    private readonly ILookupService _lookup;

    public PageService(NetectManageContext context, ILookupService lookup)
    {
        _context = context;
        _lookup = lookup;
    }

    public async Task<BaseProcess<List<PageItemResponse>>> GetAllAsync(GetPageAllRequest request, CancellationToken cancellationToken)
    {
        var query = _context.Pages.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status != PredefineDataConst.Status.Key.Active).OrderByDescending(x => x.CreatedAt).AsQueryable();

        //if (request?.HasShowHome() == true)
        //{
        //    query = query.Where(x => x.ShowHome == request.ShowHome);
        //}

        //if (request?.HasShowMenu() == true)
        //{
        //    query = query.Where(x => x.ShowMenu == request.ShowMenu);
        //}

        var result = await query.OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);

        var response = result.Select(x => new PageItemResponse(x)).ToList();

        if (response?.Any() != true)
            return BaseProcess<List<PageItemResponse>>.Success(response);

        //set look up
        var selectModels = new List<BaseSelectModel>();
        //foreach (var item in response)
        //{
        //    if (item.TypeModel != null)
        //        selectModels.Add(item.TypeModel);
        //}
        if (selectModels?.Any() == true)
            await _lookup.GetLookUpAsync(selectModels, cancellationToken);

        return BaseProcess<List<PageItemResponse>>.Success(response);
    }

    public async Task<BaseProcess<PageDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    {
        var query = _context.Pages.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status != PredefineDataConst.Status.Key.Active && (x.PageKeyName == request.Code || x.Id == request.Id || x.Code == request.Code)).AsQueryable();

        var result = await query.FirstOrDefaultAsync(cancellationToken);
        if (result == null)
            return BaseProcess<PageDetailResponse>.Success(null);

        var response = new PageDetailResponse(result);

        //set look up
        var selectModels = new List<BaseSelectModel>();
        //if (response.TypeModel != null)
        //    selectModels.Add(response.TypeModel);

        if (selectModels?.Any() == true)
            await _lookup.GetLookUpAsync(selectModels, cancellationToken);

        return BaseProcess<PageDetailResponse>.Success(response);
    }
}

