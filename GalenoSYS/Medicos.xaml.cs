using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalenoSYS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Medicos : ContentPage
    {
        private const string Url = "http://172.25.208.1/especialidades/post.php";
        private const string Url1 = "http://172.25.208.1/medicos/post.php?especialidad_medico=";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<GalenoSYS.Datose> _post;
        private ObservableCollection<GalenoSYS.Datose> _post1;
        public Medicos()
        {
            InitializeComponent();
            get();
            getmedicos();
            
        }
        public async void get()
        {
            var content = await client.GetStringAsync(Url);
            List<GalenoSYS.Datose> posts = JsonConvert.DeserializeObject<List<GalenoSYS.Datose>>(content);
            _post = new ObservableCollection<GalenoSYS.Datose>(posts);
            txtespecialidad.ItemsSource = _post;
            
        }
        public async void getmedicos()
        {
            var content = await client.GetStringAsync(Url1);
            List<GalenoSYS.Datose> posts = JsonConvert.DeserializeObject<List<GalenoSYS.Datose>>(content);
            _post1 = new ObservableCollection<GalenoSYS.Datose>(posts);
            txtmedicos.ItemsSource = _post1;

        }

        private void btnGrabarCita_Clicked(object sender, EventArgs e)
        {

            var espe = txtespecialidad.Items[txtespecialidad.SelectedIndex];
            
            var med = txtmedicos.Items[txtmedicos.SelectedIndex];
            var hora = Convert.ToString(txthora.Time);
            var fecha = Convert.ToString( txtfecha.Date);
            string estado = "1";
            
            string paciente = "cris";



            var url = new Uri("http://172.25.208.1/citas/post.php");
            var httpClient = new HttpClient();
            var result =  httpClient.GetStringAsync(url);
            string checkResult = result.ToString();
            httpClient.Dispose();
            
            
            WebClient cliente = new WebClient();
                try
                {

                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("cita_id", "");
                    parametros.Add("cita_nombrepaciente", paciente);
                    parametros.Add("fecha_cita", fecha);
                    parametros.Add("hora_cita", hora);
                    parametros.Add("nombre_doctor", med);
                    parametros.Add("especialidad_doctor", espe);
                    parametros.Add("cita_estado", estado);


                    cliente.UploadValues("http://172.25.208.1/citas/post.php", "POST", parametros);
                    DisplayAlert("Alerta", "Datos ingresados correctamente", "Cerrar");
                }
                catch (Exception ex)
                {

                    DisplayAlert("Alerta", ex.Message, "Cerrar");
                }
            
                
            
            
        }

        private async void btnVerCitas_Clicked(object sender, EventArgs e)
        {

            try
            {
                await Navigation.PushAsync(new ReporteCita());
            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
            
        }

        public void txtespecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
           // var name = txtespecialidad.Items[txtespecialidad.SelectedIndex];

        }

        private  void txtespecialidad_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                monkeyNameLabel.Text = picker.Items[selectedIndex];
            }*/

        }
    }
}