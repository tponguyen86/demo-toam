using Microsoft.EntityFrameworkCore;
using web_client.Models.Base;
using web_client.Models.Htmls.Common;

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
            TotalCount = total,
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

    public static PagingComponent? BuildPaging(int? currentPage, int? totalPages, int? limit, string? urlFormat)
    {
        var paging = new PagingComponent
        {
            CurrentPage = currentPage ?? 0,
            TotalPages = totalPages ?? 0,
            Limit = limit ?? totalPages ?? 0,
            UrlFormat = urlFormat ?? "#",
        };

        var half = paging.Limit / 2;
        var start = Math.Max(1, paging.CurrentPage - half);
        var end = Math.Min(paging.TotalPages, start + paging.Limit - 1);

        // Adjust if too close to end
        if (end - start + 1 < limit && start > 1)
        {
            start = Math.Max(1, end - paging.Limit + 1);
        }

        // First & Prev
        if (currentPage > 1)
        {
            paging.Links.Add(new PagingItemComponent
            {
                Title = "<i class='fas fa-angle-double-left'></i>",
                Href = string.Format(urlFormat, 1)
            });
            paging.Links.Add(new PagingItemComponent
            {
                Title = "<i class='fas fa-angle-left'></i>",
                Href = string.Format(urlFormat, currentPage - 1)
            });
        }

        // Page numbers
        for (int i = start; i <= end; i++)
        {
            paging.Links.Add(new PagingItemComponent
            {
                Title = i.ToString(),
                Href = string.Format(urlFormat, i),
                IsActive = i == currentPage
            });
        }

        // Next & Last
        if (currentPage < totalPages)
        {
            paging.Links.Add(new PagingItemComponent
            {
                Title = "<i class='fas fa-angle-right'></i>",
                Href = string.Format(urlFormat, currentPage + 1)
            });
            paging.Links.Add(new PagingItemComponent
            {
                Title = "<i class='fas fa-angle-double-right'></i>",
                Href = string.Format(urlFormat, totalPages)
            });
        }

        return paging;
    }

    public static PagingComponent? BuildPaging<Titem>(this BasePagingModel<Titem>? model, string? urlFormat = null)
    {
        if (model == null || model.TotalCount <= 0)
            return null;
        return BuildPaging(model.PageIndex, model.TotalPage, 5, urlFormat);
    }
}
