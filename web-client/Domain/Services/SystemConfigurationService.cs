using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Request.SystemConfigurations;
using web_client.Models.Response.SystemConfigurations;

namespace web_client.Domain.Services;

public class SystemConfigurationService : ISystemConfigurationService
{
    private readonly NetectManageContext _context;
    private readonly ILookupService _lookup;

    public SystemConfigurationService(NetectManageContext context, ILookupService lookup)
    {
        _context = context;
        _lookup = lookup;
    }

    public async Task<BaseProcess<List<SystemConfigurationItemResponse>>> GetAllAsync(GetAllSystemConfigurationRequest request, CancellationToken cancellationToken)
    {
        var query = _context.SystemConfigurations.AsQueryable();

        //if (request?.HasStatus() == true)
        //{
        //    query = query.Where(x => x.Status == request.Status);
        //}

        var result = await query.OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);
        var response = result.Select(x => new SystemConfigurationItemResponse(x)).ToList();
        if (response?.Any() != true)
            return BaseProcess<List<SystemConfigurationItemResponse>>.Success(response);

        //set look up
        //var selectModels = new List<BaseSelectModel>();
        //foreach (var item in response)
        //{
        //    if (item.TypeModel != null)
        //        selectModels.Add(item.TypeModel);
        //}
        //if (selectModels?.Any() == true)
        //    await _lookup.GetLookUpAsync(selectModels, cancellationToken);

        return BaseProcess<List<SystemConfigurationItemResponse>>.Success(response);
    }

    public async Task<BaseProcess<SystemConfigurationDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    {
        var query = _context.SystemConfigurations.AsQueryable();

        var result = await query.FirstOrDefaultAsync(cancellationToken);
        if (result == null)
            return BaseProcess<SystemConfigurationDetailResponse>.Success(null);

        var response = new SystemConfigurationDetailResponse(result);

        //set look up
        //var selectModels = new List<BaseSelectModel>();
        //if (response.TypeModel != null)
        //    selectModels.Add(response.TypeModel);

        //if (selectModels?.Any() == true)
        //    await _lookup.GetLookUpAsync(selectModels, cancellationToken);

        return BaseProcess<SystemConfigurationDetailResponse>.Success(response);
    }
}
