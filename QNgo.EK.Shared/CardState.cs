using QNgo.EK.Abstractions.States;
using System;

namespace QNgo.EK.Shared
{
    public class CardState : ICardState
    {
        public Guid Token { get; set; }

        public int? CardId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsFlipped { get; set; }

        public static ICardState CreateFlipped(Guid token) => new CardState { Token = token, IsFlipped = true };
        public static ICardState Create(Guid token, int cardId, string name, string description) => new CardState { Token = token, CardId = cardId, Name = name, Description = description };
    }
}
