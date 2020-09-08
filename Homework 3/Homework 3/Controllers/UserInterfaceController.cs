using Homework_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework_3.Controllers
{
    class UserInterfaceController
    {
        MovieController movieController = new MovieController();

        public void Search()
        {
            Console.WriteLine("Enter your search term:");
            string input = Console.ReadLine();

            List<Movie> movies = movieController.GetFilteredMovies(input);
            Console.WriteLine($"Found {movies.Count} movies with search term '{input}':");

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine(movies[i].Name);
            }
        }

        public void Add()
        {
            Console.WriteLine("Adding a movie.");
            Console.WriteLine("Please add the details for the movie!");

            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Description:");
            string description = Console.ReadLine();

            Console.WriteLine("Length:");
            int lenght = int.Parse(Console.ReadLine());

            movieController.AddMovie(name, description, lenght);
            Console.WriteLine($"Movie '{name}' added!");
        }

        public void Remove()
        {
            Console.WriteLine("Removing a movie.");
            Console.WriteLine("Please enter the ID of the movie you want to remove:");
            int id = int.Parse(Console.ReadLine());

            List<Movie> allMovies = movieController.GetMovies();
            Movie toDelete = allMovies
                .SingleOrDefault(movie => movie.Id == id);

            Console.WriteLine($"Removing movie '{toDelete.Name}'. Are you sure (y/n)?");
            string input = Console.ReadLine();

            if (input.Equals("y"))
            {
                movieController.RemoveMovie(id);
                Console.WriteLine("Movie removed from the database.");
            }                
            else
                Console.WriteLine("Removal cancelled");
        }
    }
}
