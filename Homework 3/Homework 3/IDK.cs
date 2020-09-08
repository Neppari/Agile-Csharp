using Homework_3.Controllers;
using Homework_3.Entities;
using Homework_3.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_3
{
    class IDK
    {
        private MovieController mc = new MovieController();
        private ConsoleUi ui = new ConsoleUi();

        public IDK()
        {
            /*
            mc.AddDummyMovies();
            mc.AddMovie("Horror Thing", "This is a horror movie", 125);
            mc.AddMovie("Sweets", "A moview about candies", 90);

            List<Movie> movies = mc.GetMovies();

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine(movies[i].Name);
            }*/

            ui.Search += OnSearch;
        }

        public void Run()
        {
            while(true)
            {
                ui.MainMenu();
            }
        }

        private void OnSearch(string searchTerm)
        {
            var movies = mc.GetFilteredMovies(searchTerm);
            ui.PrintSearchResults(movies, searchTerm);
        }
    }
}
