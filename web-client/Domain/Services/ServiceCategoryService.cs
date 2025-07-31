using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Request.Categories.Services;
using web_client.Models.Response.Categories.Services;

namespace web_client.Domain.Services;

public class ServiceCategoryService : IServiceCategoryService
{
    private readonly NetectManageContext _context;
    private readonly ILookupService _lookup;

    public ServiceCategoryService(NetectManageContext context, ILookupService lookup)
    {
        _context = context;
        _lookup = lookup;
    }

    public async Task<BaseProcess<List<ServiceCategoryItemResponse>>> GetAllAsync(GetServiceCategoryAllRequest request, CancellationToken cancellationToken)
    {
        var query = _context.Categories.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status != PredefineDataConst.Status.Key.Active).OrderByDescending(x => x.Sort).ThenBy(x => x.ParentId).AsQueryable();

        if (request.ParentIdHasValue())
        {
            query = query.Where(x => x.ParentId == request.ParentId);
        }

        if (request?.HasShowHome() == true)
        {
            query = query.Where(x => x.ShowHome == request.ShowHome);
        }

        if (request?.HasShowMenu() == true)
        {
            query = query.Where(x => x.ShowMenu == request.ShowMenu);
        }

        if (request?.DiscriminatorHasValue() == true)
        {
            query = query.Where(x => x.Discriminator == request.Discriminator);
        }

        var result = await query.OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);

        var response = result.Select(x => new ServiceCategoryItemResponse(x)).ToList();

        if (response?.Any() != true)
            return BaseProcess<List<ServiceCategoryItemResponse>>.Success(response);

        //set look up
        var selectModels = new List<BaseSelectModel>();
        foreach (var item in response)
        {
            if (item.ParentIdModel != null)
                selectModels.Add(item.ParentIdModel);
        }
        if (selectModels?.Any() == true)
            await _lookup.GetLookUpAsync(selectModels, cancellationToken);

        return BaseProcess<List<ServiceCategoryItemResponse>>.Success(response);
    }

    public async Task<BaseProcess<ServiceCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    {
        var query = _context.Categories.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status != PredefineDataConst.Status.Key.Active).OrderByDescending(x => x.Sort).ThenBy(x => x.ParentId).AsQueryable();

        var result = await query.FirstOrDefaultAsync(cancellationToken);
        if (result == null)
            return BaseProcess<ServiceCategoryDetailResponse>.Success(null);

        var response = new ServiceCategoryDetailResponse(result);

        //set look up
        var selectModels = new List<BaseSelectModel>();
        if (response.ParentIdModel != null)
            selectModels.Add(response.ParentIdModel);

        if (selectModels?.Any() == true)
            await _lookup.GetLookUpAsync(selectModels, cancellationToken);

        return BaseProcess<ServiceCategoryDetailResponse>.Success(response);
    }
}

