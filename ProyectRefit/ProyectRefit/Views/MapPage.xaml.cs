
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;


namespace ProyectRefit.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage ()
		{
			InitializeComponent ();
            //este es el que esta bien
            //var locator = CrossGeolocator.Current;
            //locator.DesiredAccuracy = 50;
            ////aqui obtenemos la localizacion
            //var location = locator.GetPositionAsync();
            //var userPosition =  GetUserPosition();
            //MyMap.MoveToRegion(
            //    MapSpan.FromCenterAndRadius(
            //        new Position(37, -122),
            //        Distance.FromKilometers(1)));
            //try
            //{
            //    this.MyMap.IsShowingUser = true;
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}

        }
        private void Street_OnClicked(object sender, EventArgs e)
        {
            MyMap.MapType = MapType.Street;
        }


        private void Hybrid_OnClicked(object sender, EventArgs e)
        {
            MyMap.MapType = MapType.Hybrid;
        }

        private void Satellite_OnClicked(object sender, EventArgs e)
        {
            MyMap.MapType = MapType.Satellite;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Locator();
        }

        private async void Locator()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            //aqui obtenemos la localizacion
            var location = await locator.GetPositionAsync();
            //obtenemos la posicion
            var position = new Position(location.Latitude, location.Longitude);
            this.MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1)));
            try
            {
                this.MyMap.IsShowingUser = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //private void Handle_ValueChanged(Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        //{
        //    //este es el metodo cuando este en el valor de slaider para acercar y alejar el mapa
        //    var ZommLevel = double.Parse(e.NewValue.ToString()) * 18.0;
        //    //aqui es que se mueve el slider
        //    var latLongdegrees = 360 / (Math.Pow(2, ZommLevel));
        //    this.MyMap.MoveToRegion(new MapSpan(MyMap.VisibleRegion.Center, latLongdegrees, latLongdegrees));
        //}
        async Task<Position> GetUserPosition()
        {
            try
            {
                GeolocationRequest geolocationRequest = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(5));
                var userPosition = await Geolocation.GetLocationAsync(geolocationRequest);
                return new Position(userPosition.Latitude, userPosition.Longitude);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Error", "El dispositivo no soporta el uso de la ubicación", "Aceptar");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Error", "Es necesario tener permisos de uso de la ubicación", "Aceptar");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error desconocido", "Aceptar");
            }

            return default(Position);
        }

    }
}