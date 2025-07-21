using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Request.Products;
using web_client.Models.Response.Products;

namespace web_client.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly NetectManageContext _context;
        private readonly ILookupService _lookup;

        public ProductService(NetectManageContext context, ILookupService lookup)
        {
            _context = context;
            _lookup = lookup;
        }
        public Task<BaseProcess<ProductDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseProcess<BasePagingModel<ProductItemResponse>>> GetPagingAsync(ProductPagingRequest request, CancellationToken cancellationToken)
        {
            var query = _context.Products.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete).AsQueryable();

            if (request?.HasKeySearch() == true)
            {
                string keySearch = request.GetKeySearch();
                query = query.Where(x => x.Sku.Contains(keySearch) || EF.Functions.ILike(EF.Functions.Unaccent(x.Name.ToLower()), $"%{keySearch}%"));
            }

            if (request?.HasStatus() == true)
            {
                query = query.Where(x => x.Status == request.Status);
            }

            if (request?.CategoryHasValue() == true)
            {
                query = query.Where(x => x.ProductCategory == request.Category);
            }
            if (request?.FeaturedHasValue() == true)
            {
                query = query.Where(x => x.Featured == request.Featured);
            }

            var page = request?.GetPage() ?? 1;
            var pageSize = request?.GetPageSize() ?? 10;

            var pager = await query.OrderByDescending(x => x.CreatedAt).Paging(page, pageSize, cancellationToken);

            var resultItems = pager.Items.Select(x => new ProductItemResponse(x)).ToList();

            var response = pager.GetPaging(resultItems);

            if (response.Items?.Any() != true)
                return BaseProcess<BasePagingModel<ProductItemResponse>>.Success(response);

            //set look up
            var selectModels = new List<BaseSelectModel>();
            foreach (var item in response.Items)
            {
                //if (item.ProductCategory.HasValueGuid() == true)
                //{
                //    item.ProductCategoryModel = new CategoryProductSelectModel(item.ProductCategory);
                //    selectModels.Add(item.ProductCategoryModel);
                //}
                if (item.ProductCategoryModel != null)
                    selectModels.Add(item.ProductCategoryModel);

                if (item.GroupProductSettingModel != null)
                    selectModels.Add(item.GroupProductSettingModel);
                //if (item.Status?.HasValueString() == true)
                //{
                //    item.StatusModel = new PredefineDataSelectModel(PredefineDataConst.Status.Group, item.Status);
                //    selectModels.Add(item.StatusModel);
                //}
                if (item.StatusModel != null)
                    selectModels.Add(item.StatusModel);

                if (item.CreatedByModel != null)
                    selectModels.Add(item.CreatedByModel);

                if (item.UpdatedByModel != null)
                    selectModels.Add(item.UpdatedByModel);
            }
            if (selectModels?.Any() == true)
                await _lookup.GetLookUpAsync(selectModels, cancellationToken);


            return BaseProcess<BasePagingModel<ProductItemResponse>>.Success(response);
        }
    }
}
