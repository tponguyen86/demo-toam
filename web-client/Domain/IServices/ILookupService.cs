using web_client.Models.Base;

namespace web_client.Domain.IServices;

public interface ILookupService
{
    Task<BaseProcess<int>> GetLookUpAsync(List<BaseSelectModel> request, CancellationToken cancellationToken);
}
