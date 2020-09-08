using System;
using System.Collections.Generic;

namespace Lecture_3a
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Message> allMessages = new List<Message>();

            while (true)
            {
                Console.WriteLine("Add a new message:");
                string message = Console.ReadLine();

                Message newMessage = new Message(message);
                allMessages.Add(newMessage);

                Console.WriteLine("Total messages: " + Message.TotalMessages);
                Console.WriteLine("Last message: " + Message.LastMessage);
            }
        }
    }
}