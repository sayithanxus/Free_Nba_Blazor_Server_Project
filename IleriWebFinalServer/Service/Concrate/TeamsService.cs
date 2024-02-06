using System;
using WEBUI.Model;
using WEBUI.Service.Base;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.ComponentModel;

namespace WEBUI.Service.Concrate
{
    public class TeamsService : ITeamsService
    {
        public async Task<List<Teams>> GetAllTeamsAsync(string searchTerm)
        {
            var client = new HttpClient();
            var baseUri = new Uri("https://free-nba.p.rapidapi.com/teams?page=0&per_page=25");

            // Conditionally append the search parameter if not empty
            var uriBuilder = new UriBuilder(baseUri);
            if (!string.IsNullOrEmpty(searchTerm))
            {
                uriBuilder.Query = $"search={searchTerm}";
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

                var responseObject = JsonConvert.DeserializeObject<TeamsResponse>(body);

                var teamsList = responseObject.data;

                return teamsList;
            }
        }


        public async Task<Teams> GetSpecificTeam(int id)
        {
            var client = new HttpClient();
            var baseUri = new Uri("https://free-nba.p.rapidapi.com/teams");

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

                    var team = JsonConvert.DeserializeObject<Teams>(body);

                    if (team != null)
                    {
                        return team;
                    }
                    else
                    {
                        new Teams();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            return new Teams();
        }
        public class TeamsResponse
        {
            public List<Teams> data { get; set; }
        }
    }
}
