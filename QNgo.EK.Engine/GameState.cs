using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QNgo.EK.Engine
{
    public class GameState : IGameState
    {
        private readonly List<IPlayer> _players;
        private readonly IGameStateNotifier _gameStateNotifier;
        private readonly ILogger<GameState> _logger;
        private int _currentPlayerIndex;
        private TurnPhase _currentPhase;

        public GameState(IGameStateNotifier gameStateNotifier, ILogger<GameState> logger)
        {
            _gameStateNotifier = gameStateNotifier;
            _logger = logger;
            _players = new List<IPlayer>
            {
                new Player(1, "John"),
                new Player(2, "Jane"),
                new Player(3, "Meep"),
                new Player(4, "Milo"),
                new Player(5, "Moop")
            };

            Deck = new FakeCardRepo().GetAllCardsAsync()
                .GetAwaiter()
                .GetResult()
                .Where(c => c.Family != CardFamily.Lose && c.Family != CardFamily.LoseExtra && c.Family != CardFamily.ExtraLife)
                .ToList();
            ShuffleDeck();
        }

        public ICollection<IPlayer> Players => _players;

        public IList<ICard> Deck { get; private set; } = new List<ICard>();

        public IList<ICard> DiscardPile { get; } = new List<ICard>();

        public TurnPhase CurrentPhase
        {
            get => _currentPhase;
            set
            {
                _currentPhase = value;
                _gameStateNotifier.NotifyTurnPhaseChanged();
            }
        }
        public IPlayer CurrentPlayer => _players[_currentPlayerIndex];
        public bool IsPlayDirectionReversed { get; set; }

        public void DiscardCard(ICard card)
        {
            DiscardPile.Add(card);
            _gameStateNotifier.NotifyDiscardPileStateChanged(DiscardPile.Count);
        }

        public ICard DrawCard()
        {
            var card = Deck.First();
            Deck.Remove(card);
            _gameStateNotifier.NotifyDeckStateChanged(Deck.Count);
            return card;
        }

        public void ReturnToDeck(ICard card, int position = 0)
        {
            Deck.Insert(Math.Max(0, Math.Min(Deck.Count, position)), card);
            _gameStateNotifier.NotifyDeckStateChanged(Deck.Count);
        }

        public void GoToNextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + (IsPlayDirectionReversed ? -1 : 1)) % _players.Count;
            if (CurrentPlayer.IsEliminated)
            {
                GoToNextPlayer();
                return;
            }
            _logger.LogInformation($"Current player is now {CurrentPlayer.PlayerId}");
        }

        public void ShuffleDeck()
        {
            _logger.LogInformation("Shuffling deck...");
            var rand = new Random();
            Deck = Deck.OrderBy(x => rand.Next()).ToList();
        }
    }
}
