using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QNgo.EK.Abstractions;
using QNgo.EK.Engine;
using QNgo.EK.Engine.GameActions.CardActions;
using QNgo.EK.Engine.GameActions.PlayerActions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestRig
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<ConsoleApp>();

                    services.AddTransient<TurnEngine>();
                    services.AddTransient<IGameState, GameState>();
                    services.AddTransient<IGameActionResolver, GameActionResolver>();
                    services.AddTransient<ICardResolver, CardResolver>();

                    services.AddTransient<DrawPlayerAction>();
                    services.AddTransient<ExtraLifeAction>();
                    services.AddTransient<SkipCardAction>();
                    services.AddTransient<ShuffleCardAction>();
                    services.AddTransient<PeekDeckCardAction>();
                    services.AddTransient<AlterDeckCardAction>();
                });


            await builder.Build().RunAsync();
        }
    }

    public class ConsoleApp : IHostedService
    {
        private readonly IServiceProvider _services;

        public ConsoleApp(IServiceProvider services)
        {
            _services = services;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var engine = _services.GetRequiredService<TurnEngine>();
            await engine.StartGameAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
