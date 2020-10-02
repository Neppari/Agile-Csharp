using Homework_3.Controllers;
using Homework_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework_3.UI
{
    public class ConsoleUi
    {
        MovieController MC { get; }

        public ConsoleUi()
        {
            MC = new MovieController();
        }

        public void WelcomeText()
        {
            Console.WriteLine("Welcome to Movie Database.");
            PromptContinue();
        }

        public void MainMenu()
        {
            while(true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("Type a command (hint: 'help' displays all commands)");
                string input = Console.ReadLine().ToLower().Trim();

                switch (input)
                {
                    case "help":
                        Help();
                        break;

                    case "quit":
                        Quit();
                        break;

                    case "search":
                        Search();
                        PromptContinue();
                        break;

                    case "add":
                        Add();
                        PromptContinue();
                        break;

                    case "remove":
                        Remove();
                        PromptContinue();
                        break;

                    default:
                        Console.WriteLine("Invalid command.");
                        PromptContinue();
                        break;
                }
            }            
        }

        private void Quit()
        {
            Environment.Exit(0);
        }

        private void Help()
        {
            Console.WriteLine($"Here's a list of commands you can use!\n\n" +
                $"" +
                $"help      Open this dialog.\n" +
                $"quit      Quit the program.\n\n" +
                $"" +
                $"search    List movies by search term.\n" +
                $"add       Add a new movie.\n" +
                $"remove    Remove a movie.\n\n");
        }

        private void Search()
        {
            Console.WriteLine("Enter your search term:");
            string input = Console.ReadLine();

            try
            {
                List<Movie> movies = MC.GetFilteredMovies(input);
                Console.WriteLine($"Found {movies.Count} movies with search term '{input}':");
                movies.ForEach(m => Console.WriteLine(m.Name));
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't search for a movie.");
                Console.WriteLine(e.Message);
            }
            
        }

        private void Add()
        {
            Console.WriteLine("Adding a movie.");
            Console.WriteLine("Please add the details for the movie!");

            try
            {
                Console.WriteLine("Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Description:");
                string description = Console.ReadLine();

                Console.WriteLine("Length:");
                int lenght = int.Parse(Console.ReadLine());

                MC.AddMovie(name, description, lenght);
                Console.WriteLine($"Movie '{name}' added!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while adding movie!");
                Console.WriteLine(e.Message);
            }
        }

        private void Remove()
        {
            Console.WriteLine("Removing a movie.");
            Console.WriteLine("Please enter the ID of the movie you want to remove:");

            try
            {
                int id = int.Parse(Console.ReadLine());

                List<Movie> allMovies = MC.GetMovies();
                Movie toDelete = allMovies
                    .SingleOrDefault(movie => movie.Id == id);

                Console.WriteLine($"Removing movie '{toDelete.Name}'. Are you sure (y/n)?");
                string input = Console.ReadLine();

                if (input.Equals("y"))
                {
                    MC.RemoveMovie(id);
                    Console.WriteLine("Movie removed from the database.");
                }
                else
                    Console.WriteLine("Removal cancelled");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while removing a movie!");
                Console.WriteLine(e.Message);
            }
        }

        private void PromptContinue()
        {
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
