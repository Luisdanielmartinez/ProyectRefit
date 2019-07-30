

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
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class PostViewModel:BaseViewModel
    {
        private ObservableCollection<Post> listPost;
        private bool isBusy;
       
        
        public bool IsBusy
        {
            get => isBusy;
            set => SetValue(ref isBusy,value);
        }

        public ObservableCollection<Post> ListPost
        {
            get => listPost;
            set => SetValue(ref listPost,value);
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    await LoadPost();
                    IsBusy = false;
                });
            }
        }

        public PostViewModel()
        {
            LoadPost();
        }

        private async Task LoadPost()
        {
            try
            {
                isBusy = true;
                var url = Application.Current.Resources["UrlApi"].ToString();
                var apiService = RestService.For<IApiService>("https://jsonplaceholder.typicode.com");
                var response = await apiService.GET();
               // var list = (List<Post>)response.Result;
                ListPost = new ObservableCollection<Post>(response);
                IsBusy = false;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Error con la carga de los datos",
                    "Ok");
            }
        }

        


    }
}
