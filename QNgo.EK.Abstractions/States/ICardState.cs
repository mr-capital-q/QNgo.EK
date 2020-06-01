namespace QNgo.EK.Abstractions.States
{
    public interface ICardState
    {
        int? CardId { get; }
        string Name { get; }
        string Description { get; }
        bool IsFlipped { get; }
    }
}
