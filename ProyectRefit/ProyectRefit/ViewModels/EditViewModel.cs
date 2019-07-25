
namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using ProyectRefit.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;

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
            get => isRunning;
            set => SetValue(ref isRunning,value);
        }

        public ICommand SaveCommand => new RelayCommand(SaveProduct);
        public ICommand DeleteCommand => new RelayCommand(DeleteProduct);

        public EditViewModel(Product product)
        {
            this.Product = product;
        }

        private void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        private void SaveProduct()
        {
            throw new NotImplementedException();
        }
    }
}
