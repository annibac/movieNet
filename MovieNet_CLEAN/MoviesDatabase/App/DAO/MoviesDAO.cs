using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.App.Interface;
using MoviesDatabase;

namespace MoviesDatabase.App.DAO
{
    class MoviesDAO : IMoviesDAO
    {
        private DataModelContainer ctx;

        public MoviesDAO()
        {
            this.ctx = new DataModelContainer();
        }

        public Movies CreateMovie(Movies movie)
        {
            ctx.MoviesSet.Add(movie);
            ctx.SaveChanges();
            return movie;
        }

        public bool DeleteMovie(Movies movie)
        {
            Movies toDelete = ctx.MoviesSet.Where(m => m.Id == movie.Id).FirstOrDefault();
            ctx.MoviesSet.Remove(toDelete);
            ctx.SaveChanges();
            return true;
        }

        public List<Movies> SearchMovies(string query)
        {
            DataModelContainer ctx = new DataModelContainer();
            List<string> query_words = query.Split(' ', ',').ToList();
            List<Movies> results = ctx.MoviesSet.Where(m => query_words.Any(q => m.Name.Contains(q) || m.Genre.Contains(q) || m.Description.Contains(q))).ToList();
            return results;

        }

        public List<Movies> GetAllMovies()
        {
            return this.ctx.MoviesSet.ToList();
        }

        public Movies GetMovie(int mid)
        {
            return ctx.MoviesSet.Where(m => m.Id == mid).FirstOrDefault();
        }

        public Movies UpdateMovie(Movies movie)
        {
            Movies toUpdate = ctx.MoviesSet.Where(m => m.Id == movie.Id).FirstOrDefault();
            toUpdate.Name = movie.Name;
            toUpdate.Genre = movie.Genre;
            toUpdate.Description = movie.Description;
            toUpdate.Rate = movie.Rate;
            if (toUpdate.Equals(movie))
            {
                ctx.SaveChanges();
                return toUpdate;
            }
            else
            {
                throw new Exception("Update movie failed");
            }
        }
    }
}
