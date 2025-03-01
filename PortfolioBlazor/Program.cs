using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using PortfolioBlazor.Components;
using PortfolioBlazor.Components.Public.Controls;
using PortfolioBlazor.Server;
using PortfolioBlazor.Services;
using System.Text.Json;

namespace PortfolioBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
            var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
            builder.Services.AddScoped(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var baseAddress = config["ApiBaseUrl"]; // Read from appsettings.json
                return new HttpClient { BaseAddress = new Uri(baseAddress) };
            });
            /*builder
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
                });*/

            //identity to authorize admin page.
            builder.Services.AddAuthentication();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<
                AuthenticationStateProvider,
                ServerAuthenticationStateProvider
            >();
            //builder.Services.AddScoped<AuthenticationStateProvider>();

            //builder.Services.AddScoped<ServerAuthenticationStateProvider>();

            builder.Services.AddScoped<ChartModal>();

            builder.Services.AddScoped<TerminalServices>();

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
