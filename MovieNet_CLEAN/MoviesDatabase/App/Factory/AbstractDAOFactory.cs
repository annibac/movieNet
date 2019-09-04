using MoviesDatabase.App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.App.Factory
{
    abstract class AbstractDAOFactory
    {
        public abstract IUserDAO getUserDAO();

        public abstract IMoviesDAO getMovieDAO();

        public abstract IRateDAO getRateDAO();

        public static AbstractDAOFactory getFactory()
        {
            return new DAOFactory();
        }
    }
}