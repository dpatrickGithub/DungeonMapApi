using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonMap_API.Models;
using DungeonMap_API.Services.Character;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DungeonMap_API.Controllers
{
    [Route("api/characters")]
    [Authorize]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [Route("users/{userId:int}/games/{gameId:int}")]
        public IActionResult GetCharacterByUserAndGame(int userId, int gameId)
        {
            var characterDetails = _characterService.GetCharacterByUserAndGame(userId, gameId);
            return new OkObjectResult(characterDetails);
        }

        /// <summary>
        /// Get characters by User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("users/{userId:int}")]
        public IActionResult GetCharactersByUser(int userId)
        {
            var characterDetails = _characterService.GetCharactersByUser(userId);
            return Ok(characterDetails);
        }

        /// <summary>
        /// Gets a list of characters that your friends have. 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>a collection of Id-Name Pairs to populate a dropdown of available characters when creating a new game.</returns>
        [Route("users/{userId:int}/friends")]
        public IActionResult GetFriendsCharacters(int userId)
        {
            var characters = _characterService.GetFriendsCharacters(userId);
            return Ok(characters);
        }

        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var character = _characterService.GetById(id);
            return Ok(character);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CharacterModel model)
        {
            _characterService.CreateCharacter(model);
            return Ok();
        }
    }
}