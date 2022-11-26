using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalenoSYS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu(string ci, string nom, string ape, string idd, string pasw, string corre)
        {
            InitializeComponent();
            lblNombresPac.Text = " " + nom + " " + ape;
            lblCIPac.Text = ci;
            lblIDPac.Text = idd;
            lblPASSPac.Text = pasw;
            lblCOPac.Text = corre;
            lblNomPac.Text = nom;
            lblApePac.Text = ape;

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //DisplayAlert("Información", "MIS DATOS", "Cerrar");
            await Navigation.PushAsync(new Datos(lblIDPac.Text, lblCIPac.Text, lblNomPac.Text, lblApePac.Text, lblPASSPac.Text, lblCOPac.Text));
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            //DisplayAlert("Información", "MÉDICOS", "Cerrar");
            await Navigation.PushAsync(new ListaMedicos());

        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            //DisplayAlert("Información", "CITAS", "Cerrar");
            await Navigation.PushAsync(new Medicos());
        }

        private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            //DisplayAlert("Información", "UBICACIÓN", "Cerrar");
            await Navigation.PushAsync(new Ubicacion());
        }

        private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            //DisplayAlert("Información", "CONTACTOS", "Cerrar");
            await Navigation.PushAsync(new Contactos());
        }

        private async void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {
            //DisplayAlert("Información", "SALIR", "Cerrar");
            //await Navigation.PushAsync(new ListaUser());
            await Navigation.PushAsync(new Login());
        }
    }
}