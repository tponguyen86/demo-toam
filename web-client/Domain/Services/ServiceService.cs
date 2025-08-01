using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Request.Services;
using web_client.Models.Response.Services;

namespace web_client.Domain.Services
{
    public class ServiceService : IServiceService
    {
        private readonly NetectManageContext _context;
        private readonly ILookupService _lookup;

        public ServiceService(NetectManageContext context, ILookupService lookup)
        {
            _context = context;
            _lookup = lookup;
        }

        public async Task<BaseProcess<ServiceDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
        {
            var result = await _context.CategoryDetails.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status == PredefineDataConst.Status.Key.Active && (x.PageKeyName == request.Code || x.Id == request.Id)).FirstOrDefaultAsync(cancellationToken);

            if (result == null)
                return BaseProcess<ServiceDetailResponse>.Success(null);

            var response = new ServiceDetailResponse(result);

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

            return BaseProcess<ServiceDetailResponse>.Success(response);
        }

        public async Task<BaseProcess<BasePagingModel<ServiceItemResponse>>> GetPagingAsync(ServicePagingRequest request, CancellationToken cancellationToken)
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
                query = query.Where(x => x.CategoryId == request.Category);
            }

            if (request?.FeaturedHasValue() == true)
            {
                query = query.Where(x => x.Hot == request.Featured);
            }

            var page = request?.GetPage() ?? 1;
            var pageSize = request?.GetPageSize() ?? 10;

            var pager = await query.OrderByDescending(x => x.CreatedAt).Paging(page, pageSize, cancellationToken);

            var resultItems = pager.Items.Select(x => new ServiceItemResponse(x)).ToList();

            var response = pager.GetPaging(resultItems);

            if (response.Items?.Any() != true)
                return BaseProcess<BasePagingModel<ServiceItemResponse>>.Success(response);

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

            return BaseProcess<BasePagingModel<ServiceItemResponse>>.Success(response);
        }

        public async Task<BaseProcess<List<ServiceItemResponse>>> GetRelativeAsync(Guid serviceId, CancellationToken cancellationToken)
        {
            var query = _context.CategoryDetails.Where(x => x.Status != PredefineDataConst.SystemStatus.Key.Delete && x.Status == PredefineDataConst.Status.Key.Active && x.Id != serviceId).AsQueryable();

            var resultItems = await query.OrderBy(r => Guid.NewGuid()).Take(5).ToListAsync(cancellationToken);
            var response = resultItems.Select(x => new ServiceItemResponse(x)).ToList();

            if (response?.Any() != true)
                return BaseProcess<List<ServiceItemResponse>>.Success(response);

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

            return BaseProcess<List<ServiceItemResponse>>.Success(response);
        }
    }
}
