using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Locator();
        }

        private async void Locator()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            //aqui obtenemos la localizacion
            var location = await locator.GetPositionAsync();
            //obtenemos la posicion
            var position = new Xamarin.Forms.Maps.Position(location.Latitude, location.Longitude);
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
        private void Handle_ValueChanged(Object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            //este es el metodo cuando este en el valor de slaider para acercar y alejar el mapa
            var ZommLevel = double.Parse(e.NewValue.ToString()) * 18.0;
            //aqui es que se mueve el slider
            var latLongdegrees = 360 / (Math.Pow(2, ZommLevel));
            this.MyMap.MoveToRegion(new MapSpan(this.MyMap.VisibleRegion.Center, latLongdegrees, latLongdegrees));
        }

    }
}