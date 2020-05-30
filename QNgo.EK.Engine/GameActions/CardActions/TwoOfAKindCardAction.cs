using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions.CardActions
{
    public class TwoOfAKindCardAction : IGameAction
    {
        public TwoOfAKindCardAction(ILogger<TwoOfAKindCardAction> logger = null)
        {
            Random = new Random();
            Logger = logger;
        }

        protected Random Random { get; set; }
        protected ILogger Logger { get; set; }

        public Task ExecuteActionAsync(int playerId, IGameState gameState, IActionCost actionCost)
        {
            DiscardCards(playerId, gameState, actionCost);
            return ExecuteCoreAsync(gameState);
        }

        protected void DiscardCards(int playerId, IGameState gameState, IActionCost actionCost)
        {
            Logger?.LogInformation("Discarding cards.");

            var player = gameState.Players.Single(p => p.PlayerId == playerId);
            foreach (var card in actionCost.Cards)
            {
                player.Cards.Remove(card);
                gameState.DiscardCard(card);
            }
        }

        protected virtual async Task ExecuteCoreAsync(IGameState gameState)
        {
            var playerId = await gameState.CurrentPlayer.ChoosePlayerAsync();
            var targetedPlayer = gameState.Players.FirstOrDefault(p => p.PlayerId == playerId);
            if (targetedPlayer == null)
            {
                Logger.LogInformation("Could not determine targeted player.");
                return;
            }

            var card = targetedPlayer.Cards.ElementAtOrDefault(Random.Next(targetedPlayer.Cards.Count));
            if (card == null)
            {
                Logger.LogInformation("Could not pick a random card from the targeted player.");
                return;
            }

            targetedPlayer.Cards.Remove(card);
            gameState.CurrentPlayer.Cards.Add(card);
        }
    }
}
