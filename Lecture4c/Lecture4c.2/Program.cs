using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lecture4c._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string filePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"\names.txt";

            string[] names = File.ReadAllLines(filePath);

            while (true)
            {
                Console.WriteLine("Input the name or part of name you would like to search:");
                string input = Console.ReadLine();

                string[] searchResult = names
                    .Where(s => s.Contains(input))
                    .ToArray();

                int results = searchResult.Length;
                Console.WriteLine($"There were {results} results.");

                if (results < 10)
                {
                    List<User> users = new List<User>();
                    int id = 0;

                    for (int i = 0; i < searchResult.Length; i++)
                    {
                        users.Add(new User(id, searchResult[i]));
                        id++;
                    }

                    var sortedUsers = users.OrderBy(u => u.Name.Length);
                    foreach (User user in sortedUsers)
                        Console.WriteLine($"{user.Id}, {user.Name}");
                }
            }
        }
    }

    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
