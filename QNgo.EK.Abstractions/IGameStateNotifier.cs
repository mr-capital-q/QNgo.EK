using System.Collections.Generic;

namespace QNgo.EK.Abstractions
{
    public interface IGameStateNotifier
    {
        void NotifyTurnPhaseChanged();
        void NotifyTurnPhaseExecuting(int currentPlayerId, TurnPhase currentTurnPhase);
        void NotifyDeckStateChanged(int cardCount);
        void NotifyDiscardPileStateChanged(int cardCount);
        void NotifyPlayersChanged(IEnumerable<int> players);
        void NotifyEndGameCondition(int winningPlayerId);
    }
}
