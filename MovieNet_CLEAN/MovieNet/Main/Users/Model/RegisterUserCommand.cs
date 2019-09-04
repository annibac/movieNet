using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MoviesDatabase.App.DAO;
using MoviesDatabase.App;
using MoviesDatabase;
using System.Windows.Input;


namespace MovieNet.Main.Model
{
    public class RegisterUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public UserModel userModel;
        private ServiceFacade serviceFacade;

        public RegisterUserCommand(UserModel userModel)
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
            User user = new User();

            user.Login = this.userModel.Login;
            user.Password = this.userModel.Password;
            user.Firstname = this.userModel.Firstname;
            user.Lastname = this.userModel.Lastname;
            user.Email = this.userModel.Email;
            user.DateOfBirth = DateTime.Now.ToString("yyyy/M/dd "); ;
            user.Civility = this.userModel.Civility;
            if (!this.userModel.Confirmation.Equals(this.userModel.Password))
            {
                return;
            }
            int id = serviceFacade.UserDAO.Persist(user);
            if (id > -1)
            {
                user.Id = id;
                TestViewModel testViewModel = new TestViewModel();

                App.Current.MainWindow.DataContext = testViewModel;
            }
        }
    }
}
