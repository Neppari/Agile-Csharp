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
    [Route("api/scores")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly ILeaderboardRepository _repository;
        public ScoreController(ILeaderboardRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("level/{levelId}")]
        public IActionResult GetScores(int levelId) =>
            Ok(_repository.GetScores(levelId));

        [HttpPost("level/{levelId}")]
        public IActionResult PostScore(int levelId, [FromBody] Score score)
        {
            if (!TryValidateModel(score))
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            _repository.AddScore(score, levelId);
            return Created(Request.Path + score.Id.ToString(), score);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteScore(int id)
        {
            Score score = _repository.GetScore(id);
            if (score == null)
                return NotFound();

            _repository.DeleteScore(id);
            return Ok(score);
        }
    }
}
