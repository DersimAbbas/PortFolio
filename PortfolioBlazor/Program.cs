using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using PortfolioBlazor.Components;
using PortfolioBlazor.Components.Public.Controls;
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

            //identity to authorize admin page.

            builder.Services.AddAuthorizationCore();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<
                AuthenticationStateProvider,
                ServerAuthenticationStateProvider
            >();
            builder.Services.AddScoped<ChartModal>();
            builder.Services.AddSingleton<TerminalServices>();

            builder.Services.Configure<JsonSerializerOptions>(options =>
            {
                options.PropertyNameCaseInsensitive = true;
            });

            builder
                .Services.AddServerSideBlazor()
                .AddCircuitOptions(options => options.DetailedErrors = true);

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
