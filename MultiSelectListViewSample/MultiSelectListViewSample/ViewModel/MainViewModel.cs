using MultiSelectListViewSample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace MultiSelectListViewSample.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Property

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        public MultiSelectObservableCollection<User> Users { get; }

        //public ICommand DisplayNameCommand => new Command<string>(async name =>
        //{
        //   await Application.Current.MainPage.DisplayAlert("Selected Name", name, "OK");
        //});

        public ICommand DisplayNameCommand => new Command<User>(async user =>
        {
            await Application.Current.MainPage.DisplayAlert("Selected Name", user.Name, "OK");
        });


        public MainViewModel()
        {
            Users = new MultiSelectObservableCollection<User>();

            User user = new User();
            user.Name = "Bertuzzi";
            Users.Add(user);

            Users[0].IsSelected = true;

            user = new User();
            user.Name = "Bruna";
            Users.Add(user);

            user = new User();
            user.Name = "Polly";
            Users.Add(user);

            user = new User();
            user.Name = "Rodolfo";
            Users.Add(user);

            user = new User();
            user.Name = "Lester";
            Users.Add(user);


        }


    }
}
