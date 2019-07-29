
namespace ProyectRefit.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using Plugin.Permissions;
    using Plugin.Permissions.Abstractions;
    //using Plugin.Media.Abstractions;
    using ProyectRefit.Interface;
    using ProyectRefit.Models;
    using ProyectRefit.service;
    using Refit;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AddProductViewModel:BaseViewModel
    {
        //private
        private bool isToggled;
        private bool isRunning;
        private bool isEnabled;
        private MediaFile file;
        private ImageSource imageSource;
        private HttpService httpService;
        //public
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsToggled {
            get => isToggled;
            set => SetValue(ref isToggled,value);
        }
        public bool IsRunning
        {
            get => isRunning;
            set => SetValue(ref isRunning,value);
        }
        public bool IsEnabled
        {
            get => isEnabled;
            set => SetValue(ref isEnabled, value);
        }

        public ImageSource ImageSource
        {
            get => imageSource;
            set => SetValue(ref imageSource, value);
        }

        public ICommand ConfirmarCommand => new RelayCommand(RegisterProduct);
        public ICommand SelectImageCommand => new RelayCommand(ChangeImage);

        public AddProductViewModel()
        {
            isToggled = true;
            this.Image = "image";
            this.ImageSource = "tokephoto";
            this.httpService = new HttpService();
        }

        private async void RegisterProduct()
        {
            try
            {
                if (parametros())
                {
                    await Application.Current.MainPage.DisplayAlert(
                       "Error",
                       "No puede dejar ningun campo vacio",
                       "Ok");
                    return;
                }

                //isEnabled = true;
                var product = new Product {
                    Name = this.Name,
                    Description = this.Description,
                    Price = this.Price,
                    IsAvalible = true,
                    Image = "image"

                };

                var url = Application.Current.Resources["UrlApi"].ToString();
                //var response = await httpService.PostAsync<Product>(url,"/Product/create",product);
                //if (!response.IsSuccess)
                //{
                //   await Application.Current.MainPage.DisplayAlert(
                //        "Error",
                //        response.Message,
                //        "Ok");
                //    return;
                //}
                //var newProduct = (Product)response.Result;
                //MainViewModel.GetInstance().Products.AddProductToList(newProduct);
                //var data = new Dictionary<string, object> {
                //    {"Name", product.Name},
                //    {"Description", product.Description},
                //    {"IsAvalible", true},
                //    {"Price", product.Price},
                //};


                var apiService = RestService.For<IApiService>(url, new RefitSettings
                {
                    ContentSerializer = new JsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    })
                });
                var response = await apiService.PostProduct(product);
                if (response != null)
                {
                    await Application.Current.MainPage.DisplayAlert(
                         "Acetado",
                         "Se ha guardado el producto",
                         "Ok");
                   //var newProduct = response;
                   //MainViewModel.GetInstance().Products.AddProductToList(response);
                    return;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Se cancelo la respuesta de datos",
                        "Ok");
                    return;
                }
                IsRunning = false;
               // IsEnabled = false;
            }
            catch (Exception ex )
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    ex.Message,
                    "Ok");
                IsRunning = false;
               // IsEnabled = false;sdas
            }
        }

        private async void ChangeImage()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                var source = await Application.Current.MainPage.DisplayActionSheet(
                    "Where do you take the picture?",
                    "Cancel",
                    null,
                    "From Gallery",
                    "From Camera");

                if (source == "Cancel")
                {
                    this.file = null;
                    return;
                }

                if (source == "From Camera")
                {
                   
                    if (!CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "No Camera",
                            ":( No camera available.",
                            "OK");
                        return;
                    }
                    this.file = await CrossMedia.Current.TakePhotoAsync(
                        new StoreCameraMediaOptions
                        {
                            Directory = "Sample",
                            Name = "test.jpg",
                            PhotoSize = PhotoSize.Small,
                        });

                }
                else
                { 
                    //aqui obtenermos la foto de la galeria
                    this.file = await CrossMedia.Current.PickPhotoAsync();
                }

                if (this.file != null)
                {
                    this.ImageSource = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        return stream;
                    });
                }

            }
            catch (Exception ex) {
              await  Application.Current.MainPage.DisplayAlert(
                    "Error",
                     ex.Message,
                    "Ok");
            }
        }

        //metodo de los parametros
        public bool parametros() {
            if (string.IsNullOrEmpty(Description)||string.IsNullOrEmpty(Name)||Price<0)
            {
                return true;
            }
            return false;
        }
    }
}
