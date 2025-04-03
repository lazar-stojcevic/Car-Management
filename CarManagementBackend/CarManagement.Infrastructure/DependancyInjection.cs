using CarManagement.Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarManagement.Infrastructure;

public static class DependancyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //Needs to be moved to appsettings
        services.AddDbContext<CarsManagementContext>(
            options => options.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CarManagementDb;Integrated Security=SSPI;"));

        services.AddScoped<IDbContext>(provider => provider.GetRequiredService<CarsManagementContext>());

        return services;
    }
}
