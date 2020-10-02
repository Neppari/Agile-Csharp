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
    [Route("api/levels")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILeaderboardRepository _repository;
        public LevelController(ILeaderboardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetLevels() =>
            Ok(_repository.GetLevels());

        [HttpPost]
        public IActionResult PostLevel([FromBody] Level level)
        {
            if (!TryValidateModel(level))
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            _repository.AddLevel(level);
            return Created(Request.Path + level.Id.ToString(), level);
        }
    }
}
