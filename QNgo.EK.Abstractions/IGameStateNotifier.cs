using QNgo.EK.Abstractions.States;
using System.Collections.Generic;

namespace QNgo.EK.Abstractions
{
    public interface IGameStateNotifier
    {
        void NotifyTurnPhaseChanged();
        void NotifyTurnPhaseExecuting(int currentPlayerId, TurnPhase currentTurnPhase);
        void NotifyDeckStateChanged(int cardCount);
        void NotifyDiscardPileStateChanged(int cardCount);
        void NotifyPlayersChanged(IEnumerable<IPlayerState> playerStates);
        void NotifyEndGameCondition(int winningPlayerId);
    }
}
