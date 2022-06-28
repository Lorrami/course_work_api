using TestAPIIgnat.Models;

namespace TestAPIIgnat.Clients;

public interface IDynamoDBClient
{
    public Task<List<GameData>> GetDataFromBD(string chatId);
    public Task<bool> PutGameIntoDB(string chatId, string key);
    public Task<bool> DeleteAllFromDB(string chatId);

}