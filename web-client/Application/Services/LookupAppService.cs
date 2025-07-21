using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Base;

namespace web_client.Application.Services;

public class LookupAppService : ILookupAppService
{
    private readonly ILookupService _lookupService;

    public LookupAppService(ILookupService lookupService)
    {
        _lookupService = lookupService;
    }

    public Task<BaseProcess<int>> GetLookUpAsync(List<BaseSelectModel> request, CancellationToken cancellationToken)
    => _lookupService.GetLookUpAsync(request, cancellationToken);
}
