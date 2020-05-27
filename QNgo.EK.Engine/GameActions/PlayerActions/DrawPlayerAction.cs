using Microsoft.Extensions.Logging;
using QNgo.EK.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QNgo.EK.Engine.GameActions.PlayerActions
{
    public class DrawPlayerAction : IGameAction
    {
        private readonly ILogger _logger;

        public DrawPlayerAction(ILogger<DrawPlayerAction> logger = null)
        {
            _logger = logger;
        }

        public Task ExecuteActionAsync(IGameState gameState, IActionCost actionCost = null)
        {
            _logger?.LogInformation("Moving to draw phase.");
            gameState.CurrentPhase = TurnPhase.Draw;
            return Task.CompletedTask;
        }
    }
}
