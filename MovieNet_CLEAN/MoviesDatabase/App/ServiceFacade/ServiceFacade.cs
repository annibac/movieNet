using MoviesDatabase.App.Factory;
using MoviesDatabase.App.Interface;

namespace MoviesDatabase.ServiceFacade
{
    public sealed class ServiceFacade : IServiceFacade
    {
        private static ServiceFacade instance = null;
        private static readonly object padlock = new object();

        private IUserDAO userDao = null;
        private IMoviesDAO moviesDao = null;
        private IRateDAO rateDao = null;

        ServiceFacade()
        {
            rateDao = AbstractDAOFactory.getFactory().getRateDAO();
            moviesDao = AbstractDAOFactory.getFactory().getMovieDAO();
            userDao = AbstractDAOFactory.getFactory().getUserDAO();
        }

        public static ServiceFacade Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceFacade();
                    }
                    return instance;
                }
            }
        }

        public IRateDAO GetRateDAO()
        {
            return rateDao;
        }

        public IMoviesDAO GetMoviesDAO()
        {
            return moviesDao;
        }

        public IUserDAO GetUserDAO()
        {
            return userDao;
        }
    }
}