using Homework6.Models;
using System.Collections.Generic;

namespace Homework6.Services
{
    public interface IProfileRepository
    {
        List<Profile> GetAllProfiles();
        Profile GetProfile(int profileId);
        List<int> GetFriendsIds(int profileId);
        void AddProfile(Profile profile);
        void DeleteProfile(int profileId);
        void UpdateProfile(int profileId, Profile profile);

        List<Post> GetAllPosts(int profileId);
        Post GetPost(int profileId, int postId);
        void AddPost(int profileId, Post post);
        void DeletePost(int profileId, int postId);
        void UpdatePost(int profileId, int postId, Post post);
    }
}