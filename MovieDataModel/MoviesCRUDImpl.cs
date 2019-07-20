using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataModel
{
    public class MoviesCRUDImpl : MoviesCRUD
    {
        private DataModelContainer ctx;
        private static MoviesCRUD instance = null;

        private MoviesCRUDImpl()
        {
            this.ctx = new DataModelContainer();
        }

        public static MoviesCRUD getInstance()
        {
            if (instance == null)
            {
                instance = new MoviesCRUDImpl();
            }
            return (instance);
        }


        public Movies AddOne(String name, String description, String genre)
        {
            var movie = new Movies
            {
                description = description,
                name = name,
                genre = genre
            };

            this.ctx.MoviesSet.Add(movie);
            this.ctx.SaveChanges();
            return movie;
        }

        public Movies UpdateOne(Movies movie)
        {
            Movies db_movie = this.ctx.MoviesSet.Find(movie.Id);
            if (db_movie == null)
            {
                return (null);
            }

            db_movie.name = movie.name;
            db_movie.description = movie.description;
            db_movie.genre = movie.genre;

            this.ctx.SaveChanges();
            return movie;
        }

        public Movies FindOne(int id)
        {
            return this.ctx.MoviesSet.Find(id);
        }

        public bool DeleteOne(Movies movie)
        {
            Movies db_movie = this.ctx.MoviesSet.Find(movie.Id);

            if (this.ctx.MoviesSet.Remove(db_movie) != null)
              {
                 this.ctx.SaveChanges();
                 return (true);
              }
            return (false);
        }

        public List<Movies> FindAll()
        {
            return this.ctx.MoviesSet.ToList();
        }
    }
}
