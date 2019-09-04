using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabase.App.Interface
{
    public interface IUserDAO
    {
        User CreateUser(User user);
        User UpdateUser(User user);
        Boolean DeleteUser(User user);
        User GetUser(int uid);
        List<User> GetAllUsers();
        User LogUser(string username, string pass);
    }
}