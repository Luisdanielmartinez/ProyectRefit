

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
        private string filter;
        public string Filter {
            get {
                return filter;
            }
            set {

                filter = value;
                this.ProductRefresh();
            }
        }
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
        public ICommand SearchCommand => new RelayCommand(ProductRefresh);

        private async void LoadProduct()
        {
            try
            {
                IsRefreshing = true;
                var url = Application.Current.Resources["UrlApi"].ToString();
                var apiService = RestService.For<IApiService>(url);
                this.myProduct = await apiService.GetProduct();
                // ListProduct = new ObservableCollection<Product>(response);
                this.ProductRefresh();
                IsRefreshing = false;
            }
            catch (Exception ex)
            {
               await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    ex.Message,
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
            //aqui estamos refrescando la lista 
            if (string.IsNullOrEmpty(this.Filter))
            {
              
               var mylist=  myProduct.Select(p => new ProductItemViewModel
               {
                   Id = p.Id,
                   Name = p.Name,
                   Description = p.Description,
                   Price = p.Price,
                   IsAvalible = p.IsAvalible,
                   Image = p.Image
               });
                this.ListProduct = new ObservableCollection<ProductItemViewModel>(
                   mylist.OrderBy(p => p.Description));
            }
            else
            {
                
              var mylist= myProduct.Select(p => new ProductItemViewModel
               {
                   Id = p.Id,
                   Name = p.Name,
                   Description = p.Description,
                   Price = p.Price,
                   IsAvalible = p.IsAvalible,
                   Image = p.Image
               }).Where(p => p.Description.ToLower().Contains(this.Filter.ToLower())).ToList();
                this.ListProduct = new ObservableCollection<ProductItemViewModel>(
                   mylist.OrderBy(p => p.Description));
            }
        
        }
        private void Refresh()
        {
            IsRefreshing = true;
            LoadProduct();
            IsRefreshing = false;
        }

    }
}
