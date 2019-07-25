

namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectRefit.Views;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel:BaseViewModel
    {
        
        private bool isRunning;
        private bool isVisible;

        public string Email { get; set; }
        public string Password { get; set; }
        
        public bool IsVisible
        {
            get => isVisible;
            set => SetValue(ref isVisible, value);
        }

        public bool IsRunning {
            get => isRunning;
            set => SetValue(ref isRunning,value);
        }
        public ICommand LoginCommand => new RelayCommand(Login);
        public LoginViewModel()
        {
            IsVisible = true;
        }

        private async void Login()
        {
            IsVisible = false;
            IsRunning = true;
            if (Parametro())
            {
               await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "No puedes dejar ningun campo vacio",
                    "Ok");
            }
            else
            {
                MainViewModel.GetInstance().Products = new ProductViewModel();
               await Application.Current.MainPage.Navigation.PushAsync(new ProductPage());
                IsRunning = false;
                IsVisible = true;
            }
        }
        private bool Parametro()
        {
            if (string.IsNullOrEmpty(Email)||string.IsNullOrEmpty(Password))
            {
                return true;
            }
            return false;
        }
    }
}
