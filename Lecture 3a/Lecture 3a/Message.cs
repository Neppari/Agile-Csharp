using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_3a
{
    class Message
    {
        public static int TotalMessages { get; set; }
        public static string LastMessage { get; set; }

        string MessageText { get; set; }

        public Message(string message)
        {
            TotalMessages++;
            LastMessage = message;
        }
    }
}
