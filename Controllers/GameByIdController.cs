using Microsoft.AspNetCore.Mvc;
using TestAPIIgnat.Clients;
using TestAPIIgnat.Models;

namespace TestAPIIgnat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameByIdController : ControllerBase
    {
        [HttpGet(Name = "GetGameById")]
        public async Task<ActionResult<GameData>> GetGameByIdAsync(string key)
        {
            Client client = new Client();
            var res = await client.GetGameByIdAsync(key);
            return Ok(res);
        }
    }
}