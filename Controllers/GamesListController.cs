using Microsoft.AspNetCore.Mvc;
using TestAPIIgnat.Clients;
using TestAPIIgnat.Models; 

namespace TestAPIIgnat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesListController : ControllerBase
    {
        [HttpGet(Name = "GetGamesList")]
        public async Task<ActionResult<List<GameData>>> GetGamesListAsync()
        {
            Client client = new Client();
            var res = await client.GetGamesListAsync();
            return Ok(res);
        }
    }
}
