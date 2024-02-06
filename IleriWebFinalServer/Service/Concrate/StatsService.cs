using Newtonsoft.Json;
using System.Text;
using WEBUI.Model;
using WEBUI.Service.Base;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static WEBUI.Service.Concrate.GamesService;

namespace WEBUI.Service.Concrate
{
	public class StatsService : IStatsService
	{
		public async Task<List<Stats>> GetAllStatsAsync()
		{
            var client = new HttpClient();

			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://free-nba.p.rapidapi.com/stats?page=0&per_page=100"),
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

                var responseObject = JsonConvert.DeserializeObject<StatsResponse>(body);

                var statsList = responseObject.data;

                return statsList;
            }
        }
        public class StatsResponse
        {
            public List<Stats> data { get; set; }
        }
    }
}
