using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions.CardActions
{
    public class PeekDeckCardAction : SingleCardAction
    {
        private readonly int _peekCardCount;
        private readonly ILogger<PeekDeckCardAction> _logger;

        public PeekDeckCardAction(int peekCardCount, ILogger<PeekDeckCardAction> logger = null)
        {
            _peekCardCount = peekCardCount;
            _logger = logger;
        }

        protected override CardFamily RequiredCardFamily => CardFamily.PeekDeck;

        protected override async Task ExecuteActionCoreAsync(IGameState gameState)
        {
            _logger?.LogInformation($"Picking up top {_peekCardCount} cards.");
            var cards = gameState.Deck.Take(Math.Min(gameState.Deck.Count, _peekCardCount)).ToList();
            await gameState.CurrentPlayer.ShowCardsAsync(cards);
        }
    }
}
