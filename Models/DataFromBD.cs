using Amazon.DynamoDBv2.DataModel;

namespace TestAPIIgnat.Models;

public class DataFromBD
{
    public string UserID { get; set; }
    public List<string> GameIDList { get; set; }
}