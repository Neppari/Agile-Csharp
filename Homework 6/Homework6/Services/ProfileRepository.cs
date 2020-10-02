using Homework6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework6.Services
{
    public class ProfileRepository : IProfileRepository
    {
        #region Profile Management
        List<Profile> profiles = new List<Profile>
        {
            new Profile
            {
                Id = 1,
                Name = "Meri Mattila",
                ProfilePictureUrl = "http://buuttiexample.com/kuva1.jpg",
                Friends = new List<int>(),
                Posts = new List<Post>
                {
                    new Post
                    {
                        Id = 1,
                        Date = DateTime.Now,
                        Content = "This is my first Post!"
                    }
                }
            }
        };

        public List<Profile> GetAllProfiles() => profiles;

        public Profile GetProfile(int profileId)
        {
            Profile profile = profiles
                .SingleOrDefault(p => p.Id.Equals(profileId));

            return profile;
        }

        public List<int> GetFriendsIds(int profileId)
        {
            var friends = GetProfile(profileId).Friends;
            return friends;
        }

        public void AddProfile(Profile profile)
        {
            GetAllProfiles().Append(profile);
        }

        public void DeleteProfile(int profileId)
        {
            var newList = profiles
                .Where(p => p.Id != profileId)
                .ToList();

            profiles = newList;
        }

        public void UpdateProfile(int profileId, Profile profile)
        {
            Profile profileToUpdate = GetProfile(profileId);
            profileToUpdate.Name = profile.Name;
            profileToUpdate.ProfilePictureUrl = profile.ProfilePictureUrl;
            profileToUpdate.Friends = profile.Friends;
        }
        #endregion

        #region Post Management
        //Returns all the posts from a profile
        public List<Post> GetAllPosts(int profileId)
        {
            List<Post> posts = GetProfile(profileId)?.Posts;
            return posts;
        }

        public Post GetPost(int profileId, int postId)
        {
            Post post = GetProfile(profileId)?.Posts
                .SingleOrDefault(p => p.Id.Equals(postId));

            return post;
        }

        public void AddPost(int profileId, Post post)
        {
            GetAllPosts(profileId).Append(post);
        }

        public void DeletePost(int profileId, int postId)
        {
            var updatedPosts = GetAllPosts(profileId)
                .Where(p => p.Id != postId)
                .ToList();

            GetProfile(profileId).Posts = updatedPosts;
        }

        public void UpdatePost(int profileId, int postId, Post post)
        {
            Post postToUpdate = GetPost(profileId, postId);
            postToUpdate.Content = post.Content;
        }
        #endregion
    }
}