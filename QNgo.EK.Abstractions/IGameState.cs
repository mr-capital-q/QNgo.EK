using System;
using System.Collections.Generic;
using System.Text;

namespace QNgo.EK.Abstractions
{
    public interface IGameState
    {
        ICollection<IPlayer> Players { get; }
        IList<ICard> Deck { get; }
        IList<ICard> DiscardPile { get; }
        TurnPhase CurrentPhase { get; set; }
        IPlayer CurrentPlayer { get; set; }
        ICard DrawCard();
        void ShuffleDeck();
        void DiscardCard(int id);
    }

    public interface IActionCost
    {
        ICollection<ICard> Cards { get; }
    }
}
