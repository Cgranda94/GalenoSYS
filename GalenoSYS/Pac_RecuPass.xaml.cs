using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalenoSYS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pac_RecuPass : ContentPage
    {
        public Pac_RecuPass()
        {
            InitializeComponent();
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos()) //Campos LLenos
            {

            }
            else
            {
                //await DisplayAlert("Advertencia", "Ingrersar todos los datos", "OK");
            }

        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txt_recced.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Cédula", "OK");
                txt_recced.Focus();
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }



    }
}