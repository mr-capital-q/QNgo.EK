using QNgo.EK.Abstractions.States;

namespace QNgo.EK.Shared
{
    public class PlayerState : IPlayerState
    {
        public PlayerState()
        { }

        public PlayerState(int playerId, string displayName, bool isEliminated)
        {
            PlayerId = playerId;
            DisplayName = displayName;
            IsEliminated = isEliminated;
        }

        public int PlayerId { get; set; }

        public string DisplayName { get; set; }

        public bool IsEliminated { get; set; }

        public override string ToString() => $"{PlayerId} - {DisplayName}";
    }
}
