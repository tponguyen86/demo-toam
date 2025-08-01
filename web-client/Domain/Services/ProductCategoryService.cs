﻿using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Request.Categories.Products;
using web_client.Models.Responses.Categories.Products;

namespace web_client.Domain.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly NetectManageContext _context;
    private readonly ILookupService _lookup;

    public ProductCategoryService(NetectManageContext context, ILookupService lookup)
    {
        _context = context;
        _lookup = lookup;
    }

    public async Task<BaseProcess<ProductCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    {
        var query = _context.ProductCategories.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status != PredefineDataConst.Status.Key.Active).OrderByDescending(x => x.Sort).ThenBy(x => x.ParentId).AsQueryable();

        var result = await query.FirstOrDefaultAsync(cancellationToken);
        if (result == null)
            return BaseProcess<ProductCategoryDetailResponse>.Success(null);

        var response = new ProductCategoryDetailResponse(result);

        //set look up
        var selectModels = new List<BaseSelectModel>();
        if (response.ParentIdModel != null)
            selectModels.Add(response.ParentIdModel);

        if (response.GroupProductSettingModel != null)
            selectModels.Add(response.GroupProductSettingModel);

        if (selectModels?.Any() == true)
            await _lookup.GetLookUpAsync(selectModels, cancellationToken);

        return BaseProcess<ProductCategoryDetailResponse>.Success(response);
    }

    public async Task<BaseProcess<List<ProductCategoryItemResponse>>> GetAllAsync(GetProductCategoryAllRequest request, CancellationToken cancellationToken)
    {
        var query = _context.ProductCategories.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status != PredefineDataConst.Status.Key.Active).OrderByDescending(x => x.Sort).ThenBy(x => x.ParentId).AsQueryable();

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

        var response = result.Select(x => new ProductCategoryItemResponse(x)).ToList();

        if (response?.Any() != true)
            return BaseProcess<List<ProductCategoryItemResponse>>.Success(response);

        //set look up
        var selectModels = new List<BaseSelectModel>();
        foreach (var item in response)
        {
            if (item.ParentIdModel != null)
                selectModels.Add(item.ParentIdModel);

            if (item.GroupProductSettingModel != null)
                selectModels.Add(item.GroupProductSettingModel);
        }
        if (selectModels?.Any() == true)
            await _lookup.GetLookUpAsync(selectModels, cancellationToken);

        return BaseProcess<List<ProductCategoryItemResponse>>.Success(response);
    }
}

