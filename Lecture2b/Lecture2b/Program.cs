using System;
using System.Collections.Generic;

namespace Lecture2b
{
    class User
    {
        public string username;
        public string password;
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            List<User> users = new List<User>();

            while (true)
            {
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                user.username = username;
                user.password = password;
                users.Add(user);
            }
        }
    }
}
