using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.NavHelper;
using MoviesDatabase.App.Factory;
using MoviesDatabase.App.Interface;
using MoviesDatabase;
using System.ComponentModel;

namespace MovieNet.ViewModel
{
    public class VMUsers : ViewModelBase
    {
        private static IServiceFacade Services { get; } = ServiceFacadeFactory.GetServiceFacade();
        private static IUserDAO UserDao { get; } = Services.GetUserDAO();
        protected INavService _navigationService;

        private User _user;


        // for login & subscribe view
        private string _incorrectLogin = "";
        private string _username;
        private string _password;

        // for subscribe view only
        private string _firstname;
        private string _lastname;
        private string _email;

        public string IncorrectLogin
        {
            get
            {
                return _incorrectLogin;
            }

            set
            {
                _incorrectLogin = value;
                RaisePropertyChanged();
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                RaisePropertyChanged("Firstname");
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                RaisePropertyChanged("Lastname");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        public RelayCommand<object> Login { get; }
        public RelayCommand<object> Subscribe { get; }
        public RelayCommand EditUser { get; }
        public User User { get => _user; set => _user = value; }

        public VMUsers(INavService navigationService)
        {
            _navigationService = navigationService;
            ClearInputs();
            Login = new RelayCommand<object>(LoginAction, CanLoginAction);
            Subscribe = new RelayCommand<object>(SubscribeAction, CanSubscribeAction);
            EditUser = new RelayCommand(EditUserAction, CanEditUserAction);

        }

        void LoginAction(object obj)
        {
            _password = ((System.Windows.Controls.PasswordBox)obj).Password;
            User user = UserDao.LogUser(_username, _password);

            if (user != null)
            {
                ClearInputs();
                _navigationService.NavigateTo("ShowMovies");
            }
            else
                IncorrectLogin = "Oups! Votre login ou mot de passe semble incorrect.";
        }

        bool CanLoginAction(object obj)
        {
            Console.WriteLine(Username);
            Console.WriteLine(Password);
            return !string.IsNullOrEmpty(Username);
        }

        void SubscribeAction(object obj)
        {
            _password = ((System.Windows.Controls.PasswordBox)obj).Password;
            User u = new User(_firstname, _lastname, _email, _username, _password);
            User user = UserDao.CreateUser(u);

            if (user != null)
            {
                ClearInputs();
                _navigationService.NavigateTo("ShowMovies");
            }
            else
                IncorrectLogin = "Une erreur est survenue.";
        }

        bool CanSubscribeAction(object obj)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Firstname)
                || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Lastname))
                return false;
            return true;
        }

        bool CanEditUserAction()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Firstname)
                || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Lastname))
                return false;
            return true;
        }

        void EditUserAction()
        { 
            User.Login = Username;
            User.Password = Password;
            User.Lastname = Lastname;
            User.Firstname = Firstname;
            User.Email = Email;
            var up = UserDao.UpdateUser(User);

            if (up != null)
            {
                ClearInputs();
                _navigationService.NavigateTo("ShowUsers");
            }
        }

        public void ClearInputs()
        {
            Firstname = "";
            Lastname = "";
            IncorrectLogin = "";
            Username = "";
            Password = "";
            Email = "";

            User = _navigationService.Parameter as User;
            if (User != null)
            {
                Username = User.Login;
                Password = User.Password;
                Lastname = User.Lastname;
                Firstname = User.Firstname;
                Email = User.Email;
            }
        }
    }


}
