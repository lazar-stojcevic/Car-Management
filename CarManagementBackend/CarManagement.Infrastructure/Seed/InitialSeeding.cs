using CarManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Infrastructure.Seed;

public static class InitialSeeding
{
    public static void SeedData(this ModelBuilder builder)
    {
        builder.Entity<Car>().HasData(
        [
            new Car ()
            {
                Id = new Guid("e688880b-fe34-4362-8786-e4464744bf87"),
                Manufacturer = "Toyota",
                ModelName = "Corolla",
                Year = 2020,
                Color = "Red"
            },
            new Car
            {
                Id = new Guid("e688880b-fe34-4362-8786-e4464744bf88"),
                Manufacturer = "Honda",
                ModelName = "Civic",
                Year = 2019,
                Color = "Blue"
            },
            new Car
            {
                Id = new Guid("e688880b-fe34-4362-8786-e4464744bf89"),
                Manufacturer = "Ford",
                ModelName = "Mustang",
                Year = 2021,
                Color = "Black"
            }
        ]);
    }
}
