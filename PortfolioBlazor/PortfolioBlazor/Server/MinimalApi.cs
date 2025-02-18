using ChartJs.Blazor.Common.Axes.Ticks;
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
    }
}
