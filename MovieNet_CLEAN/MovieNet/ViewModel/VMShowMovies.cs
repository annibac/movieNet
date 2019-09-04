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
    public class VMShowMovies : ViewModelBase
    {
        private static IServiceFacade Services { get; } = ServiceFacadeFactory.GetServiceFacade();
        private static IMoviesDAO MoviesDao { get; } = Services.GetMoviesDAO();
        private ObservableCollection<Movies> _movies;
        private Movies _selectedItem;

        private INavService _navigationService;
        private RelayCommand _addMovie;
        private RelayCommand _showUsers;
        public RelayCommand EditMovie { get; }
        public RelayCommand InfoMovie { get; }
        public RelayCommand DeleteMovie { get; }


        public VMShowMovies(INavService navigationService)
        {
            _navigationService = navigationService;
            GetMovies();

            InfoMovie = new RelayCommand(InfoAction, CanAction);
            EditMovie = new RelayCommand(EditAction, CanAction);
            DeleteMovie = new RelayCommand(DeleteAction, CanAction);

        }

        public void GetMovies()
        {
            Movies = new ObservableCollection<Movies>(MoviesDao.GetAllMovies());
        }

        public ObservableCollection<Movies> Movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                RaisePropertyChanged("Movies");
            }
        }
        public Movies SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != null)
                    Console.WriteLine(_selectedItem.Name);
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public RelayCommand AddMovie
        {
            get
            {
                return _addMovie
                    ?? (_addMovie = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("AddMovie");
                    }));
            }
        }

        public RelayCommand ShowUsers
        {
            get
            {
                return _showUsers
                    ?? (_showUsers = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("ShowUsers");
                    }));
            }
        }


        void InfoAction()
        {
            _navigationService.NavigateTo("InfoMovie", SelectedItem);
        }

        bool CanAction()
        {
            return SelectedItem != null;
        }

        void EditAction()
        {
            _navigationService.NavigateTo("EditMovie", SelectedItem);
        }

        void DeleteAction()
        {
            MoviesDao.DeleteMovie(SelectedItem);
            GetMovies();
            _navigationService.NavigateTo("ShowMovies");
        }

    }
}
