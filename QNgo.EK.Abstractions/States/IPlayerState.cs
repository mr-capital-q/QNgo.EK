namespace QNgo.EK.Abstractions.States
{
    public interface IPlayerState
    {
        int PlayerId { get; }
        string DisplayName { get; }
        bool IsEliminated { get; }
    }
}
