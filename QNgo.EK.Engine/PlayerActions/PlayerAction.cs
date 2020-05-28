using QNgo.EK.Abstractions;
using System.Collections.Generic;

namespace QNgo.EK.Engine.PlayerActions
{
    public class PlayerAction : IPlayerAction
    {
        private PlayerAction(int playerId, PlayerActionType actionType, ICollection<int> cardIds)
        {
            PlayerId = playerId;
            ActionType = actionType;
            CardIds = cardIds;
        }

        public int PlayerId { get; }

        public PlayerActionType ActionType { get; }

        public ICollection<int> CardIds { get; }

        public static PlayerAction Draw(int playerId) => new PlayerAction(playerId, PlayerActionType.DrawCard, new List<int>());

        public static PlayerAction PlayCard(int playerId, int cardId) => new PlayerAction(playerId, PlayerActionType.PlayCard, new List<int> { cardId });
    }
}
