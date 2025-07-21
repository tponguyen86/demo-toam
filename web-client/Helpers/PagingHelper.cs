using Microsoft.EntityFrameworkCore;
using web_client.Models.Base;

namespace web_client.Helpers;


public static class PagingHelper
{
    public static async Task<BasePagingModel<T>> Paging<T>(this IQueryable<T> queryable, int pageIndex, int pageSize, CancellationToken cancellationToken)
    {
        if (pageIndex < 1)
        {
            pageIndex = 1;
        }
        pageIndex--;
        if (pageSize < 1)
        {
            pageSize = 10;
        }
        var total = await queryable.CountAsync(cancellationToken);
        var items = await queryable
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
        return new BasePagingModel<T>
        {
            Items = items,
            PageIndex = pageIndex + 1,
            PageSize = pageSize,
            TotalCount = total
        };
    }
    public static BasePagingModel<TNew> GetPaging<TOld, TNew>(this BasePagingModel<TOld>? source, IEnumerable<TNew>? newItems)
    {
        return new BasePagingModel<TNew>
        {
            Items = newItems,
            PageIndex = source?.PageIndex ?? (newItems?.Any() == true ? 1 : 0),
            PageSize = source?.PageSize ?? (newItems?.Count() ?? 10),
            TotalCount = source?.TotalCount ?? (newItems?.Count() ?? 0)
        };
    }
}
