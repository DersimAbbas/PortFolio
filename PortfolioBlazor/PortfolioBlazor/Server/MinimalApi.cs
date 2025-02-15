using PortfolioBlazor.Models;

namespace PortfolioBlazor.Server
{
    public class MinimalApi
    {
        private readonly HttpClient _httpClient;

        public MinimalApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TechsModel>> FetchTechsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7192/api/techs");
                var json = await response.Content.ReadAsStringAsync();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Raw JSON Response: {json}");
                Console.ResetColor();

                var techs = System.Text.Json.JsonSerializer.Deserialize<List<TechsModel>>(json);
                return techs ?? new List<TechsModel>();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error fetching techs: {ex.Message}");
                Console.ResetColor();
                return new List<TechsModel>();
            }
        }



        //public async Task<List<TechsModel>> FetchTechsAsync()
        //{
        //    try
        //    {
        //        var techsResponse = await _httpClient.GetFromJsonAsync<List<TechsModel>>(
        //            "https://localhost:7192/api/techs"
        //        );

        //        if (techsResponse == null || techsResponse.Count == 0)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("no data found in mongoDB.");
        //            Console.ResetColor();
        //            return new List<TechsModel>();
        //        }
        //        var techList = techsResponse
        //            .Select(t => new TechsModel
        //            {
        //                Tech = t.Tech,
        //                SkillLevel = t.SkillLevel,
        //                TechExperience = t.TechExperience,
        //            })
        //            .ToList();

        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.WriteLine($"Fetched {techList.Count} techs from MongoDB.");
        //        Console.ResetColor();
        //        return techList;
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine($"HTTP request failed: {ex.Message}");
        //        Console.ResetColor();
        //        return new List<TechsModel>();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        Console.ResetColor();
        //        return new List<TechsModel>();
        //    }
        //}
    }
}
