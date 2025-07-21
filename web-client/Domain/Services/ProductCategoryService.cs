using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Helpers;
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
    public Task<BaseProcess<ProductCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseProcess<BasePagingModel<ProductCategoryItemResponse>>> GetPagingAsync(FilterProductCategoryRequest request, CancellationToken cancellationToken)
    {
        var query = _context.ProductCategories.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete).OrderByDescending(x => x.Sort).ThenBy(x => x.ParentId).AsQueryable();

        if (request.HasKeySearch() == true)
        {
            var keySearch = request.GetKeySearch();
            query = query.Where(x => EF.Functions.Unaccent(x.Name.ToLower()).Contains(keySearch));
        }

        if (request.ParentIdHasValue())
        {
            query = query.Where(x => x.ParentId == request.ParentId);
        }

        if (request?.HasStatus() == true)
        {
            query = query.Where(x => x.Status == request.Status);
        }

        if (request?.ShowHomeHasValue() == true)
        {
            query = query.Where(x => x.ShowHome == request.ShowHome);
        }

        var page = request?.GetPage() ?? 1;
        var pageSize = request?.GetPageSize() ?? 10;

        var pager = await query.OrderByDescending(x => x.CreatedAt).Paging(page, pageSize, cancellationToken);

        var resultItems = pager.Items.Select(x => new ProductCategoryItemResponse(x)).ToList();

        var response = pager.GetPaging(resultItems);

        if (response.Items?.Any() != true)
            return BaseProcess<BasePagingModel<ProductCategoryItemResponse>>.Success(response);

        //set look up
        var selectModels = new List<BaseSelectModel>();
        foreach (var item in response.Items)
        {
            if (item.ParentIdModel != null)
                selectModels.Add(item.ParentIdModel);

            if (item.GroupProductSettingModel != null)
                selectModels.Add(item.GroupProductSettingModel);
        }
        if (selectModels?.Any() == true)
            await _lookup.GetLookUpAsync(selectModels, cancellationToken);


        return BaseProcess<BasePagingModel<ProductCategoryItemResponse>>.Success(response);
    }
}

