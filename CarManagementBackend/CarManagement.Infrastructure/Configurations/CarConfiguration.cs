using CarManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarManagement.Infrastructure.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Manufacturer).IsRequired().HasMaxLength(255);
        builder.Property(x => x.ModelName).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Year).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Color).IsRequired().HasMaxLength(255);
    }
}
