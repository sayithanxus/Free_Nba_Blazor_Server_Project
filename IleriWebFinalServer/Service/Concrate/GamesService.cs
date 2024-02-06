using Newtonsoft.Json;
using System.Text;
using WEBUI.Model;
using WEBUI.Service.Base;
using static WEBUI.Service.Concrate.PlayersService;
using static WEBUI.Service.Concrate.TeamsService;

namespace WEBUI.Service.Concrate
{
	public class GamesService : IGamesService
	{
		public async Task<List<Games>> GetAllGamesAsync(int team_ids, int Seasons)
		{
			var client = new HttpClient();

			var baseUri = new Uri("https://free-nba.p.rapidapi.com/games?");

			var uriBuilder = new UriBuilder(baseUri);
			var query = new StringBuilder();

			if (team_ids > 0)
			{
				query.Append($"team_ids={team_ids}");
			}

			if (Seasons > 0)
			{
				query.Append($"&Seasons={Seasons}");
			}

			uriBuilder.Query = query.ToString().TrimStart('&');

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = uriBuilder.Uri,
				Headers =
				{
					{ "X-RapidAPI-Key", "bad8fed98bmsh2e699934cbbb3a5p14ea83jsna1090435228b" },
					{ "X-RapidAPI-Host", "free-nba.p.rapidapi.com" },
				},
			};

			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();

				var responseObject = JsonConvert.DeserializeObject<GameResponse>(body);

				var gamesList = responseObject.data;

				return gamesList;
			}
		}

		public async Task<Games> GetSpecificGame(int id)
		{
			var client = new HttpClient();
			var baseUri = new Uri("https://free-nba.p.rapidapi.com/games");

			var uriBuilder = new UriBuilder(baseUri);
			if (id > 0)
			{
				uriBuilder.Path = $"{uriBuilder.Path}/{id}";
			}

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = uriBuilder.Uri,
				Headers =
				{
					{ "X-RapidAPI-Key", "bad8fed98bmsh2e699934cbbb3a5p14ea83jsna1090435228b" },
					{ "X-RapidAPI-Host", "free-nba.p.rapidapi.com" },
				},
			};

            try
            {
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    var game = JsonConvert.DeserializeObject<Games>(body);

                    if (game != null)
                    {
                        return game;
                    }
                    else
                    {
                        new Games();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            return new Games();
        }
		public class GameResponse
		{
			public List<Games> data { get; set; }
		}
	}
}
