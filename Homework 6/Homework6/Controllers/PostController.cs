using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework6.Models;
using Homework6.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Homework6.Controllers
{
    [Route("api/profile/{profileId}/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        public PostController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet]
        public IActionResult GetAllPosts(int profileId)
        {
            var posts = _profileRepository.GetAllPosts(profileId);
            if (posts == null)
                return NotFound();

            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public IActionResult GetPost(int profileId, int postId)
        {
            var post = _profileRepository.GetPost(profileId, postId);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public IActionResult AddPost(int profileId, [FromBody] Post post)
        {
            if (!TryValidateModel(post))
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            _profileRepository.AddPost(profileId, post);
            return Created(Request.Path + post.Id.ToString(), post);
        }

        [HttpPatch("{postId}")]
        public IActionResult UpdatePost(int profileId, int postId, [FromBody] JsonPatchDocument<PostPatch> patchDocument)
        {
            Post initialPost = _profileRepository.GetPost(profileId, postId);
            if (initialPost == null)
                return NotFound();

            PostPatch patchPost = new PostPatch
            { Content = initialPost.Content };
            patchDocument.ApplyTo(patchPost, ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            initialPost.Content = patchPost.Content;
            _profileRepository.UpdatePost(profileId, postId, initialPost);

            return NoContent();
        }

        [HttpDelete("{postId}")]
        public IActionResult DeletePost(int profileId, int postId)
        {
            Post post = _profileRepository.GetPost(profileId, postId);
            if (post == null)
                return NotFound();

            _profileRepository.DeletePost(profileId, postId);
            return Ok(post);
        }
    }
}