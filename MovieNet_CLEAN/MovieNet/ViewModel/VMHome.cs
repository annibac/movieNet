using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MovieNet.NavHelper;
using GalaSoft.MvvmLight.CommandWpf;


namespace MovieNet.ViewModel
{
    public class VMHome : ViewModelBase
    {
        private INavService _navigationService;

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand
                    ?? (_loginCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Login");
                    }));
            }
        }
        private RelayCommand _subscribeCommand;

        public RelayCommand SubscribeCommand
        {
            get
            {
                return _subscribeCommand
                       ?? (_subscribeCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Subscribe");
                           }));
            }
        }

        public VMHome(INavService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}

