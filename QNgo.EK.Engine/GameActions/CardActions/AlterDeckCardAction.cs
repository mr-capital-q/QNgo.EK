using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions.CardActions
{
    public class AlterDeckCardAction : SingleCardAction
    {
        private readonly int _peekCardCount;
        private readonly ILogger _logger;

        public AlterDeckCardAction(int peekCardCount, ILogger<AlterDeckCardAction> logger = null)
        {
            _peekCardCount = peekCardCount;
            _logger = logger;
        }

        protected override CardFamily RequiredCardFamily => CardFamily.AlterDeck;

        protected override async Task ExecuteActionCoreAsync(IGameState gameState)
        {
            _logger?.LogInformation($"Picking up top {_peekCardCount} cards.");
            var cards = gameState.Deck.Take(Math.Min(gameState.Deck.Count, _peekCardCount)).ToList();
            var reorderedCards = await gameState.CurrentPlayer.ShowCardsAsync(cards, true);

            _logger?.LogInformation("Placing reordered cards on top of deck.");
            foreach (var card in cards)
            {
                gameState.Deck.Remove(card);
            }
            foreach (var card in reorderedCards.Reverse())
            {
                gameState.Deck.Insert(0, card);
            }
        }
    }
}
