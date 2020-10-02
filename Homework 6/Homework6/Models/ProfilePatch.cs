using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework6.Models
{
    public class ProfilePatch
    {
        public string Name { get; set; }
        public string ProfilePictureUrl { get; set; }
        public List<int> Friends { get; set; }
    }
}
