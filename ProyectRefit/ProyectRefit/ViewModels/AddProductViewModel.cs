
namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectRefit.Interface;
    using ProyectRefit.Models;
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AddProductViewModel:BaseViewModel
    {
        private bool isToggled;
        private bool isRunning;
        private Product product;
        private bool isEnabled;
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsToggled {
            get => isToggled;
            set => SetValue(ref isToggled,value);
        }
        public bool IsRunning
        {
            get => isRunning;
            set => SetValue(ref isRunning,value);
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }
        public ICommand ConfirmarCommand => new RelayCommand(RegisterProduct);

        public AddProductViewModel()
        {
            isToggled = true;
            product = new Product();
        }

        private async void RegisterProduct()
        {
            try
            {
                if (parametros())
                {
                    await Application.Current.MainPage.DisplayAlert(
                       "Error",
                       "No puede dejar ningun campo vacio",
                       "Ok");
                    return;
                }
              
                //isEnabled = true;
                IsRunning = true;
                product.Image = "image";
                product.Name = Name;
                product.Description = Description;
                product.IsAvalible = true;
                product.Price = Price;
                var url = Application.Current.Resources["UrlApi"].ToString();
                var apiService = RestService.For<IApiService>(url);
                var response =  apiService.PostProduct(product);
                if (response.IsCompleted)
                {
                   await Application.Current.MainPage.DisplayAlert(
                        "Acetado",
                        "Se ha guardado el producto",
                        "Ok");
                    return;
                }else if (response.IsCanceled)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Se cancelo la respuesta de datos",
                        "Ok");
                    return;
                }
                IsRunning = false;
               // IsEnabled = false;
            }
            catch (Exception )
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Error al enviar los datos",
                    "Ok");
                IsRunning = false;
               // IsEnabled = false;sasadxas
            }
        }
        public bool parametros() {
            if (string.IsNullOrEmpty(Description)||string.IsNullOrEmpty(Name)||Price<0)
            {
                return true;
            }
            return false;
        }
    }
}
