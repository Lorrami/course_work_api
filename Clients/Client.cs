using System.Text.Json;
using Newtonsoft.Json.Linq;
using TestAPIIgnat.Models;

namespace TestAPIIgnat.Clients
{
    public class Client
    {
        List<string> keys = new List<string>()
        {
            "440",    //1. Team Fortress 2
            "730",    //2. CS GO
            "291480", //3. Warface
            "620",    //4. Portal 2
            "292030", //5. The Witcher 3
            "1091500",//6. Cyberpunk 2077
            "386180", //7. Crossout
            "1174180",//8. RDR 2
            "1551360",//9. Forza Horizon 5
            "298110", //10. Far Cry 4
        };
        public async Task<List<GameData>> GetGamesListAsync()
        {
            if (LocalData.LocalData.GameDataList.Count == 0)
            {
                foreach (var key in keys)
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(LocalData.LocalData.Address + key),
                        Headers =
                        {
                            { "X-RapidAPI-Host", LocalData.LocalData.Host },
                            { "X-RapidAPI-Key", LocalData.LocalData.Key },
                        },
                    };
                    var response = await client.SendAsync(request);
                    var body = await response.Content.ReadAsStringAsync();

                    var details = JObject.Parse(body);
                    var result = details[key]?.ToObject<GameData>();
                    if (result != null)
                    {
                        result.Data.Id = Convert.ToInt32(key);
                        result.Data.Pc_Requirements?.Parser();
                        LocalData.LocalData.GameDataList.Add(result);
                    }
                }
            }
            return LocalData.LocalData.GameDataList;
        }

        public async Task<GameData> GetGameByIdAsync(string key)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(LocalData.LocalData.Address + key),
                Headers =
                {
                    { "X-RapidAPI-Host", LocalData.LocalData.Host },
                    { "X-RapidAPI-Key", LocalData.LocalData.Key },
                },
            };
            var response = await client.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            var details = JObject.Parse(body);
            var result = details[key]?.ToObject<GameData>();
            if (result != null)
            {
                result.Data.Id = Convert.ToInt32(key);
                result.Data?.Pc_Requirements?.Parser();
                return result;
            }
            else return null;
        }

        public async Task<GameData> GetGameByUserParams()
        {
            GameData gameData = new GameData();
            await GetGamesListAsync();
            foreach (var game in LocalData.LocalData.GameDataList)
            {
                if (LocalData.LocalData.UserParameters.Graphics == game.Data.Pc_Requirements.MinimumGraphics &&
                    LocalData.LocalData.UserParameters.Processor == game.Data.Pc_Requirements.MinimumProcessor)
                {
                    gameData = game;
                    gameData.Data.Pc_Requirements.Level = "minimum processor and graphics";
                    gameData.Data.Pc_Requirements.Notes = "(Suitable for you by minimum!)";
                }
                else if (LocalData.LocalData.UserParameters.Graphics == game.Data.Pc_Requirements.RecommendedGraphics &&
                         LocalData.LocalData.UserParameters.Processor == game.Data.Pc_Requirements.RecommendedProcessor)
                {
                    gameData = game;
                    gameData.Data.Pc_Requirements.Level = "recommended processor and graphics";
                    gameData.Data.Pc_Requirements.Notes = "(The most suitable for you!)";
                }
                else if (game.Data.Pc_Requirements.MinimumGraphics != null && 
                    LocalData.LocalData.UserParameters.Graphics == game.Data.Pc_Requirements.MinimumGraphics)
                {
                    gameData = game;
                    gameData.Data.Pc_Requirements.Level = "minimum graphics";
                    gameData.Data.Pc_Requirements.Notes = "(could be some problems with your processor, be attentive!)";
                }
                else if (game.Data.Pc_Requirements.RecommendedGraphics != null &&
                         LocalData.LocalData.UserParameters.Graphics == game.Data.Pc_Requirements.RecommendedGraphics)
                {
                    gameData = game;
                    gameData.Data.Pc_Requirements.Level = "recommended graphics";
                    gameData.Data.Pc_Requirements.Notes = "(could be some problems with your processor, be attentive!)";
                }
                else if (game.Data.Pc_Requirements.MinimumProcessor != null && 
                         LocalData.LocalData.UserParameters.Processor == game.Data.Pc_Requirements.MinimumProcessor)
                {
                    gameData = game;
                    gameData.Data.Pc_Requirements.Level = "minimum processor";
                    gameData.Data.Pc_Requirements.Notes = "(could be some problems with your graphics, be attentive!)";
                }
                else if (game.Data.Pc_Requirements.RecommendedProcessor != null && 
                         LocalData.LocalData.UserParameters.Processor == game.Data.Pc_Requirements.RecommendedProcessor)
                {
                    gameData = game;
                    gameData.Data.Pc_Requirements.Level = "recommended processor";
                    gameData.Data.Pc_Requirements.Notes = "(could be some problems with your graphics, be attentive!)";
                }
            }
            //Console.WriteLine(gameData.Data.Name);
            return gameData;
        }
        public async Task<bool> PutUserParamsAsync(UserParams userParams)
        {
            LocalData.LocalData.UserParameters = userParams;
            Console.WriteLine(LocalData.LocalData.UserParameters.Graphics);
            Console.WriteLine(LocalData.LocalData.UserParameters.Processor);
            return true;
        }
        public async Task<bool> PutUserGenresAsync(List<string> genres)
        {
            LocalData.LocalData.UserGenres = genres;
            foreach (var genre in LocalData.LocalData.UserGenres)
            {
                Console.WriteLine(genre);
            }
            return true;
        }

        public async Task<List<GameData>> GetGamesByUserGenresAsync()
        {
            LocalData.LocalData.GamesByGenres.Clear();
            await GetGamesListAsync();
            foreach (var game in LocalData.LocalData.GameDataList)
            {
                foreach (var gamesGenre in game.Data.Genres)
                {
                    foreach (var genre in LocalData.LocalData.UserGenres)
                    {
                        if (LocalData.LocalData.GamesByGenres.Count <= 3 && gamesGenre.Description == genre)
                        {
                            bool found = false;
                            foreach (var gameFound in LocalData.LocalData.GamesByGenres)
                            {
                                if (gameFound.Data.Name == game.Data.Name)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                LocalData.LocalData.GamesByGenres.Add(game);
                            }
                        }
                    }
                }
            }
            foreach (var game in LocalData.LocalData.GameDataList)
            {
                foreach (var gamesGenre in game.Data.Categories)
                {
                    foreach (var genre in LocalData.LocalData.UserGenres)
                    {
                        if (LocalData.LocalData.GamesByGenres.Count <= 3 && gamesGenre.Description == genre)
                        {
                            bool found = false;
                            foreach (var gameFound in LocalData.LocalData.GamesByGenres)
                            {
                                if (gameFound.Data.Name == game.Data.Name)
                                {
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                LocalData.LocalData.GamesByGenres.Add(game);
                            }
                        }
                    }
                }
            }
            return LocalData.LocalData.GamesByGenres;
        }
    }
}
