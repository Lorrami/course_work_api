using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Mvc;
using TestAPIIgnat.Clients;
using TestAPIIgnat.LocalData;
using TestAPIIgnat.Models;

namespace TestAPIIgnat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DynamoDbController : ControllerBase
    {
        private readonly IDynamoDBClient _dynamoDbClient;
        public DynamoDbController(IDynamoDBClient dynamoDbClient)
        {
            _dynamoDbClient = dynamoDbClient;
        }
        [HttpGet(Name = "GetFromDB")]
        public async Task<ActionResult<List<GameData>>> GetDataFromBdAsync(string chatId)
        { 
            var result = await _dynamoDbClient.GetDataFromBD(chatId);
            return Ok(result);
        }
        [HttpPut(Name = "PutIntoDB")]
        public async Task<ActionResult<bool>> PutDataIntoBD(string chatId, string key)
        { 
            var result = await _dynamoDbClient.PutGameIntoDB(chatId, key);
            return Ok(result);
        }
        [HttpDelete(Name = "DeleteFromDB")]
        public async Task<ActionResult<bool>> DeleteAllFromBD(string chatId)
        { 
            var result = await _dynamoDbClient.DeleteAllFromDB(chatId);
            return Ok(result);
        }
    }
}