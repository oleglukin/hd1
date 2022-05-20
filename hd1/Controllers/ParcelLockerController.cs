using Microsoft.AspNetCore.Mvc;

namespace hd1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParcelLockerController : ControllerBase
{
    // GET: api/<ParcelLockerController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<ParcelLockerController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ParcelLockerController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ParcelLockerController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ParcelLockerController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

