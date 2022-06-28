using TestAPIIgnat.Models;

namespace TestAPIIgnat.LocalData;

public class LocalData
{
    public static List<GameData> GamesFromDB = new List<GameData>();
    
    public static UserParams UserParameters = new UserParams();
    public static List<GameData> GameDataList = new List<GameData>();
    public static List<GameData> GamesByGenres = new List<GameData>();
    public static List<string> UserGenres = new List<string>();
    public static string Address = "https://steam-store-data.p.rapidapi.com/api/appdetails/?appids=";
    public static string Host = "steam-store-data.p.rapidapi.com";
    public static string Key = "d8badaf485msh48b872bd56c858fp16cfd7jsn489572f21be7";

    public static string DBKey = "AKIAVYVX23XJ7FMV3QXS";
    public static string DBSecret = "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";
}