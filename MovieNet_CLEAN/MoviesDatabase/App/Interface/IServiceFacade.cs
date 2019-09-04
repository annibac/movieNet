using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.App.Interface
{
    public interface IServiceFacade
    {
        IRateDAO GetRateDAO();
        IMoviesDAO GetMoviesDAO();
        IUserDAO GetUserDAO();
    }
}
