
namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectRefit.Models;
    using ProyectRefit.Views;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
   

    // using Xamarin.Forms;

    public class MainViewModel
    {
        public static MainViewModel mainViewModel{ get; set; }
        public  LoginViewModel Login { get; set; }
        public AddProductViewModel AddProduct { get; set; }
        public PostViewModel Post { get; set; }
        public EditViewModel EditProduct { get; set; }
        public ProductViewModel Products { get; set; }
        public RegisterUserViewModel RegisterUser { get; set; }
        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        //public ICommand AddProductCommand => new RelayCommand(GoToProduct);

        public MainViewModel()
        {
            mainViewModel = this;
            this.LoadMenus();
        }

        public static MainViewModel GetInstance()
        {
            if (mainViewModel==null) {
                mainViewModel = new MainViewModel();
            }
            return mainViewModel;
        }

        //public async void GoToProduct()
        //{
        //    this.AddProduct = new AddProductViewModel();
        //    await App.Navigator.PushAsync(new AddProductPage());

        //}

        //metodo de menu
        private void LoadMenus()
        {
            var menus = new List<Menu> {
                new Menu
                {
                    Icon="ic_add_shopping_cart",
                    Title="Agregar Producto",
                    PageName="AddProduct"
                    
                },
                new Menu{
                    Icon="ic_phonelink_setup",
                    Title="Ver Productos",
                    PageName="SeeProduct"

                },
            new Menu {
                Icon = "ic_perm_device_information",
                Title = "Comprar Productos",
                PageName = "BuyProduct"
            },
            new Menu {
                Icon="ic_exit_to_app.png",
                Title="Sign Out",
                PageName="LoginPage"
            }

            };
            //aqui almamos el menu con una formato de linq
            this.Menus = new ObservableCollection<MenuItemViewModel>
                (menus.Select(m => new MenuItemViewModel
                {
                    Icon = m.Icon,
                    Title = m.Title,
                    PageName = m.PageName
                }).ToList());
        }
    }
}
