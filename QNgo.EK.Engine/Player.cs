using QNgo.EK.Abstractions;
using QNgo.EK.Abstractions.States;
using QNgo.EK.Engine.PlayerActions;
using QNgo.EK.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine
{
    public class Player : IPlayer
    {
        private List<ICard> _cards = new List<ICard>();
        private readonly IGameStateNotifier _gameNotifier;

        public Player(int id, string displayName, IGameStateNotifier gameNotifier)
        {
            PlayerId = id;
            DisplayName = displayName;
            _gameNotifier = gameNotifier;
        }

        public int PlayerId { get; }

        public string DisplayName { get; }

        public IReadOnlyCollection<ICard> Cards => _cards;

        public bool IsEliminated { get; set; }

        public Task<int> ChoosePlayerAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IPlayerAction> GetPlayerActionAsync()
        {
            await Task.Delay(500);
            var skip = Cards.FirstOrDefault(c => c.Family == CardFamily.Skip);
            if (skip != null && Cards.All(c => c.Family != CardFamily.ExtraLife))
                return PlayerAction.PlayCard(PlayerId, skip.CardId);
            return PlayerAction.Draw(PlayerId);
        }

        public Task<IPlayerQuickAction> GetPlayerQuickActionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICard> PickCardAsync(ICollection<ICard> cards)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ICard>> ShowCardsAsync(ICollection<ICard> cards, bool allowReorder = false)
        {
            throw new NotImplementedException();
        }

        public override string ToString() => $"{PlayerId} - {DisplayName}";

        public void AddCard(ICard card)
        {
            if (_cards.Any(c => c.CardId == card.CardId))
                throw new InvalidOperationException($"Cannot add duplicate card id {card.CardId}.");

            _cards.Add(card);
            _gameNotifier.NotifyPlayerHandChanged(PlayerId, Cards.Select(c => CardState.CreateFlipped(c.StateToken)));
        }

        public void RemoveCard(int cardId)
        {
            foreach (var card in _cards.Where(c => c.CardId == cardId).ToList())
            {
                _cards.Remove(card);
            }

            _gameNotifier.NotifyPlayerHandChanged(PlayerId, Cards.Select(c => CardState.CreateFlipped(c.StateToken)));
        }

        public IPlayerState GetState()
        {
            return new PlayerState(PlayerId, DisplayName, IsEliminated);
        }
    }
}
