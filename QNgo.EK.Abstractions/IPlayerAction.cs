using System.Collections.Generic;

namespace QNgo.EK.Abstractions
{
    public interface IPlayerAction
    {
        int PlayerId { get; }
        PlayerActionType ActionType { get; }
        ICollection<int> CardIds { get; }
    }

    public interface IPlayerQuickAction
    {
        int PlayerId { get; }
        int? CardId { get; }
    }
}
