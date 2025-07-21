using web_client.Models.Base;

namespace web_client.Application.IServices;

public interface ILookupAppService
{
    Task<BaseProcess<int>> GetLookUpAsync(List<BaseSelectModel> request, CancellationToken cancellationToken);
}
