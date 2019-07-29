

namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectRefit.Interface;
    using ProyectRefit.Models;
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ProductViewModel:BaseViewModel
    {
        private List<Product> myProduct;
        private ObservableCollection<ProductItemViewModel> listProduct;
        private bool isRefresh;

        public bool IsRefreshing
        {
            get => isRefresh;
            set => SetValue(ref isRefresh,value);
        }

        public ObservableCollection<ProductItemViewModel> ListProduct
        {
            get => listProduct;
            set => SetValue(ref listProduct, value);
        }

        public ProductViewModel()
        {
            LoadProduct();
        }

        public ICommand RefreshCommand => new RelayCommand(Refresh);

      
        private async void LoadProduct()
        {
            try
            {
                IsRefreshing = true;
                var url = Application.Current.Resources["UrlApi"].ToString();
                var apiService = RestService.For<IApiService>(url);
                this.myProduct =  await apiService.GetProduct();
                // ListProduct = new ObservableCollection<Product>(response);
                this.ProductRefresh();
                IsRefreshing = false;
            }
            catch (Exception ex)
            {
               await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Error con la Peticcion de los recursos.",
                    "Ok");
            }
        }
        public void AddProductToList(Product product)
        {
            this.myProduct.Add(product);
            this.ProductRefresh();
        }
        public void updateProduct(Product product)
        {
            var previousProduct = this.myProduct.Where(p => p.Id ==  product.Id).FirstOrDefault();

            if (previousProduct!=null)
            {
                this.myProduct.Remove(previousProduct);
            }

            this.myProduct.Add(product);

            this.ProductRefresh();
        }

        public void DeleteProduct(int productId)
        {
            var previousProduct = myProduct.Where(p => p.Id == productId).FirstOrDefault();

            if (previousProduct != null)
            {
                 this.myProduct.Remove(previousProduct);
            }

            this.ProductRefresh();
        }

        public void ProductRefresh()
        {
            this.ListProduct = new ObservableCollection<ProductItemViewModel>(
                myProduct.Select(p => new ProductItemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    IsAvalible = p.IsAvalible,
                    Image = p.Image
                }).OrderBy(p => p.Name));
        }
        private void Refresh()
        {
            IsRefreshing = true;
            LoadProduct();
            IsRefreshing = false;
        }

    }
}
