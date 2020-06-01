using Microsoft.AspNetCore.Mvc;
using QNgo.EK.Engine;
using System;
using System.Threading.Tasks;

namespace QNgo.EK.App.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly TurnEngine _turnEngine;

        public GamesController(TurnEngine turnEngine)
        {
            _turnEngine = turnEngine ?? throw new ArgumentNullException(nameof(turnEngine));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _turnEngine.StartGameAsync();
            return Ok();
        }
    }
}
