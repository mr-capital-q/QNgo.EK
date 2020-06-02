using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions.CardActions
{
    public class ThreeOfAKindCardAction : TwoOfAKindCardAction
    {
        public ThreeOfAKindCardAction(ILogger<ThreeOfAKindCardAction> logger = null)
            : base()
        {
            Logger = logger;
        }

        protected override async Task ExecuteCoreAsync(IGameState gameState)
        {
            var playerId = await gameState.CurrentPlayer.ChoosePlayerAsync();
            var targetedPlayer = gameState.Players.FirstOrDefault(p => p.PlayerId == playerId);
            if (targetedPlayer == null)
            {
                Logger.LogInformation("Could not determine targeted player.");
                return;
            }

            var referenceCard = await gameState.CurrentPlayer.PickCardAsync(null); // Get a distinct list of cards
            if (referenceCard == null)
            {
                Logger.LogInformation("Could not determine card chosen by player.");
                return;
            }

            var card = targetedPlayer.Cards.FirstOrDefault(c => c.Name == referenceCard.Name);
            if (card == null)
            {
                Logger.LogInformation("Targeted player does not have a card by that name.");
                return;
            }

            targetedPlayer.RemoveCard(card.CardId);
            gameState.CurrentPlayer.AddCard(card);
        }
    }
}
