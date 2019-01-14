using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonMap_API.Models;
using DungeonMap_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DungeonMap_API.Controllers
{
    [Route("api/games")]
    [ApiController]
    [Authorize]
    public class GamesController : ControllerBase
    {
        private IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Gets all of a user's characters by id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("users/{userId}")]
        public IActionResult GetByUser(int userId)
        {
            var games = _gameService.GetGamesByUserId(userId);

            return new OkObjectResult(games);
        }

        /// <summary>
        /// Creates a new game. 
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] GameModel game)
        {
            _gameService.CreateGame(game);
            return Ok();
        }

        /// <summary>
        /// gets a list of active games run by friends of the logged in user. 
        /// </summary>
        [Route("users/{userId:int}/friends")]
        public IActionResult GetFriendsGames(int userId)
        {
            var games = _gameService.GetFriendsGames(userId);
            return Ok(games);
        }
    }
}