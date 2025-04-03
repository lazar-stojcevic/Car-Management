using AutoMapper;
using CarManagement.Domain;
using CarManagement.Domain.Common;
using MediatR;

namespace CarManagement.Application.Cars;

public static class GetCars
{
    public class Request : PagedRequest<Response.Item>;

    public class Response
    {
        public class Item
        {
            public Guid Id { get; set; }
            public string Manufacturer { get; set; } = string.Empty;
            public string ModelName { get; set; } = string.Empty;
            public uint Year { get; set; }
            public string Color { get; set; } = string.Empty;
            public bool IsElectric { get; set; }
        }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Car, Item>();
            }
        }
    }

    public class RequestHandler : IRequestHandler<Request, PagedResponse<Response.Item>>
    {
        public Task<PagedResponse<Response.Item>> Handle(Request request, CancellationToken cancellationToken)
        {
            var car = new Response.Item() { Color = "blue", IsElectric = false, Manufacturer = "Toyota", ModelName = "Jaris", Year = 2020 };
            var car1 = new Response.Item() { Color = "blue2", IsElectric = false, Manufacturer = "Toyota2", ModelName = "Jaris2", Year = 2020 };
            var car2 = new Response.Item() { Color = "blue3", IsElectric = false, Manufacturer = "Toyota3", ModelName = "Jaris3", Year = 2020 };
            var cars = new List<Response.Item>() { car, car1, car2 };
            var response = new PagedResponse<Response.Item>
            {
                Items = cars,
                TotalCount = cars.Count,
                PageNumber = 1,
                PageSize = 10
            };
            return Task.FromResult(response);
        }
    }
}
