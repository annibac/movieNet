using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MoviesDatabase.App.Factory;
using MoviesDatabase.App.Interface;
using MoviesDatabase;
using System.Collections.ObjectModel;
using MovieNet.NavHelper;

namespace MovieNet.ViewModel
{
    public class VMShowUsers : ViewModelBase
    {
        private static IServiceFacade Services { get; } = ServiceFacadeFactory.GetServiceFacade();
        private static IUserDAO UserDAO { get; } = Services.GetUserDAO();
        private ObservableCollection<User> _users;

        private User _selectedItem;
        private INavService _navigationService;
        private RelayCommand _addUser;
        private RelayCommand _showMovies;


        public RelayCommand EditUser { get; }
        public RelayCommand InfoUser { get; }
        public RelayCommand DeleteUser { get; }

        public VMShowUsers(INavService navigationService)
        {
            _navigationService = navigationService;
            InfoUser = new RelayCommand(InfoAction, CanAction);
            EditUser = new RelayCommand(EditAction, CanAction);
            DeleteUser = new RelayCommand(DeleteAction, CanAction);
            GetUsers();
        }

        public void GetUsers()
        {
            Users = new ObservableCollection<User>(UserDAO.GetAllUsers());
        }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged("Users");
            }
        }

        public User SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public RelayCommand AddUser
        {
            get
            {
                return _addUser
                    ?? (_addUser = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Subscribe");
                    }));
            }
        }

        void InfoAction()
        {
            _navigationService.NavigateTo("InfoUser", SelectedItem);
        }

        bool CanAction()
        {
            return SelectedItem != null;
        }

        void EditAction()
        {
            _navigationService.NavigateTo("EditUser", SelectedItem);
        }

        void DeleteAction()
        {
            UserDAO.DeleteUser(SelectedItem);
            GetUsers();
            _navigationService.NavigateTo("ShowUsers");
        }

        public RelayCommand ShowMovies
        {
            get
            {
                return _showMovies
                    ?? (_showMovies = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("ShowMovies");
                    }));
            }
        }

    }
}
