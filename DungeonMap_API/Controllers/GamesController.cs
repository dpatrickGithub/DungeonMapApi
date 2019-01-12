using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonMap_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DungeonMap_API.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Authorize]
        [Route("users/{userId}")]
        public IActionResult GetByUser(int userId)
        {
            var games = _gameService.GetGamesByUserId(userId);

            return new OkObjectResult(games);
        }
        
    }
}