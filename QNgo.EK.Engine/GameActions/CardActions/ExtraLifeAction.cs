using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions.CardActions
{
    public class ExtraLifeAction : IGameAction
    {
        private const CardFamily CostCardFamily = CardFamily.ExtraLife;
        private const CardFamily ReturnCardFamily = CardFamily.Lose;
        private readonly ILogger _logger;

        public ExtraLifeAction(ILogger<ExtraLifeAction> logger = null)
        {
            _logger = logger;
        }

        public Task ExecuteActionAsync(int playerId, IGameState gameState, IActionCost actionCost)
        {
            _logger?.LogInformation("Using extra life and returning lose card.");

            if (actionCost is null)
                throw new ArgumentNullException(nameof(actionCost));

            if (actionCost.Cards.Count != 2)
                throw new InvalidOperationException("Action cost for an extra life action must be two cards.");

            var playedCard = actionCost.Cards.First();
            if (playedCard.Family != CostCardFamily)
                throw new InvalidOperationException($"Action requires a cost of one card from family {CostCardFamily} and must be the first action cost card.");

            var loseCard = actionCost.Cards.ElementAt(1);
            if (loseCard.Family != ReturnCardFamily)
                throw new InvalidOperationException($"Action requires a cost of one card from family {ReturnCardFamily} and must be the second action cost card.");

            var player = gameState.Players.Single(p => p.PlayerId == playerId);

            player.RemoveCard(playedCard.CardId);
            gameState.DiscardCard(playedCard);

            // TODO: Let player choose where instead of randomly.
            player.RemoveCard(loseCard.CardId);
            gameState.ReturnToDeck(loseCard, new Random().Next(gameState.Deck.Count + 1));
            return Task.CompletedTask;
        }
    }
}
