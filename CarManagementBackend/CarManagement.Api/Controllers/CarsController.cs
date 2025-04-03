using CarManagement.Application.Cars;
using CarManagement.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    private readonly IMediator _mediatr;
    public CarsController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet(Name = "GetCars")]
    public async Task<ActionResult<PagedResponse<GetCars.Response.Item>>> GetPaged([FromQuery] GetCars.Request request)
    {
        var result = await _mediatr.Send(request);
        return result;
    }
}
