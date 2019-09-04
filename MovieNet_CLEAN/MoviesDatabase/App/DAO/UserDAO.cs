using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.App.Interface;

namespace MoviesDatabase.App.DAO
{
    class UserDAO : IUserDAO
    {
        private DataModelContainer ctx;

        public UserDAO()
        {
            this.ctx = new DataModelContainer();
        }

        public User CreateUser(User user)
        {
            ctx.UserSet.Add(user);
            ctx.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            User toUpdate = ctx.UserSet.Where(u => u.Id == user.Id).FirstOrDefault();
            toUpdate.Firstname = user.Firstname;
            toUpdate.Lastname = user.Lastname;
            toUpdate.Login = user.Login;
            toUpdate.Password = user.Password;
            toUpdate.Email = user.Email;
            if (toUpdate.Equals(user))
            {
                ctx.SaveChanges();
                return toUpdate;
            }
            else
            {
                throw new Exception("Update failed");
            }
        }

        public bool DeleteUser(User user)
        {
            User toDelete = ctx.UserSet.Where(u => u.Id == user.Id).FirstOrDefault();
            ctx.UserSet.Remove(toDelete);
            ctx.SaveChanges();
            return true;
        }

        public List<User> GetAllUsers()
        {
            return ctx.UserSet.ToList();
        }

        public User GetUser(int uid)
        {
            return ctx.UserSet.Where(u => u.Id == uid).FirstOrDefault();
        }

        public User LogUser(string username, string pass)
        {
            return ctx.UserSet
                .Where(u => u.Login == username && pass == u.Password)
                .Select(u => u).FirstOrDefault();
        }
    }
}
