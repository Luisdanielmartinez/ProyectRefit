
namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectRefit.Models;
    using ProyectRefit.Views;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ProductItemViewModel:Product
    {
        public ICommand SelectProductCommand=>new RelayCommand(this.SelectProduct);

        private async void SelectProduct()
        {
            MainViewModel.GetInstance().EditProduct = new EditViewModel((Product)this);
            await App.Navigator.PushAsync(new EditProductPage());
        }
    }
}
