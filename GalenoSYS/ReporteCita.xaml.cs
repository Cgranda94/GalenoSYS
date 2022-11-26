using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalenoSYS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReporteCita : ContentPage
    {
        private const string Url = "http://172.25.208.1/citas/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<GalenoSYS.Datosbd> _post;
        public ReporteCita()
        {
            InitializeComponent();
            get();

        }

        public async void get()
        {
            var content = await client.GetStringAsync(Url);
            List<GalenoSYS.Datosbd> posts = JsonConvert.DeserializeObject<List<GalenoSYS.Datosbd>>(content);
            _post = new ObservableCollection<GalenoSYS.Datosbd>(posts);
            MyListView.ItemsSource = _post;
        }
        async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var datosbs = e.SelectedItem as Datosbd;
            await Navigation.PushAsync(new ResumenCitas(datosbs.cita_id, datosbs.cita_nombrepaciente,datosbs.fecha_cita,datosbs.hora_cita,datosbs.nombre_doctor,datosbs.especialidad_doctor, datosbs.cita_estado));
        }   

        private void btnGet_Clicked(object sender, EventArgs e)
        {

        }
    }
}