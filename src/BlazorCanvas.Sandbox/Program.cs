using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Assets;
using BlazorCanvas.Core.Assets.Loaders;
using BlazorCanvas.Sandbox.Game;
using BlazorCanvas.Sandbox.Game.Builders;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorCanvas.Sandbox
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IAssetResolver, AssetResolver>();
            builder.Services.AddSingleton<IAssetLoader<Sprite>, SpriteAssetLoader>();
            builder.Services.AddSingleton<IAssetLoader<SpriteSheet>, SpriteSheetAssetLoader>();
            builder.Services.AddSingleton<IAssetLoaderFactory>(ctx =>
            {
                var factory = new AssetLoaderFactory();

                factory.Register(ctx.GetRequiredService<IAssetLoader<Sprite>>());
                factory.Register(ctx.GetRequiredService<IAssetLoader<SpriteSheet>>());

                return factory;
            });


            builder.Services.AddSingleton<InputService>();
            builder.Services.AddTransient<PathFollowerCarObjectBuilder>();
            builder.Services.AddTransient<UserControlledCarObjectBuilder>();
            builder.Services.AddTransient<SandboxGameFacade>();

            await builder.Build().RunAsync();
        }
    }
}
