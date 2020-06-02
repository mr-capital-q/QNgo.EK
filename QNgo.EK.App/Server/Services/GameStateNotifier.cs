using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using QNgo.EK.Abstractions.States;
using QNgo.EK.App.Server.Hubs;
using System.Collections.Generic;
using System.Linq;

namespace QNgo.EK.App.Server.Services
{
    public class GameStateNotifier : IGameStateNotifier
    {
        private readonly IHubContext<GameHub> _gameHub;
        private readonly ILogger<GameStateNotifier> _logger;

        public GameStateNotifier(IHubContext<GameHub> gameHub, ILogger<GameStateNotifier> logger)
        {
            _gameHub = gameHub ?? throw new System.ArgumentNullException(nameof(gameHub));
            _logger = logger;
        }

        public void NotifyTurnPhaseChanged()
        {
        }

        public void NotifyTurnPhaseExecuting(int currentPlayerId, TurnPhase currentTurnPhase)
        {
            _logger?.LogInformation($"Player {currentPlayerId} is executing the {currentTurnPhase} turn phase.");
            _ = _gameHub.Clients.All.SendAsync("TurnPhaseExecuting", currentPlayerId, currentTurnPhase);
        }

        public void NotifyDeckStateChanged(IEnumerable<ICardState> cards)
        {
            _logger?.LogInformation($"There are {cards.Count()} cards left in the deck.");
            _ = _gameHub.Clients.All.SendAsync("DeckStateChanged", cards);
        }

        public void NotifyDiscardPileStateChanged(IEnumerable<ICardState> cards)
        {
            _logger?.LogInformation($"There are {cards.Count()} cards in the discard pile.");
            _ = _gameHub.Clients.All.SendAsync("DiscardPileStateChanged", cards);
        }

        public void NotifyPlayersChanged(IEnumerable<IPlayerState> playerStates)
        {
            _logger?.LogInformation($"Players {string.Join(", ", playerStates)} are actively playing.");
            _ = _gameHub.Clients.All.SendAsync("PlayersChanged", playerStates);
        }

        public void NotifyPlayerHandChanged(int playerId, IEnumerable<ICardState> cards)
        {
            _logger?.LogInformation($"Player {playerId} has {cards.Count()} card(s).");
            _ = _gameHub.Clients.All.SendAsync("PlayerHandChanged", playerId, cards);
        }

        public void NotifyEndGameCondition(int winningPlayerId)
        {
            _logger?.LogInformation($"Player {winningPlayerId} is the winner!");
            _ = _gameHub.Clients.All.SendAsync("EndGameCondition", winningPlayerId);
        }
    }
}
