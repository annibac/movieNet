using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MovieNet.Main.ViewModel;

namespace MovieNet.Main
{
    class TestCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Window window = App.Current.MainWindow;
            UserViewModel viewModel = new UserViewModel();

            window.DataContext = viewModel;
        }
    }
}
