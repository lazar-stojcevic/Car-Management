using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarManagement.Application.Common;
using CarManagement.Application.Extensions;
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

    public class RequestHandler(IMapper mapper, IDbContext dbContext) : IRequestHandler<Request, PagedResponse<Response.Item>>
    {
        public Task<PagedResponse<Response.Item>> Handle(Request request, CancellationToken cancellationToken) => dbContext.Cars
                .ProjectTo<Response.Item>(mapper.ConfigurationProvider, cancellationToken)
                .ToPagedResponseAsync(request, cancellationToken);
    }
}
