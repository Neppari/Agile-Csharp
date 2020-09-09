using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise_5._5.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }

        public Note(int id, string content, string creator)
        {
            Id = id;
            Content = content;
            Creator = creator;
        }

        public Note()
        {

        }
    } 
}
