using Microsoft.EntityFrameworkCore;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Response.Pages.PageConfigurations;

namespace web_client.Domain.Services
{
    public class PageConfigurationService : IPageConfigurationService
    {
        private readonly NetectManageContext _context;

        public PageConfigurationService(NetectManageContext context)
        {
            _context = context;
        }
        public async Task<BaseProcess<List<BasePageConfigurationResponse>>> GetConfigByPageAsync(Guid pageId, CancellationToken cancellationToken)
        {
            if (!pageId.HasValueGuid())
                return BaseProcess<List<BasePageConfigurationResponse>>.Success(null);
            
            var pageConfiguration = await _context.PageConfigurations
                .Where(x => x.PageId == pageId && x.Status != PredefineDataConst.SystemStatus.Key.Delete)
                .OrderBy(x => x.Sort)
                .Select(x => new BasePageConfigurationResponse
                {
                    Name = x.Name,
                    Value = x.Value
                })
                .ToListAsync(cancellationToken: cancellationToken);
            return BaseProcess<List<BasePageConfigurationResponse>>.Success(pageConfiguration);
        }
    }
}
