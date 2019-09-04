using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.App.Interface
{
    public interface IMoviesDAO
    {
        Movies CreateMovie(Movies movie);
        Movies UpdateMovie(Movies movie);
        List<Movies> SearchMovies(string query);
        Boolean DeleteMovie(Movies movie);
        Movies GetMovie(int fid);
        List<Movies> GetAllMovies();
    }
}