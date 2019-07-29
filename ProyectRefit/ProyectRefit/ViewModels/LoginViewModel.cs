

namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Plugin.ValidationRules;
    using ProyectRefit.Validation;
    using ProyectRefit.Views;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel:BaseViewModel
    {
        private ValidationUnit _unit;
        private bool isRunning;
        private bool isVisible;

        public ValidatableObject<string> Email { get; set; }
        public ValidatableObject<string> Password { get; set; }

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
        public ICommand RegisterUserCommand => new RelayCommand(GoToRegisterUser);

        public LoginViewModel()
        {
            IsVisible = true;
            Email = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();
            _unit = new ValidationUnit( Email, Password);
            AddValidations();
        }

        private async void Login()
        {
            IsVisible = false;
            IsRunning = true;
            if (!Validate())
            {
                return;
            }
            else
            {
               
                Application.Current.MainPage = new MasterPage();
                IsRunning = false;
                IsVisible = true;
            }
        }

        private async void GoToRegisterUser()
        {
            MainViewModel.GetInstance().RegisterUser = new RegisterUserViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterUserPage());
        }

        private void AddValidations()
        {
            //  validations 
            Password.Validations.Add(new ValidationIsNull<string> { ValidationMessage = "La contrasena es requerido." });
            //Email validations
            Email.Validations.Add(new ValidationIsNull<string> { ValidationMessage = "El email es requerido" });
            Email.Validations.Add(new EmailRule<string> { ValidationMessage = "Email no valido" });
        }

        public bool Validate()
        {
            //return isValidName && isValidLastname && isValidEmail;
            return _unit.Validate();
        }
    }
}
