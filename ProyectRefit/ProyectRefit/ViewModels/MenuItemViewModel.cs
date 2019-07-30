

namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectRefit.Views;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    //esta la clase que va a controlar el menu
    public class MenuItemViewModel: ProyectRefit.Models.Menu
    { 

        public ICommand SelectMenuCommand => new RelayCommand(SelectMenu);

        private async void SelectMenu()
        {
            App.Master.IsPresented = false;
            var mainViewModel = MainViewModel.GetInstance();
            switch (this.PageName)
            {
                case "mapaPage":
                   // MainViewModel.GetInstance().AddProduct = new AddProductViewModel();
                    await App.Navigator.PushAsync(new MapPage());
                    break;
                case "AddProduct":
                    MainViewModel.GetInstance().AddProduct = new AddProductViewModel();
                    await App.Navigator.PushAsync(new AddProductPage());
                    break;
                case "BuyProduct":
                    MainViewModel.GetInstance().Post = new PostViewModel();
                    await App.Navigator.PushAsync(new PostPage());
                    break;
                case "SeeProduct":
                    MainViewModel.GetInstance().Products = new ProductViewModel();
                    await App.Navigator.PushAsync(new ProductPage());
                    break;
                default:
                    MainViewModel.GetInstance().Login = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
            }
        }
    }
}
