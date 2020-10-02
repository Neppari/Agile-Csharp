using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework6.Models
{
    public class Profile
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public List<int> Friends { get; set; }
        public List<Post> Posts { get; set; }
    }
}
