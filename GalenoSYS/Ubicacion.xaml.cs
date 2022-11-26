using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalenoSYS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ubicacion : ContentPage
    {
        double latitud;
        double longitud;

        public Ubicacion()
        {
            InitializeComponent();
        }

        private async void IniciarGPS()
        {
            var geolocator = CrossGeolocator.Current;

            geolocator.DesiredAccuracy = 50;

            if (geolocator.IsGeolocationEnabled)
            {
                if (!geolocator.IsListening)
                {
                    await geolocator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                }
                geolocator.PositionChanged += (cambio, args) =>
                {
                    var loc = args.Position;
                    lon.Text = loc.Longitude.ToString();
                    longitud = double.Parse(lon.Text);
                    lat.Text = loc.Latitude.ToString();
                    latitud = double.Parse(lat.Text);
                };
            }
        }

        private async void VerMapa_Clicked(object sender, EventArgs e)
        {
            //posición de Escazu
            latitud = -0.19198821923168943;
            longitud = -78.48098509047743;


            MapLaunchOptions options = new MapLaunchOptions { Name = "CLINICA GALENO" };
            await Map.OpenAsync(latitud, longitud, options);
        }

    }
}