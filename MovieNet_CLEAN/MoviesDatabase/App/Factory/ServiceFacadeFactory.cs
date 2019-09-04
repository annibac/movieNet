using MoviesDatabase.App.Interface;
using MoviesDatabase.ServiceFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.App.Factory
{
    public class ServiceFacadeFactory
    {
        static IServiceFacade serviceFacade = null;
        static public IServiceFacade GetServiceFacade()
        {

            if (null == serviceFacade)
            {
                serviceFacade = ServiceFacade.ServiceFacade.Instance;
            }

            return serviceFacade;
        }
    }
}
