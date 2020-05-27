using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions.CardActions
{
    public class ShuffleCardAction : SingleCardAction
    {
        private readonly ILogger _logger;

        public ShuffleCardAction(ILogger<ShuffleCardAction> logger = null)
        {
            _logger = logger;
        }

        protected override CardFamily RequiredCardFamily => CardFamily.Shuffle;

        protected override Task ExecuteActionCoreAsync(IGameState gameState)
        {
            _logger?.LogInformation("Shuffling deck.");
            gameState.ShuffleDeck();
            return Task.CompletedTask;
        }
    }
}
