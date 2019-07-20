using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;


namespace MovieNet
{
    public class MoviesList : ViewModelBase
    {
        public MoviesList()
        {
            Title = "Welcome to movies list !";
            GoToList = new RelayCommand(GoToListExecute, GoToListCanExecute);
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand GoToList { get; } 

        void GoToListExecute()
        {
            Title = "Almost there...";
        }

        bool GoToListCanExecute()
        {
            return true;
        }
    }
}
