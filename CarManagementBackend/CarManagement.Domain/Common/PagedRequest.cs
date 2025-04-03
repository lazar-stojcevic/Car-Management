using MediatR;

namespace CarManagement.Domain.Common;

public class PagedRequest<TResponse> : IRequest<PagedResponse<TResponse>>, IPagedRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
