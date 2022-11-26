using Acr.UserDialogs.Extended;
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
    public partial class ListaMedicos : ContentPage
    {

        //Acceso a BD

        private const string Url = "http://172.25.208.1/listamedicos/post_med.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<GalenoSYS.Ws.bd_t_medico> _post;

        public ListaMedicos()
        {
            InitializeComponent();
            
            
            get_listMed();


        }
        
        public async void get_listMed()
        {
            var content = await client.GetStringAsync(Url);

            List<GalenoSYS.Ws.bd_t_medico> post = JsonConvert.DeserializeObject<List<GalenoSYS.Ws.bd_t_medico>>(content);
            _post = new ObservableCollection<GalenoSYS.Ws.bd_t_medico>(post);

            ListViewMedicos.ItemsSource = _post;

            UserDialogs.Instance.ShowLoading("Importando Médicos, un momento por favor..."); //Activity Indicator
            await Task.Delay(2000);
            UserDialogs.Instance.HideLoading();

        }

        private async void btnOK_Clicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OK", "Cita Agendada", "Cerrar");
            await Navigation.PushAsync(new Medicos());

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListViewMedicos.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ListViewMedicos.ItemsSource = _post;
            else
                ListViewMedicos.ItemsSource = _post.Where(i => i.med_nombrescompletos.Contains(e.NewTextValue));

            ListViewMedicos.BeginRefresh();

        }
    }
}