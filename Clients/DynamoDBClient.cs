using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TestAPIIgnat.Extensions;
using TestAPIIgnat.Models;

namespace TestAPIIgnat.Clients
{

    public class DynamoDBClient : IDynamoDBClient
    {
        private readonly IAmazonDynamoDB _dynamoDb;

        public DynamoDBClient(IAmazonDynamoDB dynamoDb)
        {
            _dynamoDb = dynamoDb;
        }
        public async Task<List<GameData>> GetDataFromBD(string chatId)
        {
            var tableName = "game_bot_bd";
            var item = new GetItemRequest()
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "UserID", new AttributeValue { S = chatId } },
                }
            };
            var response = _dynamoDb.GetItemAsync(item);
            var result = response.Result;
            var shit = result.Item;
            var listOfKeys = new List<string>();
            foreach (var obj in shit)
            {
                if (obj.Key == "GameIDList")
                {
                    foreach (var key in obj.Value.SS)
                    {
                        listOfKeys.Add(key);
                    }
                }
            }

            Client client = new Client();
            LocalData.LocalData.GamesFromDB.Clear();
            foreach (var gameId in listOfKeys)
            {
                var gameFromApi = client.GetGameByIdAsync(gameId);
                var game = gameFromApi.Result;
                LocalData.LocalData.GamesFromDB.Add(game);
            }
            
            return LocalData.LocalData.GamesFromDB;
        }

        public async Task<bool> PutGameIntoDB(string chatId, string key)
        {
            var tableName = "game_bot_bd";
            var request = new UpdateItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string,AttributeValue>() { { "UserID", new AttributeValue { S = chatId } } },
                ExpressionAttributeNames = new Dictionary<string, string>()
                {
                    {"#A", "GameIDList"},
                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
                {
                    {":auth", new AttributeValue { SS = { key } } },
                },
                UpdateExpression = "ADD #A :auth"
            };
            var response = await _dynamoDb.UpdateItemAsync(request);
            return true;
        }
        public async Task<bool> DeleteAllFromDB(string chatId)
        {
            var tableName = "game_bot_bd";
            var request = new DeleteItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "UserID", new AttributeValue { S = chatId } } },
            };

            var response = await _dynamoDb.DeleteItemAsync(request);
            return true;
        }
    }
}