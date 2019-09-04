using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNet.ViewModel;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MovieNet.NavHelper;

namespace MovieNet
{
    public class VM_locator
    {
        static VM_locator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<VMMain>();
            SimpleIoc.Default.Register<VMShowMovies>();
            SimpleIoc.Default.Register<VMShowUsers>();
            SimpleIoc.Default.Register<VMHome>();
            SimpleIoc.Default.Register<VMUsers>();
            SimpleIoc.Default.Register<VMMovies>();
            SetupNavigation();
        }
        private static void SetupNavigation()
        {
            var navigationService = new NavService();
            navigationService.Configure("Home", new Uri("../View/Home.xaml", UriKind.Relative));
            navigationService.Configure("Subscribe", new Uri("../View/AddUser.xaml", UriKind.Relative));
            navigationService.Configure("Login", new Uri("../View/Login.xaml", UriKind.Relative));
            navigationService.Configure("ShowMovies", new Uri("../View/AllMovies.xaml", UriKind.Relative));
            navigationService.Configure("ShowUsers", new Uri("../View/AllUsers.xaml", UriKind.Relative));
            navigationService.Configure("AddMovie", new Uri("../View/AddMovie.xaml", UriKind.Relative));
            navigationService.Configure("InfoMovie", new Uri("../View/InfoMovie.xaml", UriKind.Relative));
            navigationService.Configure("InfoUser", new Uri("../View/InfoUser.xaml", UriKind.Relative));
            navigationService.Configure("EditMovie", new Uri("../View/EditMovie.xaml", UriKind.Relative));
            navigationService.Configure("EditUser", new Uri("../View/EditUser.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<INavService>(() => navigationService);
        }

        public VMMain Main
        {
            get { return ServiceLocator.Current.GetInstance<VMMain>(); }
        }

        public VMShowMovies ShowMovies
        {
            get {
                ServiceLocator.Current.GetInstance<VMShowMovies>().GetMovies();
                return ServiceLocator.Current.GetInstance<VMShowMovies>();
            }
        }
        public VMShowUsers ShowUsers
        {
            get {
                ServiceLocator.Current.GetInstance<VMShowUsers>().GetUsers();
                return ServiceLocator.Current.GetInstance<VMShowUsers>();
            }
        }
        public VMHome Home
        {
            get { return ServiceLocator.Current.GetInstance<VMHome>(); }
        }
        public VMUsers Users
        {
            get {
                ServiceLocator.Current.GetInstance<VMUsers>().ClearInputs();
                return ServiceLocator.Current.GetInstance<VMUsers>(); }
        }

        public VMMovies Movies
        {
            get {
                ServiceLocator.Current.GetInstance<VMMovies>().ClearInputs();
                return ServiceLocator.Current.GetInstance<VMMovies>();
            }
        }
    }
}
