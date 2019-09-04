using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MovieNet.NavHelper;
using MoviesDatabase.App.Factory;
using MoviesDatabase.App.Interface;
using GalaSoft.MvvmLight.CommandWpf;
using MoviesDatabase;

namespace MovieNet.ViewModel
{
    public class VMMovies : ViewModelBase
    {
        private static IServiceFacade Services { get; } = ServiceFacadeFactory.GetServiceFacade();
        private static IMoviesDAO MoviesDao { get; } = Services.GetMoviesDAO();
        private INavService _navigationService;

        private string _name;
        private string _genre;
        private string _description;

        private Movies _movie;


        public RelayCommand AddNewMovie { get; }
        public RelayCommand EditMovie { get; }
        public string Name { get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
    public string Genre { get => _genre;
            set {
                _genre = value;
                RaisePropertyChanged("Genre");
            }
        }
        public string Description { get => _description; set { _description = value; RaisePropertyChanged("Description");  } }
        public Movies Movie { get => _movie; set => _movie = value; }

        public VMMovies(INavService navigationService)
        {
            _navigationService = navigationService;

            AddNewMovie = new RelayCommand(AddMovieAction, CanAddMovieAction);
            EditMovie = new RelayCommand(EditMovieAction, CanAddMovieAction);
        }

        void AddMovieAction()
        {
            Movies m = new Movies();
            m.Description = Description;
            m.Genre = Genre;
            m.Name = Name;
            Movies nm = MoviesDao.CreateMovie(m);

            if (nm != null)
            {
                ClearInputs();
                _navigationService.NavigateTo("ShowMovies");
            }
        }

        bool CanAddMovieAction()
        {
            if (!string.IsNullOrEmpty(Genre) && !string.IsNullOrEmpty(Description)
                && !string.IsNullOrEmpty(Name))
                return true;
            return false;
        }

        void EditMovieAction()
        {
            Movie.Name = Name;
            Movie.Genre = Genre;
            Movie.Description = Description;
            var up = MoviesDao.UpdateMovie(Movie);

            if (up != null)
            {
                ClearInputs();
                _navigationService.NavigateTo("ShowMovies");
            }
        }

        public void ClearInputs()
        {
            Name = "";
            Genre = "";
            Description = "";

            Movie = _navigationService.Parameter as Movies;
            if (Movie != null)
            {
                Name = Movie.Name;
                Description = Movie.Description;
                Genre = Movie.Genre;
            }
        }

    }
}
