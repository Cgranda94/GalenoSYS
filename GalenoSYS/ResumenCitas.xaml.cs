using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalenoSYS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResumenCitas : ContentPage
    {
        public ResumenCitas(int cita_id ,string Npaciente, string fecha,string hora, string Nmedico,string especialidad, int cita_estado )
        {
            InitializeComponent();
            
            txtmedico.Text = Convert.ToString(Nmedico);
            txtespecialidad.Text = Convert.ToString(especialidad);
            txtfecha.Text = Convert.ToString(fecha);
            txthora.Text= Convert.ToString(hora);
            txtid.Text= Convert.ToString(cita_id);
            txtestado.Text= Convert.ToString(cita_estado);



        }

        private async void btneliminar_Clicked(object sender, EventArgs e)

        {
            bool res =await DisplayAlert("Alerta", "Desea cancelar su cita", "si","no");
            if (true)
            {
                WebClient cliente = new WebClient();
                try
                {

                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("cita_id", txtid.Text);


                    cliente.UploadValues("http://172.25.208.1/citas/post.php?cita_id=" + txtid.Text, "DELETE", parametros);
                    await DisplayAlert("Alerta", "Su cita a sido cancelada", "Cerrar");
                    await Navigation.PushAsync(new Medicos());
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Alerta", ex.Message, "Cerrar");
                }
            }
            else
            {
                await Navigation.PushAsync(new Medicos());
            }
            
        }
    }
}