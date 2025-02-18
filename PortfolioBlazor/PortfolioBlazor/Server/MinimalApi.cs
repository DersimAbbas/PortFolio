using ChartJs.Blazor.Common.Axes.Ticks;
using PortfolioBlazor.Models;
using static System.Net.WebRequestMethods;

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


        public async Task AddTechAsync(TechsModel tech)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7192/api/newtech", tech);
        }

        public async Task UpdateTechAsync(string id, TechsModel tech)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7192/api/tech{id}", tech);
        }

        public async Task DeleteTechAsync(string id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7192/api/deletetech{id}");
        }
    }
}

