using Microsoft.AspNetCore.Mvc;
using TestAPIIgnat.Clients;
using TestAPIIgnat.Models; 

namespace TestAPIIgnat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserGenresController : ControllerBase
    {
        [HttpPost(Name = "PutUserGenres")]
        public async Task<ActionResult> PutUserGenresAsync(List<string> genres)
        {
            var client = new Client();
            var res = await client.PutUserGenresAsync(genres);
            return Ok(res);
        }
    }
}