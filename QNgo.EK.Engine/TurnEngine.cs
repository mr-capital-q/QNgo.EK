using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine
{
    public class TurnEngine
    {
        private readonly IGameState _gameState;
        private readonly IGameActionResolver _gameActionResolver;
        private readonly ICardResolver _cardResolver;
        private readonly ILogger<TurnEngine> _logger;

        public TurnEngine(IGameState gameState,
            IGameActionResolver gameActionResolver,
            ICardResolver cardResolver,
            ILogger<TurnEngine> logger = null)
        {
            _gameState = gameState ?? throw new ArgumentNullException(nameof(gameState));
            _gameActionResolver = gameActionResolver ?? throw new ArgumentNullException(nameof(gameActionResolver));
            _cardResolver = cardResolver ?? throw new ArgumentNullException(nameof(cardResolver));
            _logger = logger;
        }

        public Task StartGameAsync()
        {
            for (var i = 0; i < 1; i++)
            {
                foreach (var player in _gameState.Players)
                {
                    player.Cards.Add(_gameState.DrawCard());
                }
            }

            return ExecuteTurnPhaseAsync();
        }

        public async Task ExecuteTurnPhaseAsync()
        {
            _logger?.LogInformation($"Executing {_gameState.CurrentPhase} turn phase.");
            switch (_gameState.CurrentPhase)
            {
                case TurnPhase.TurnStart:
                    _gameState.CurrentPhase = TurnPhase.PlayerAction;
                    break;
                case TurnPhase.PlayerAction:
                    var playerAction = await _gameState.CurrentPlayer.GetPlayerActionAsync();
                    var gameAction = await _gameActionResolver.GetGameActionAsync(playerAction);
                    var playedCards = await Task.WhenAll(playerAction.CardIds.Select(id => _cardResolver.GetCardAsync(id)));
                    await gameAction.ExecuteActionAsync(_gameState, new ActionCost(playedCards));
                    break;
                case TurnPhase.Draw:
                    var newCard = _gameState.DrawCard();
                    // Check for exploding kitten and perform defuse if necessary
                    _gameState.CurrentPlayer.Cards.Add(newCard);
                    _gameState.CurrentPhase = TurnPhase.TurnEnd;
                    break;
                case TurnPhase.TurnEnd:
                    _gameState.GoToNextPlayer();
                    _gameState.CurrentPhase = TurnPhase.TurnStart;
                    break;
                default:
                    break;
            }

            await ExecuteTurnPhaseAsync();
        }
    }
}
