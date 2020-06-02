using QNgo.EK.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions.CardActions
{
    public abstract class SingleCardAction : IGameAction
    {
        public Task ExecuteActionAsync(int playerId, IGameState gameState, IActionCost actionCost)
        {
            if (actionCost is null)
                throw new ArgumentNullException(nameof(actionCost));

            if (actionCost.Cards.Count != 1)
                throw new InvalidOperationException("Action cost for a single card action must only contain one card.");

            var playedCard = actionCost.Cards.Single();
            if (playedCard.Family != RequiredCardFamily)
                throw new InvalidOperationException($"Action requires a cost of one card from family {RequiredCardFamily}.");

            gameState.Players.Single(p => p.PlayerId == playerId).RemoveCard(playedCard.CardId);
            gameState.DiscardCard(playedCard);

            return ExecuteActionCoreAsync(gameState);
        }

        protected abstract CardFamily RequiredCardFamily { get; }

        protected abstract Task ExecuteActionCoreAsync(IGameState gameState);
    }
}
