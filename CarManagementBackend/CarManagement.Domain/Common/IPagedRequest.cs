namespace CarManagement.Domain.Common;

public interface IPagedRequest
{
    int PageNumber { get; set; }
    int PageSize { get; set; }
}
