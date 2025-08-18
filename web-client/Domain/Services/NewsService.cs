using Microsoft.EntityFrameworkCore;
using System.Linq;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Request.Categories.Details;
using web_client.Models.Request.News;
using web_client.Models.Response.News;

namespace web_client.Domain.Services
{
    public class NewsService : INewsService
    {
        private readonly NetectManageContext _context;
        private readonly ILookupService _lookup;

        public NewsService(NetectManageContext context, ILookupService lookup)
        {
            _context = context;
            _lookup = lookup;
        }

        public async Task<BaseProcess<NewsDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
        {
            var result = await _context.CategoryDetails.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status == PredefineDataConst.Status.Key.Active && (x.PageKeyName == request.Code || x.Id == request.Id)).FirstOrDefaultAsync(cancellationToken);

            if (result == null)
                return BaseProcess<NewsDetailResponse>.Success(null);

            var response = new NewsDetailResponse(result);

            //set look up
            var selectModels = new List<BaseSelectModel>();

            if (response.ParentIdModel != null)
                selectModels.Add(response.ParentIdModel);

            if (response.StatusModel != null)
                selectModels.Add(response.StatusModel);

            if (response.CreatedByModel != null)
                selectModels.Add(response.CreatedByModel);

            if (response.UpdatedByModel != null)
                selectModels.Add(response.UpdatedByModel);

            if (selectModels?.Any() == true)
                await _lookup.GetLookUpAsync(selectModels, cancellationToken);

            return BaseProcess<NewsDetailResponse>.Success(response);
        }

        public async Task<BaseProcess<BasePagingModel<NewsItemResponse>>> GetPagingAsync(NewsPagingRequest request, CancellationToken cancellationToken)
        {
            var query = _context.CategoryDetails.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status == PredefineDataConst.Status.Key.Active).AsQueryable();

            if (request?.HasKeySearch() == true)
            {
                string keySearch = request.GetKeySearch();
                query = query.Where(x => EF.Functions.ILike(EF.Functions.Unaccent(x.Name.ToLower()), $"%{keySearch}%"));
            }

            if (request?.HasStatus() == true)
            {
                query = query.Where(x => x.Status == request.Status);
            }

            if (request?.CategoryHasValue() == true)
            {
                var categoryIds = request.GetCategory();
                query = query.Where(x => categoryIds.Contains(x.CategoryId));
            }

            if (request?.FeaturedHasValue() == true)
            {
                query = query.Where(x => x.Hot == request.Featured);
            }

            var page = request?.GetPage() ?? 1;
            var pageSize = request?.GetPageSize() ?? 10;

            var pager = await query.OrderByDescending(x => x.CreatedAt).Paging(page, pageSize, cancellationToken);

            var resultItems = pager.Items.Select(x => new NewsItemResponse(x)).ToList();

            var response = pager.GetPaging(resultItems);

            if (response.Items?.Any() != true)
                return BaseProcess<BasePagingModel<NewsItemResponse>>.Success(response);

            //set look up
            var selectModels = new List<BaseSelectModel>();
            foreach (var item in response.Items)
            {
                if (item.ParentIdModel != null)
                    selectModels.Add(item.ParentIdModel);

                if (item.StatusModel != null)
                    selectModels.Add(item.StatusModel);

                if (item.CreatedByModel != null)
                    selectModels.Add(item.CreatedByModel);

                if (item.UpdatedByModel != null)
                    selectModels.Add(item.UpdatedByModel);
            }
            if (selectModels?.Any() == true)
                await _lookup.GetLookUpAsync(selectModels, cancellationToken);

            return BaseProcess<BasePagingModel<NewsItemResponse>>.Success(response);
        }

        public async Task<BaseProcess<List<NewsItemResponse>>> GetRelativeAsync(GetCategoryDetailRelativeRequest request, CancellationToken cancellationToken)
        {
            if (request?.Validate()!=true)
                return BaseProcess<List<NewsItemResponse>>.Success(null);

            var query = _context.CategoryDetails.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status == PredefineDataConst.Status.Key.Active && x.Id != request.Id).AsQueryable();

            if (request?.CategoryHasValue() == true)
            {
                var categoryIds = request.GetCategory();
                query = query.Where(x => categoryIds.Contains(x.CategoryId));
            }

            var resultItems = await query.OrderBy(r => Guid.NewGuid()).Take(request.PageSize).ToListAsync(cancellationToken);
            var response = resultItems.Select(x => new NewsItemResponse(x)).ToList();

            if (response?.Any() != true)
                return BaseProcess<List<NewsItemResponse>>.Success(response);

            //set look up
            var selectModels = new List<BaseSelectModel>();
            foreach (var item in response)
            {
                if (item.ParentIdModel != null)
                    selectModels.Add(item.ParentIdModel);

                if (item.StatusModel != null)
                    selectModels.Add(item.StatusModel);

                if (item.CreatedByModel != null)
                    selectModels.Add(item.CreatedByModel);

                if (item.UpdatedByModel != null)
                    selectModels.Add(item.UpdatedByModel);
            }
            if (selectModels?.Any() == true)
                await _lookup.GetLookUpAsync(selectModels, cancellationToken);

            return BaseProcess<List<NewsItemResponse>>.Success(response);
        }
    }
}
