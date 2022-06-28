using Microsoft.AspNetCore.Mvc;
using TestAPIIgnat.Clients;
using TestAPIIgnat.Models; 

namespace TestAPIIgnat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserParamsController : ControllerBase
    {
        [HttpPost(Name = "PutUserParams")]
        public async Task<ActionResult> PutUserParamsAsync(UserParams userParams)
        {
            var client = new Client();
            var res = await client.PutUserParamsAsync(userParams);
            return Ok(res);
        }
    }
}