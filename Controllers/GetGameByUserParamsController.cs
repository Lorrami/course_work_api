using Microsoft.AspNetCore.Mvc;
using TestAPIIgnat.Clients;
using TestAPIIgnat.Models; 

namespace TestAPIIgnat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetGameByUserParamsController : ControllerBase
    {
        [HttpGet(Name = "GetGameByUserParams")]
        public async Task<ActionResult<GameData>> GetGameByUserParamsAsync()
        {
            Client client = new Client();
            var res = await client.GetGameByUserParams();
            return Ok(res);
        }
    }
}
