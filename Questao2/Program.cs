using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

public class Program
{
    private static readonly HttpClient client = new HttpClient();
    public static async Task  Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        int totalGoals = 0;
        int page = 1;
        bool hasMorePages = true;

        while (hasMorePages)
        {
            string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={Uri.EscapeDataString(team)}&page={page}";
            var response = await client.GetStringAsync(url);
            var json = JObject.Parse(response);
            var matches = json["data"];

            foreach (var match in matches)
            {
                totalGoals += (int)match["team1goals"];
            }

            
            hasMorePages = page < (int)json["total_pages"];
            page++;
        }

        
        page = 1;
        hasMorePages = true;

        while (hasMorePages)
        {
            string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={Uri.EscapeDataString(team)}&page={page}";
            var response = await client.GetStringAsync(url);
            var json = JObject.Parse(response);
            var matches = json["data"];

            foreach (var match in matches)
            {
                totalGoals += (int)match["team2goals"];
            }

            hasMorePages = page < (int)json["total_pages"];
            page++;
        }

        return totalGoals;
    }
}