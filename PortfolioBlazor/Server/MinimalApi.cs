using ChartJs.Blazor.Common.Axes.Ticks;
using Microsoft.JSInterop;
using PortfolioBlazor.Models;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace PortfolioBlazor.Server
{
    public class MinimalApi
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        public MinimalApi(HttpClient httpClient, IJSRuntime jsruntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsruntime;
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

        public async Task<List<TechsModel>> FetchProjectsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7192/api/projects");
                var json = await response.Content.ReadAsStringAsync();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Raw JSON Response: {json}");
                Console.ResetColor();

                var project = System.Text.Json.JsonSerializer.Deserialize<List<TechsModel>>(json);
                return project ?? new List<TechsModel>();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error fetching techs: {ex.Message}");
                Console.ResetColor();
                return new List<TechsModel>();
            }
        }



        public async Task<bool> AddTechAsync(TechsModel newTech)
        {
            try
            {
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
                if (!string.IsNullOrEmpty(token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = await _httpClient.PostAsJsonAsync("https://localhost:7192/api/newtech", newTech);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding tech: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateTechAsync(string id, TechsModel updatedTech)
        {
            try
            {
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
                if (!string.IsNullOrEmpty(token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = await _httpClient.PutAsJsonAsync($"https://localhost:7192/api/updatetech/{id}", updatedTech);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating tech: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteTechAsync(string id)
        {
            try
            {
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
                if (!string.IsNullOrEmpty(token))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = await _httpClient.DeleteAsync($"https://localhost:7192/api/deletetech{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting tech: {ex.Message}");
                return false;
            }
        }

    }
}

