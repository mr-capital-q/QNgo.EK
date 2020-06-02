using QNgo.EK.Abstractions.States;
using System.Collections.Generic;

namespace QNgo.EK.Abstractions
{
    public interface IGameStateNotifier
    {
        void NotifyTurnPhaseChanged();
        void NotifyTurnPhaseExecuting(int currentPlayerId, TurnPhase currentTurnPhase);
        void NotifyDeckStateChanged(IEnumerable<ICardState> cards);
        void NotifyDiscardPileStateChanged(IEnumerable<ICardState> cards);
        void NotifyPlayersChanged(IEnumerable<IPlayerState> playerStates);
        void NotifyPlayerHandChanged(int playerId, IEnumerable<ICard> cards);
        void NotifyEndGameCondition(int winningPlayerId);
    }
}
