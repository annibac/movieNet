using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MovieNet.NavHelper;


namespace MovieNet.ViewModel
{
    public class VMMain : ViewModelBase
    {
        private INavService _navigationService;
        private RelayCommand _loadedCommand;
        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Home");
                    }));
            }
        }

        public VMMain(INavService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
