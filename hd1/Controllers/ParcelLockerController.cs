using hd1.Services;
using Microsoft.AspNetCore.Mvc;

namespace hd1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParcelLockerController : ControllerBase
{
    private readonly IParcelLockerService _parcelLockerService;

    public ParcelLockerController(IParcelLockerService parcelLockerService)
    {
        _parcelLockerService = parcelLockerService;
    }

    // GET: api/<ParcelLockerController>
    [HttpGet]
    public IActionResult Get()
    {
        return _parcelLockerService.GetActiveParcelLockers() switch
        {
            var items when items.Any() => Ok(items),
            _ => NotFound(),
        };
    }

    // GET api/<ParcelLockerController>/5
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        return _parcelLockerService.GetParcelLocker(id) switch
        {
            { } locker => Ok(locker),
            _ => NotFound(),
        };
    }
}

