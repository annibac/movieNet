using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataModel
{
    public interface MoviesCRUD
    {
        List<Movies> FindAll();
        Movies FindOne(int id);
        Movies AddOne(String name, String description, String genre);
        bool DeleteOne(Movies movie);
        Movies UpdateOne(Movies movie);
    }
}
