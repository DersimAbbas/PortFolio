using System.Text.Json;
using PortfolioBlazor.Components;
using PortfolioBlazor.Components.Pages;
using PortfolioBlazor.Server;
using PortfolioBlazor.Services;

namespace PortfolioBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
            builder
                .Services.AddHttpClient(
                    "ApiClient",
                    client =>
                    {
                        client.BaseAddress = new Uri("Https://localhost:7192");
                    }
                )
                .ConfigureHttpClient(client =>
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                })
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler();
                });

            builder.Services.AddControllers();
            builder.Services.AddSingleton<TerminalServices>();

            builder.Services.Configure<JsonSerializerOptions>(options =>
            {
                options.PropertyNameCaseInsensitive = true; // ✅ This allows camelCase to map to PascalCase automatically
            });
            builder.Services.AddServerSideBlazor().AddCircuitOptions(options => options.DetailedErrors = true);
            builder.Services.AddScoped<MinimalApi>();
            builder.Services.AddBlazorBootstrap();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
            app.Run();
        }
    }
}
