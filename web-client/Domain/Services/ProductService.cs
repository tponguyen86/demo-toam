using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Data.Contexts.Entities;
using web_client.Models.Request.Categories.Details;
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
        public async Task<BaseProcess<ProductDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status == PredefineDataConst.Status.Key.Active && (x.PageKeyName == request.Code || x.Id == request.Id)).FirstOrDefaultAsync(cancellationToken);

            if (result == null)
                return BaseProcess<ProductDetailResponse>.Success(null);

            var response = new ProductDetailResponse(result);

            //set look up
            var selectModels = new List<BaseSelectModel>();
            if (response.ProductCategoryModel != null)
                selectModels.Add(response.ProductCategoryModel);

            if (response.GroupProductSettingModel != null)
                selectModels.Add(response.GroupProductSettingModel);

            if (response.StatusModel != null)
                selectModels.Add(response.StatusModel);

            if (response.CreatedByModel != null)
                selectModels.Add(response.CreatedByModel);

            if (response.UpdatedByModel != null)
                selectModels.Add(response.UpdatedByModel);

            if (selectModels?.Any() == true)
                await _lookup.GetLookUpAsync(selectModels, cancellationToken);

            return BaseProcess<ProductDetailResponse>.Success(response);
        }

        public async Task<BaseProcess<BasePagingModel<ProductItemResponse>>> GetPagingAsync(ProductPagingRequest request, CancellationToken cancellationToken)
        {
            var query = _context.Products.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status == PredefineDataConst.Status.Key.Active).AsQueryable();

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
                var categoryIds = request.GetCategory();
                query = query.Where(x => categoryIds.Contains(x.ProductCategory));
            }

            if (request?.FeaturedHasValue() == true)
            {
                query = query.Where(x => x.Featured == request.Featured);
            }

            //atributes
            var attributes = request?.GetAttributes();
            if (attributes?.Any() == true)
            {
                var parameter = Expression.Parameter(typeof(Product), "u");
                Expression? body = null;
                foreach (var cond in attributes)
                {
                    var json = $@"{{ ""Properties"": {{ ""{cond.Key}"": {{ ""Value"": {(
                        cond.Value is string ? $"\"{cond.Value}\"" : cond.Value.ToString())} }}}} }}";

                    // EF.Functions.JsonContains(u.Data, json)
                    var call = Expression.Call(
                        typeof(NpgsqlJsonDbFunctionsExtensions),
                        nameof(NpgsqlJsonDbFunctionsExtensions.JsonContains),
                        Type.EmptyTypes,
                        Expression.Property(null, typeof(EF), nameof(EF.Functions)),
                        Expression.Property(parameter, nameof(Product.Attribute)),
                        Expression.Constant(json));

                    body = body == null ? call : Expression.OrElse(body, call);
                }
                var lambda = Expression.Lambda<Func<Product, bool>>(body!, parameter);
                query = query.Where(lambda);

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
                if (item.ProductCategoryModel != null)
                    selectModels.Add(item.ProductCategoryModel);  
                
                if (item.AttributeModel != null)
                {
                    foreach (var prop in item.AttributeModel.PropertiesModel)
                    {
                        if (prop.Value.PropertiesModelKey!=null)
                            selectModels.Add(prop.Value.PropertiesModelKey);
                        
                        if (prop.Value.ValueModel!=null)
                            selectModels.Add(prop.Value.ValueModel);
                    }
                }

                if (item.GroupProductSettingModel != null)
                    selectModels.Add(item.GroupProductSettingModel);

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

        public async Task<BaseProcess<List<ProductItemResponse>>> GetRelativeAsync(GetCategoryDetailRelativeRequest request, CancellationToken cancellationToken)
        {
            if (request?.Validate() != true)
                return BaseProcess<List<ProductItemResponse>>.Success(null);

            var query = _context.Products.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status == PredefineDataConst.Status.Key.Active && x.Id != request.Id).AsQueryable();

            if (request?.CategoryHasValue() == true)
            {
                var categoryIds = request.GetCategory();
                query = query.Where(x => categoryIds.Contains(x.ProductCategory));
            }

            var resultItems = await query.OrderBy(r => Guid.NewGuid()).Take(request.PageSize).ToListAsync(cancellationToken);
            var response = resultItems.Select(x => new ProductItemResponse(x)).ToList();

            if (response?.Any() != true)
                return BaseProcess<List<ProductItemResponse>>.Success(response);

            //set look up
            var selectModels = new List<BaseSelectModel>();
            foreach (var item in response)
            {
                if (item.ProductCategoryModel != null)
                    selectModels.Add(item.ProductCategoryModel);

                if (item.GroupProductSettingModel != null)
                    selectModels.Add(item.GroupProductSettingModel);

                if (item.StatusModel != null)
                    selectModels.Add(item.StatusModel);

                if (item.CreatedByModel != null)
                    selectModels.Add(item.CreatedByModel);

                if (item.UpdatedByModel != null)
                    selectModels.Add(item.UpdatedByModel);
            }
            if (selectModels?.Any() == true)
                await _lookup.GetLookUpAsync(selectModels, cancellationToken);

            return BaseProcess<List<ProductItemResponse>>.Success(response);
        }
    }
}
