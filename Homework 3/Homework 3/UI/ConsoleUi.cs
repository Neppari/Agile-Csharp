using Homework_3.Entities;
using Homework_3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_3.UI
{
    public class ConsoleUi : IUi
    {
        public event IUi.SearchEvent Search;
        public event IUi.EmptyEvent Add;
        public event IUi.EmptyEvent Remove;

        public void MainMenu()
        {
            OnSearch();
        }

        private void Quit()
        {
            return;
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

        private void OnSearch()
        {
            //instuctions
            Console.WriteLine("Enter your search term:");

            //take input
            string input = Console.ReadLine();

            //raise search event
            Search?.Invoke(input);
        }

        public void PrintSearchResults(List<Movie> movies, string input)
        {
            Console.WriteLine($"Found {movies.Count} movies with search term '{input}':");
            movies.ForEach(m => Console.WriteLine(m.Name));
        }

        private void OnAdd()
        {

        }

        private void OnRemove()
        {

        }
    }
}
