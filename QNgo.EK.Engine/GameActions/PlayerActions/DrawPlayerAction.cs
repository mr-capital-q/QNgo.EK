using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions.PlayerActions
{
    public class DrawPlayerAction : IGameAction
    {
        private readonly ILogger _logger;

        public DrawPlayerAction(ILogger<DrawPlayerAction> logger = null)
        {
            _logger = logger;
        }

        public Task ExecuteActionAsync(int playerId, IGameState gameState, IActionCost actionCost = null)
        {
            _logger?.LogInformation("Drawing a card...");
            var newCard = gameState.DrawCard();
            gameState.Players.Single(p => p.PlayerId == playerId).Cards.Add(newCard);

            if (newCard.Family == CardFamily.Lose)
                gameState.CurrentPhase = TurnPhase.Elimination;
            else
                gameState.CurrentPhase = TurnPhase.TurnEnd;
            return Task.CompletedTask;
        }
    }
}
