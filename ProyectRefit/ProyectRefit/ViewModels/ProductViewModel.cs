

namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectRefit.Interface;
    using ProyectRefit.Models;
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Windows.Input;

    public class ProductViewModel:BaseViewModel
    {
        private ObservableCollection<Product> listProdut;
        private bool isRefresh;
        public bool IsRefreshing
        {
            get => isRefresh;
            set => SetValue(ref isRefresh,value);
        }
        public ObservableCollection<Product> ListProduct
        {
            get => listProdut;
            set => SetValue(ref listProdut, value);
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
                var apiService = RestService.For<IApiService>("http://192.168.2.2:8001/api");
                var response =  await apiService.GetProduct();
                ListProduct = new ObservableCollection<Product>(response);
                IsRefreshing = false;
            }
            catch (Exception ex)
            {

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
