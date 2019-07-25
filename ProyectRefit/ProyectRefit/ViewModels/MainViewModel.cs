
namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectRefit.Views;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainViewModel
    {
        public static MainViewModel mainViewModel{ get; set; }
        public  LoginViewModel Login { get; set; }
        public AddProductViewModel AddProduct { get; set; }
        public PostViewModel Post { get; set; }
        public EditViewModel EditProduct { get; set; }
        public ProductViewModel Products { get; set; }
        public ICommand AddProductCommand => new RelayCommand(GoToProduct);

        public MainViewModel()
        {
            mainViewModel = this;
        }

        public static MainViewModel GetInstance()
        {
            if (mainViewModel==null) {
                mainViewModel = new MainViewModel();
            }
            return mainViewModel;
        }

        public void GoToProduct()
        {
            this.AddProduct = new AddProductViewModel();
            Application.Current.MainPage.Navigation.PushAsync(new AddProductPage());
            
        }
    }
}
