using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.App.DAO;
using MoviesDatabase.App.Interface;

namespace MoviesDatabase.App.Factory
{
    class DAOFactory : AbstractDAOFactory
    {
        public override IRateDAO getRateDAO()
        {
            return new RateDAO();
        }

        public override IMoviesDAO getMovieDAO()
        {
            return new MoviesDAO();
        }

        public override IUserDAO getUserDAO()
        {
            return new UserDAO();
        }
    }
}
