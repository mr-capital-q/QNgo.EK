using QNgo.EK.Abstractions;
using System.Threading.Tasks;

namespace QNgo.EK.Engine
{
    public class Card : ICard
    {
        public Card(int cardId, CardFamily family, string name, string description)
        {
            CardId = cardId;
            Family = family;
            Name = name;
            Description = description;
        }

        public int CardId { get; }

        public CardFamily Family { get; }

        public string Name { get; }

        public string Description { get; }

        public Task ExecuteActionAsync(IGameState gameState, IActionCost actionCost = null)
        {
            return Task.CompletedTask;
        }
    }
}
