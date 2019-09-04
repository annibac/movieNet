using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNet.Main.Model;
using MovieNet.Main.View;
using System.Windows.Controls;

namespace MovieNet.Main.ViewModel
{
    public class UserViewModel
    {
        public UserModel loginUser { get; set; }
        public UserModel registerUser { get; set; }
        public AuthenticateUserCommand authenticateUserCommand { get; set; }
        public RegisterUserCommand registerUserCommand { get; set; }
        public UserControl View { get; set; }

        public UserViewModel()
        {
            this.loginUser = new UserModel();
            this.registerUser = new UserModel();
            this.authenticateUserCommand = new AuthenticateUserCommand(this.loginUser);
            this.registerUserCommand = new RegisterUserCommand(this.registerUser);
            this.View = new Home();
        }
    }
}
