
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

    public class EditViewModel:BaseViewModel
    {
        private bool isRunning;
        private bool isEnabled;
        public Product Product { get; set; }
        public bool IsRunning
        {
            get => isRunning;
            set => SetValue(ref isRunning,value);
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set => SetValue(ref isEnabled,value);
        }

        public ICommand SaveCommand => new RelayCommand(SaveProduct);
        public ICommand DeleteCommand => new RelayCommand(DeleteProduct);

        public EditViewModel(Product product)
        {
            this.Product = product;
        }

        private async void DeleteProduct()
        {
            try
            {
                IsRunning = true;
                IsEnabled = true;
                var url = Application.Current.Resources["UrlApi"].ToString();
                var response = RestService.For<IApiService>(url);
                var answer =  response.DelateProduct(Product.Id);
                if (answer!=null)
                {
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Se ha eliminado el producto",
                    "Ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Error en eliminar el product",
                    "Ok");
                }
                IsRunning = false;
                IsEnabled = false;
            }
            catch (Exception ex)
            {
               await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Error en la peticion",
                    "Ok");
                IsRunning = false;
                IsEnabled = false;
            }
        }

        private void SaveProduct()
        {
            throw new NotImplementedException();
        }
    }
}
