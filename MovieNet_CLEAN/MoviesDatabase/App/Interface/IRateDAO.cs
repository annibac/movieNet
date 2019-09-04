using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoviesDatabase.App.Interface
{
    public interface IRateDAO
    {
        Rate CreateRate(Rate rate);
        Rate UpdateRate(Rate rate);
        Boolean DeleteRate(Rate rate);
        Rate GetRate(int id);
        List<Rate> getAllRates();
    }
}