using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Request.Categories;
using web_client.Models.Response.Categories;
using web_client.Models.Response.Categories.Products;

namespace web_client.Domain.Services;

public class CategoryService : ICategoryService
{
    private readonly NetectManageContext _context;
    private readonly ILookupService _lookup;

    public CategoryService(NetectManageContext context, ILookupService lookup)
    {
        _context = context;
        _lookup = lookup;
    }

    public async Task<BaseProcess<GetCategoryAllIdResponse>> GetAllIdAsync(GetCategoryAllIdRequest request, CancellationToken cancellationToken)
    {
        var query = _context.Categories.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status == PredefineDataConst.Status.Key.Active && (x.PageKeyName == request.Code || x.Id == request.Id)).AsQueryable();

        if (request?.DiscriminatorHasValue() == true)
        {
            string discriminator = request.GetDiscriminator();
            query = query.Where(x => x.Discriminator == discriminator);
        }

        if (request?.ParentIdValidate() == true)
        {
            var parentId = request.GetParentId();
            query = query.Where(x => x.ParentId == parentId);
        }

        var result = await query.FirstOrDefaultAsync(cancellationToken);

        if (result == null)
            return BaseProcess<GetCategoryAllIdResponse>.Success(null);

        var response = new GetCategoryAllIdResponse(result);

        //set look up
        var selectModels = new List<BaseSelectModel>();
        if (response.ChildModel != null)
            selectModels.Add(response.ChildModel);

        if (response.ParentIdModel != null)
            selectModels.Add(response.ParentIdModel);

        if (selectModels?.Any() == true)
            await _lookup.GetLookUpAsync(selectModels, cancellationToken);

        return BaseProcess<GetCategoryAllIdResponse>.Success(response);
    }

    public async Task<BaseProcess<GetGroupProductSettingByProductCategoryIdResponse>> GetGroupProductSettingByProductCategoryId(Guid categoryId, CancellationToken cancellationToken)
    {
        if (categoryId.HasValueGuid() != true)
            return BaseProcess<GetGroupProductSettingByProductCategoryIdResponse>.Success(null);

        var result = await GetGroupProductSettingId(categoryId, cancellationToken);
        if (result == null) return BaseProcess<GetGroupProductSettingByProductCategoryIdResponse>.Success(null);

        var response = new GetGroupProductSettingByProductCategoryIdResponse() { InputCategoryId = categoryId };
        response.OutputGroupSettingId = result.Value.outputSettingId;
        response.OutputCategoryId = result.Value.outputCategoryId;
        return BaseProcess<GetGroupProductSettingByProductCategoryIdResponse>.Success(response);
    }
    private async Task<(Guid outputCategoryId, Guid outputSettingId)?> GetGroupProductSettingId(Guid categoryId, CancellationToken cancellationToken)
    {
        var category = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == categoryId && x.Status != PredefineDataConst.SystemStatus.Key.Delete, cancellationToken);
        if (category != null)
        {
            // Check if the current category has a group product setting
            if (category.GroupProductSetting != Guid.Empty)
            {
                return (category.Id, category.GroupProductSetting);
            }
            // If not, recursively check the parent category
            if (category.ParentId.HasValue)
            {
                return await GetGroupProductSettingId(category.ParentId.Value, cancellationToken);
            }
        }
        return null;
    }
}

