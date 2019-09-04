using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;


namespace MovieNet.NavHelper
{
    public interface INavService : INavigationService
    {
        object Parameter { get; }
    }
}
