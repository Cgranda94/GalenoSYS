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
    public partial class ListaUser : ContentPage
    {
        private const string Url = "http://192.168.100.15/galenosys/post.php?usr_id=1";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<GalenoSYS.Ws.bd_t_usuario> _post;


        public ListaUser()
        {
            InitializeComponent();



        }

        private void btnConsulta_Clicked(object sender, EventArgs e)
        {
            get();
        }


        public async void get()
        {
            var content = await client.GetStringAsync(Url);
            //await DisplayAlert("Advertencia", content, "OK");

            List<GalenoSYS.Ws.bd_t_usuario> posts = JsonConvert.DeserializeObject<List<GalenoSYS.Ws.bd_t_usuario>>(content);
            _post = new ObservableCollection<GalenoSYS.Ws.bd_t_usuario>(posts);

            ListDataUser.ItemsSource = _post;
        }
    }
}