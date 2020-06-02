using System;

namespace QNgo.EK.Abstractions.States
{
    public interface ICardState
    {
        Guid Token { get; }
        int? CardId { get; }
        string Name { get; }
        string Description { get; }
        bool IsFlipped { get; }
    }
}
