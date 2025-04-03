using CarManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Application.Common;

public interface IDbContext
{
    DbSet<Car> Cars { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
