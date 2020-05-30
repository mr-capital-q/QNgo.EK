using System.Collections.Generic;

namespace QNgo.EK.Abstractions
{
    public interface IGameState
    {
        ICollection<IPlayer> Players { get; }
        IList<ICard> Deck { get; }
        IList<ICard> DiscardPile { get; }
        TurnPhase CurrentPhase { get; set; }
        IPlayer CurrentPlayer { get; }
        ICard DrawCard();
        void ShuffleDeck();
        void DiscardCard(ICard card);
        void ReturnToDeck(ICard card, int position = 0);
        void GoToNextPlayer();
    }

    public interface IActionCost
    {
        ICollection<ICard> Cards { get; }
    }
}
