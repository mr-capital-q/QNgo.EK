using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions.CardActions
{
    public class SkipCardAction : SingleCardAction
    {
        private readonly ILogger _logger;

        public SkipCardAction(ILogger<SkipCardAction> logger = null)
        {
            _logger = logger;
        }
        
        protected override CardFamily RequiredCardFamily => CardFamily.Skip;

        protected override Task ExecuteActionCoreAsync(IGameState gameState)
        {
            _logger?.LogInformation("Skipping to turn end phase.");
            gameState.CurrentPhase = TurnPhase.TurnEnd;
            return Task.CompletedTask;
        }
    }
}
