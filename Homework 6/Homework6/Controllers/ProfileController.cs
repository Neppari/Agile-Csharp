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
    [Route("api/profile/{profileId}")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet]
        public IActionResult GetProfile(int profileId)
        {
            Profile profile = _profileRepository.GetProfile(profileId);
            if (profile == null)
                return NotFound();

            return Ok(profile);
        }

        [HttpGet("friends")]
        public IActionResult GetFriends(int profileId)
        {
            var friends = _profileRepository.GetFriendsIds(profileId);
            if (friends == null)
                return NotFound();

            return Ok(friends);
        }

        [HttpPost]
        public IActionResult PostProfile([FromBody] Profile profile)
        {
            if (!TryValidateModel(profile))
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            _profileRepository.AddProfile(profile);
            return Created(Request.Path + profile.Id.ToString(), profile);
        }

        [HttpPatch]
        public IActionResult UpdateProfile(int profileId, [FromBody] JsonPatchDocument<ProfilePatch> patchDocument)
        {
            Profile initialProfile = _profileRepository.GetProfile(profileId);
            if (initialProfile == null)
                return NotFound();

            ProfilePatch patchProfile = new ProfilePatch
            { Name = initialProfile.Name, ProfilePictureUrl = initialProfile.ProfilePictureUrl, Friends = initialProfile.Friends };
            patchDocument.ApplyTo(patchProfile, ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            initialProfile.Name = patchProfile.Name;
            initialProfile.ProfilePictureUrl = patchProfile.ProfilePictureUrl;
            initialProfile.Friends = patchProfile.Friends;

            _profileRepository.UpdateProfile(profileId, initialProfile);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteProfile(int profileId)
        {
            Profile profile = _profileRepository.GetProfile(profileId);
            if (profile == null)
                return NotFound();

            _profileRepository.DeleteProfile(profileId);
            return Ok(profile);
        }
    }
}
