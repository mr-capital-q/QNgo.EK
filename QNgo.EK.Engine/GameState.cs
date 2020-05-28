using QNgo.EK.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QNgo.EK.Engine
{
    public class GameState : IGameState
    {
        private readonly List<IPlayer> _players;
        private int _currentPlayerIndex;

        public GameState()
        {
            _players = new List<IPlayer>
            {
                new Player(1),
                new Player(2),
                new Player(3),
            };

            Deck = new FakeCardRepo().GetAllCardsAsync().GetAwaiter().GetResult().ToList();
        }

        public ICollection<IPlayer> Players => _players;

        public IList<ICard> Deck { get; private set; } = new List<ICard>();

        public IList<ICard> DiscardPile { get; } = new List<ICard>();

        public TurnPhase CurrentPhase { get; set; }
        public IPlayer CurrentPlayer => _players[_currentPlayerIndex];
        public bool IsPlayDirectionReversed { get; set; }

        public void DiscardCard(ICard card)
        {
            DiscardPile.Add(card);
        }

        public ICard DrawCard()
        {
            var card = Deck.First();
            Deck.Remove(card);
            return card;
        }

        public void GoToNextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + (IsPlayDirectionReversed ? -1 : 1)) % _players.Count;
        }

        public void ShuffleDeck()
        {
            var rand = new Random();
            Deck = Deck.OrderBy(x => rand.Next()).ToList();
        }
    }
}
