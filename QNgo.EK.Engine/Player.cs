using QNgo.EK.Abstractions;
using QNgo.EK.Abstractions.States;
using QNgo.EK.Engine.PlayerActions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QNgo.EK.Engine
{
    public class Player : IPlayer
    {
        public Player(int id, string displayName)
        {
            PlayerId = id;
            DisplayName = displayName;
            Cards = new List<ICard>();
        }

        public int PlayerId { get; }

        public string DisplayName { get; }

        public ICollection<ICard> Cards { get; }

        public bool IsEliminated { get; set; }

        public Task<int> ChoosePlayerAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IPlayerAction> GetPlayerActionAsync()
        {
            await Task.Delay(500);
            //if (Cards.Any())
            //    return PlayerAction.PlayCard(PlayerId, Cards.First().CardId);
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

        public IPlayerState GetState()
        {
            return new PlayerState(PlayerId, DisplayName, IsEliminated, Cards.Count);
        }

        public override string ToString() => $"{PlayerId} - {DisplayName}";

        public class PlayerState : IPlayerState
        {
            public PlayerState(int playerId, string displayName, bool isEliminated, int handCardCount)
            {
                PlayerId = playerId;
                DisplayName = displayName;
                IsEliminated = isEliminated;
                HandCardCount = handCardCount;
            }

            public int PlayerId { get; }

            public string DisplayName { get; }

            public bool IsEliminated { get; }

            public int HandCardCount { get; }

            public override string ToString() => $"{PlayerId} - {DisplayName}";
        }
    }
}
