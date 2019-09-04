using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNet.Main.Model
{
    public class UserModel : INotifyPropertyChanged
    {
        private long id;
        private string firstname;
        private string lastname;
        private DateTime dateOfBirth;
        private string login;
        private string password;
        private string confirmation;
        private string email;
        private string civility;

        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Confirmation
        {
            get
            {
                return (confirmation);
            }
            set
            {
                confirmation = value;
                OnPropertyChanged("Confirmation");
            }
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Civility
        {
            get
            {
                return civility;
            }
            set
            {
                civility = value;
                OnPropertyChanged("Civility");
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
