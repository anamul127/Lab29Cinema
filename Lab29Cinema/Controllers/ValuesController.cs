using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab29Cinema.Models;

namespace Lab29Cinema.Controllers
{
    public class ValuesController : ApiController
    {
        MoviesDBEntities db = new MoviesDBEntities();
        Random rand = new Random();

        //1. Get a List of all movies.
        public List<Cinema> GetMovie()
        {
            List<Cinema> movie = db.Cinemas.ToList();

            return movie;
        }

        //2. Get movies by specific category
        public List<Cinema> GetMovieByCategory(string id)
        {
            List<Cinema> movie = (from m in db.Cinemas where m.Category == id select m).ToList();

            return movie;
        }

        //3. Get a random movie pick.
        public Cinema GetRandMovie()
        {
            int id = rand.Next(1, (db.Cinemas.Count() + 1));

            Cinema movie = (from m in db.Cinemas where m.ID == id select m).Single();

            return movie;
        }

        //4. Get random movie from a specific category.
        public Cinema GetRandMovieAgain(string id)
        {
            List<Cinema> movies = (from m in db.Cinemas where m.Category == id  select m).ToList();

            int num = rand.Next(0, movies.Count);
            Cinema movie = movies[num];

            return movie;
        }

        //8. Get movies with a keyword in their title
        public List<Cinema> GetMovieByKeyword(string key)
        {
            List<Cinema> movies = (from m in db.Cinemas where m.Title.Contains(key) select m).ToList();

            return movies;

        }
    }
}
