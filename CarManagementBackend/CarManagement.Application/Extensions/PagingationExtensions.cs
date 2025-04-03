using CarManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Application.Extensions;

public static class PagingationExtensions
{
    public static async Task<PagedResponse<T>> ToPagedResponseAsync<T>(this IQueryable<T> query, IPagedRequest request,
    CancellationToken cancellationToken = default)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var pagedQuery = query;

        var skipPaging = request.PageSize == Int32.MaxValue;

        if (!skipPaging)
        {
            pagedQuery = pagedQuery.Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);
        }

        var items = await pagedQuery.ToListAsync(cancellationToken);

        var totalCount = skipPaging ? items.Count : await query.CountAsync(cancellationToken);

        return new PagedResponse<T>
        {
            Items = items,
            TotalCount = totalCount,
            PageSize = request.PageSize,
            PageNumber = request.PageNumber
        };
    }
}
