using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.IO;
using Homework_3.Entities;
using Newtonsoft.Json;
using System.Linq;

namespace Homework_3.Controllers
{
    class MovieController
    {
        private string db = @"C:\Users\Meri\Desktop\Agile-Csharp\Homework 3\Homework 3\db.json";

        public List<Movie> GetMovies()
        {
            string json = File.ReadAllText(db);
            List<Movie> deserializedMovies = JsonConvert.DeserializeObject<List<Movie>>(json);

            return deserializedMovies;
        }

        public void AddMovie(string name, string description, int length)
        {
            List<Movie> allMovies = GetMovies();
            //WE NEED NEW WAY TO CREATE ID
            int id = allMovies.Count;

            Movie newMovie = new Movie(id, name, description, length);
            allMovies.Add(newMovie);

            //update json db
            string jsonString = JsonConvert.SerializeObject(allMovies);
            File.WriteAllText(db, jsonString);

        }

        public void RemoveMovie(int id)
        {
            List<Movie> allMovies = GetMovies();

            //find movie by id, then remove it
            Movie toDelete = allMovies
                .SingleOrDefault(movie => movie.Id == id);

            allMovies.Remove(toDelete);

            //update json db
            string jsonString = JsonConvert.SerializeObject(allMovies);
            File.WriteAllText(db, jsonString);
        }

        public List<Movie> GetFilteredMovies(string keyword)
        {
            List<Movie> allMovies = GetMovies();

            List<Movie> filteredMovies = allMovies
                .Where(movie => movie.Name.Contains(keyword))
                .ToList();

            return filteredMovies;
        }

        public void AddDummyMovies()
        {
            Movie dummy1 = new Movie(0, "Dummy 1", "This is a dummy movie", 120);
            Movie dummy2 = new Movie(1, "Dummy 2", "This is a dummy movie", 120);
            Movie dummy3 = new Movie(2, "Dummy 3", "This is a dummy movie", 120);

            List<Movie> dummyMovies = new List<Movie>() { dummy1, dummy2, dummy3 };

            string jsonString = JsonConvert.SerializeObject(dummyMovies);
            File.WriteAllText(db, jsonString);
        }
    }
}
