using AutoMapper;
using CarManagement.Application.Cars;
using CarManagement.Application.Common;
using CarManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Moq;

public class GetCarsHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IDbContext> _dbContextMock;
    private readonly GetCars.RequestHandler _handler;

    public GetCarsHandlerTests()
    {
        var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new GetCars.Response.Mapping()));
        _mapper = mapperConfig.CreateMapper();

        _dbContextMock = new Mock<IDbContext>();
        _handler = new GetCars.RequestHandler(_mapper, _dbContextMock.Object);
    }

    [Test]
    public async Task Handle_ReturnsPagedResponse()
    {
        var cars = new List<Car>
        {
            new Car { Id = Guid.NewGuid(), Manufacturer = "Tesla", ModelName = "Model S", Year = 2022, Color = "Red", IsElectric = true },
            new Car { Id = Guid.NewGuid(), Manufacturer = "BMW", ModelName = "i4", Year = 2023, Color = "Blue", IsElectric = true }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Car>>();
        mockSet.As<IQueryable<Car>>().Setup(m => m.Provider).Returns(cars.Provider);
        mockSet.As<IQueryable<Car>>().Setup(m => m.Expression).Returns(cars.Expression);
        mockSet.As<IQueryable<Car>>().Setup(m => m.ElementType).Returns(cars.ElementType);
        mockSet.As<IQueryable<Car>>().Setup(m => m.GetEnumerator()).Returns(cars.GetEnumerator());

        _dbContextMock.Setup(db => db.Cars).Returns(mockSet.Object);

        var request = new GetCars.Request { PageNumber = 1, PageSize = 10 };

        var result = await _handler.Handle(request, CancellationToken.None);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Items.Count, Is.EqualTo(2));
    }
}
