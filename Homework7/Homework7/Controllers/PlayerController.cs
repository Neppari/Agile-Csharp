using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework7.Models;
using Homework7.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework7.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ILeaderboardRepository _repository;
        public PlayerController(ILeaderboardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetPlayers() =>
            Ok(_repository.GetPlayers());

        [HttpPost]
        public IActionResult PostPlayer([FromBody] Player player)
        {
            if (!TryValidateModel(player))
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            _repository.AddPlayer(player);
            return Created(Request.Path + player.Id.ToString(), player);
        }
    }
}
