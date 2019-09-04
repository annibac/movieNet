using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MoviesDatabase.App.DAO;
using MoviesDatabase.App;
using MoviesDatabase;

namespace MovieNet.Main.Model
{
    public class AuthenticateUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private UserModel userModel;
        private ServiceFacade serviceFacade;

        public AuthenticateUserCommand(UserModel userModel)
        {
            this.userModel = userModel;
            this.serviceFacade = new ServiceFacade();
        }

        public bool CanExecute(object parameter)
        {
            return (true);
        }

        public void Execute(object parameter)
        {
            Window window = App.Current.MainWindow;
            User user = this.serviceFacade.UserDAO.Authenticate(this.userModel.Login, this.userModel.Password);

            if (user != null)
            {
                TestViewModel viewModel = new TestViewModel();

                window.DataContext = viewModel;
            }
        }
    }
}
