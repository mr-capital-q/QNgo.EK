using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using QNgo.EK.Abstractions;
using QNgo.EK.Engine;
using QNgo.EK.Engine.GameActions.CardActions;
using QNgo.EK.Engine.GameActions.PlayerActions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace QNgo.EK.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddTransient<TurnEngine>();
            builder.Services.AddTransient<IGameState, GameState>();
            builder.Services.AddTransient<IGameActionResolver, GameActionResolver>();
            builder.Services.AddTransient<ICardResolver, CardResolver>();

            builder.Services.AddTransient<DrawPlayerAction>();
            builder.Services.AddTransient<SkipCardAction>();
            builder.Services.AddTransient<ShuffleCardAction>();
            builder.Services.AddTransient<PeekDeckCardAction>();
            builder.Services.AddTransient<AlterDeckCardAction>();

            await builder.Build().RunAsync();
        }
    }
}
