using Blazor.IndexedDB.WebAssembly;
using BlazorDownloadFile;
using ForeSins.App.Database;
using ForeSins.App.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ForeSins.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMudServices();

            builder.Services.AddBlazorDownloadFile();

            builder.Services.AddTransient<Grader>();
            builder.Services.AddTransient<HorndicapService>();
            builder.Services.AddTransient<DownloadService>();

            builder.Services.AddTransient<RoundRepository>();
            builder.Services.AddScoped<IIndexedDbFactory, IndexedDbFactory>();

            //builder.Services.AddOidcAuthentication(options =>
            //{
            //    // Configure your authentication provider options here.
            //    // For more information, see https://aka.ms/blazor-standalone-auth
            //    builder.Configuration.Bind("Local", options.ProviderOptions);
            //});

            await builder.Build().RunAsync();
        }
    }
}
