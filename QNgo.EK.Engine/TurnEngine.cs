using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using QNgo.EK.Engine.PlayerActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.Engine
{
    public class TurnEngine
    {
        private readonly IGameState _gameState;
        private readonly IGameActionResolver _gameActionResolver;
        private readonly ICardResolver _cardResolver;
        private readonly IGameStateNotifier _gameStateNotifier;
        private readonly ILogger<TurnEngine> _logger;

        public TurnEngine(IGameState gameState,
            IGameActionResolver gameActionResolver,
            ICardResolver cardResolver,
            IGameStateNotifier gameStateNotifier,
            ILogger<TurnEngine> logger = null)
        {
            _gameState = gameState ?? throw new ArgumentNullException(nameof(gameState));
            _gameActionResolver = gameActionResolver ?? throw new ArgumentNullException(nameof(gameActionResolver));
            _cardResolver = cardResolver ?? throw new ArgumentNullException(nameof(cardResolver));
            _gameStateNotifier = gameStateNotifier ?? throw new ArgumentNullException(nameof(gameStateNotifier));
            _logger = logger;
        }

        public async Task StartGameAsync()
        {
            for (var i = 0; i < 7; i++)
            {
                foreach (var player in _gameState.Players)
                {
                    player.Cards.Add(_gameState.DrawCard());
                }
            }

            var id = 1;
            foreach (var player in _gameState.Players)
            {
                if (id != 1)
                    _gameState.ReturnToDeck(await _cardResolver.GetCardAsync(id));
                player.Cards.Add(await _cardResolver.GetCardAsync(id + 7));
                id++;
            }
            _gameState.ShuffleDeck();

            _gameStateNotifier.NotifyPlayersChanged(_gameState.Players.Select(p => p.PlayerId));

            await ExecuteTurnPhaseAsync();
        }

        public async Task ExecuteTurnPhaseAsync()
        {
            _gameStateNotifier.NotifyTurnPhaseExecuting(_gameState.CurrentPlayer.PlayerId, _gameState.CurrentPhase);
            switch (_gameState.CurrentPhase)
            {
                case TurnPhase.TurnStart:
                    _gameState.CurrentPhase = TurnPhase.PlayerAction;
                    break;
                case TurnPhase.PlayerAction:
                    var playerAction = await _gameState.CurrentPlayer.GetPlayerActionAsync();
                    var gameAction = await _gameActionResolver.GetGameActionAsync(playerAction);
                    var playedCards = await Task.WhenAll(playerAction.CardIds.Select(id => _cardResolver.GetCardAsync(id)));
                    await gameAction.ExecuteActionAsync(_gameState.CurrentPlayer.PlayerId, _gameState, new ActionCost(playedCards));
                    break;
                case TurnPhase.TurnEnd:
                    _gameState.GoToNextPlayer();
                    _gameState.CurrentPhase = TurnPhase.TurnStart;
                    break;
                case TurnPhase.Elimination:
                    var loseCard = _gameState.CurrentPlayer.Cards.LastOrDefault(c => c.Family == CardFamily.Lose);
                    if (loseCard is null)
                    {
                        _gameState.CurrentPhase = TurnPhase.TurnEnd;
                        break;
                    }

                    var extraLifeCard = _gameState.CurrentPlayer.Cards.FirstOrDefault(c => c.Family == CardFamily.ExtraLife);
                    if (extraLifeCard is null)
                    {
                        _gameState.CurrentPlayer.IsEliminated = true;
                        _gameStateNotifier.NotifyPlayersChanged(_gameState.Players.Where(p => !p.IsEliminated).Select(p => p.PlayerId));
                    }
                    else
                    {
                        var action = await _gameActionResolver.GetGameActionAsync(PlayerAction.PlayCard(_gameState.CurrentPlayer.PlayerId, extraLifeCard.CardId));
                        await action.ExecuteActionAsync(_gameState.CurrentPlayer.PlayerId, _gameState, new ActionCost(new List<ICard> { extraLifeCard, loseCard }));
                    }

                    if (_gameState.Players.Count(c => !c.IsEliminated) == 1)
                    {
                        _gameState.CurrentPhase = TurnPhase.GameEnd;
                        break;
                    }

                    _gameState.CurrentPhase = TurnPhase.TurnEnd;
                    break;
                default:
                    _gameStateNotifier.NotifyEndGameCondition(_gameState.Players.Single(c => !c.IsEliminated).PlayerId);
                    return;
            }

            await ExecuteTurnPhaseAsync();
        }
    }
}
