using QNgo.EK.Abstractions.States;

namespace QNgo.EK.Shared
{
    public class CardState : ICardState
    {
        public int? CardId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsFlipped { get; set; }

        public static ICardState CreateFlipped() => new CardState { IsFlipped = true };
        public static ICardState Create(int cardId, string name, string description) => new CardState { CardId = cardId, Name = name, Description = description };
    }
}
