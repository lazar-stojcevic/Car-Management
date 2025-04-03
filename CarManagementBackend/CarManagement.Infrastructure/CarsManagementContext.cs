using CarManagement.Application.Common;
using CarManagement.Domain;
using CarManagement.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarManagement.Infrastructure;

public class CarsManagementContext : DbContext, IDbContext
{
    public DbSet<Car> Cars { get; set; }

    public CarsManagementContext(DbContextOptions<CarsManagementContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var implementedConfigTypes = Assembly.GetExecutingAssembly()
        .GetTypes()
        .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.GetTypeInfo().ImplementedInterfaces
        .Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

        foreach (var configType in implementedConfigTypes)
        {
            dynamic config = Activator.CreateInstance(configType);
            modelBuilder.ApplyConfiguration(config);
        }

        modelBuilder.SeedData();
    }
}
