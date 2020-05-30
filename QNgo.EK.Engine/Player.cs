using QNgo.EK.Abstractions;
using QNgo.EK.Engine.PlayerActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine
{
    public class Player : IPlayer
    {
        public Player(int id)
        {
            PlayerId = id;
            Cards = new List<ICard>();
        }

        public int PlayerId { get; }

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
    }
}
