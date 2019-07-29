
namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Plugin.ValidationRules;
    using ProyectRefit.Interface;
    using ProyectRefit.Models;
    using ProyectRefit.Validation;
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class RegisterUserViewModel : BaseViewModel
    {
        private ValidationUnit _unit;

        public ValidatableObject<string> FirstName { get; set; }
        public ValidatableObject<string> LastName { get; set; }
        public ValidatableObject<string> Address { get; set; }
        public ValidatableObject<string> Tel { get; set; }
        public ValidatableObject<string> Email { get; set; }
        public ValidatableObject<string> Password { get; set; }

        public ICommand CreateCountCommand => new RelayCommand(CreateCountUser);

        public RegisterUserViewModel()
        {
            //aqui instaciamos el changed de las propiedades
            FirstName = new ValidatableObject<string>();
            LastName = new ValidatableObject<string>();
            Email = new ValidatableObject<string>();
            Address = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();
            Tel = new ValidatableObject<string>();
            //le pasamos los parametros que queremos validar 
            _unit = new ValidationUnit(FirstName,LastName,Address,Tel,Email,Password);
            AddValidations();
        }

        private async void CreateCountUser()
        {
            if (!Validate()) {
               await Application.Current.MainPage.DisplayAlert(
                    "Alert",
                    "Revise los campos",
                    "Ok");
            }
            else
            {
                var user = new User
                {
                    Email = this.Email.ToString(),
                    Passowrd = this.Password.ToString(),
                    FirstName = this.FirstName.ToString(),
                    LastName = this.LastName.ToString(),
                    Address = this.Address.ToString(),
                    Tell = this.Tel.ToString()

                };
                var url = Application.Current.Resources["UrlApi"].ToString();
                var response =  RestService.For<IApiService>(url);
                var answer = response.PostUser(user);

                if (response != null)
                {
                    await Application.Current.MainPage.DisplayAlert(
                         "Acetado",
                         "Se ha creado su usuario",
                         "Ok");
                    return;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Se cancelo la respuesta de datos",
                        "Ok");
                    return;
                }
            }
        }

        private void AddValidations()
        {
            //  validations
            FirstName.Validations.Add(new ValidationIsNull<string> { ValidationMessage = "El nombre es requerido." });
            LastName.Validations.Add(new ValidationIsNull<string> { ValidationMessage = "El apellido es requerido." });
         
            Address.Validations.Add(new ValidationIsNull<string> { ValidationMessage = "La direccion es requerido." });
            Password.Validations.Add(new ValidationIsNull<string> { ValidationMessage = "La contrasena es requerido." });
            Tel.Validations.Add(new ValidationIsNull<string> { ValidationMessage = "El telefono es requerido." });
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
