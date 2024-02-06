using Newtonsoft.Json;
using Free_Nba_Blazor_Server_Project.Model;
using Free_Nba_Blazor_Server_Project.Service.Base;
using static Free_Nba_Blazor_Server_Project.Service.Concrate.TeamsService;

namespace Free_Nba_Blazor_Server_Project.Service.Concrate
{
	public class PlayersService : IPlayersService
	{
		public async Task<List<Players>> GetAllPlayersAsync(string search)
		{
			var client = new HttpClient();
			var baseUri = new Uri("https://free-nba.p.rapidapi.com/players?");

			// Conditionally append the search parameter if not empty
			var uriBuilder = new UriBuilder(baseUri);
			if (!string.IsNullOrEmpty(search))
			{
				uriBuilder.Query = $"search={search}";
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

			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();

				var responseObject = JsonConvert.DeserializeObject<PlayerResponse>(body);

				var playersList = responseObject.data;

				return playersList;
			}
		}

		public async Task<Players> GetSpecificPlayer(int id)
		{
			var client = new HttpClient();
			var baseUri = new Uri("https://free-nba.p.rapidapi.com/players");

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
                    var team = JsonConvert.DeserializeObject<Players>(body);

                    if (team != null)
                    {
                        return team;
                    }
                    else
                    {
                        new Players();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            return new Players();
        }
		public class PlayerResponse
        {
            public List<Players> data { get; set; }
        }
    }
}
