using Microsoft.AspNetCore.Mvc;
using TestAPIIgnat.Clients;
using TestAPIIgnat.LocalData;
using TestAPIIgnat.Models;

namespace TestAPIIgnat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetGameByUserGenres : ControllerBase
    {
        [HttpGet(Name = "GetGamesByUserGenres")]
        public async Task<ActionResult<List<GameData>>> GetGameByUserGenresAsync()
        {
            Client client = new Client();
            var res = await client.GetGamesByUserGenresAsync();
            return Ok(res);
        }
    }
}