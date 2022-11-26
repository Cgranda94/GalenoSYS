using Newtonsoft.Json;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Acr.UserDialogs;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs.Extended;

namespace GalenoSYS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {

        //Acceso a BD
        private const string Url = "http://172.25.208.1/usuarios/post.php?usr_login=";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<GalenoSYS.Ws.bd_t_usuario> _post;

        public Login()
        {
            InitializeComponent();
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            lblidok.Text = "";
            lblloginok.Text = "";
            lblnombok.Text = "";
            lblapelliok.Text = "";
            lblpassiok.Text = "";
            lblcorreook.Text = "";

            if (validarDatos()) //Campos LLenos
            {

                get_Login();

                UserDialogs.Instance.ShowLoading("Validando Usuario, un momento por favor..."); //Activity Indicator
                await Task.Delay(3000);
                UserDialogs.Instance.HideLoading();

                string usuario = lblloginok.Text;
                string contrasena = lblpassiok.Text;

                string tUsuario = txtUsuario.Text;
                string tContrasena = txtContrasena.Text;

                if (usuario == tUsuario & contrasena == tContrasena)
                {
                    //await DisplayAlert("Alerta", "OK USUARIO VALIDO", "Cerrar");
                    try
                    {
                        await Navigation.PushAsync(new Menu(lblloginok.Text, lblnombok.Text, lblapelliok.Text, lblidok.Text, lblpassiok.Text, lblcorreook.Text));
                    }
                    catch (Exception ex)
                    {

                        await DisplayAlert("Alerta", ex.Message , "Cerrar");
                    }
                    

                }
                else
                {
                    await DisplayAlert("Alerta", "ERROR. USUARIO NO EXISTE", "Cerrar");
                    txtUsuario.Focus();
                }
            }
            else
            {
                //await DisplayAlert("Advertencia", "Ingrersar todos los datos", "OK");
            }
        }



        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                respuesta = false;
                DisplayAlert("Alerta", "ERROR. Ingrese el campo de Cédula", "Cerrar");
                txtUsuario.Focus();
            }
            else if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                respuesta = false;
                DisplayAlert("Alerta", "ERROR. Ingrese el campo de Password", "Cerrar");
                txtContrasena.Focus();
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PacRegis());
        }

        public async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            bool isFingerPrintAvailable = await CrossFingerprint.Current.IsAvailableAsync(true);

            if (isFingerPrintAvailable)
            {
                AuthenticationRequestConfiguration conf = new AuthenticationRequestConfiguration("Autorización Biométrica", "Autentificar con su huella dactilar para Ingresar");

                var result = await CrossFingerprint.Current.AuthenticateAsync(conf);

                if (result.Authenticated)
                {
                    //OK 
                    var mensajever = "OK, Touch ID con Éxito";
                    DependencyService.Get<MensajeToast>().LongAlert(mensajever);

                    var ci0 = "1710904606";
                    var nom1 = "Cristian";
                    var ape1 = "Lopez";
                    var pass1 = "123";
                    var corr1 = "crismau23@hotmail.com";
                    var id1 = "5254";

                    await Navigation.PushAsync(new Menu(ci0, nom1, ape1, id1, pass1, corr1));

                }
                else
                {
                    //ERROR 
                    await DisplayAlert("Alerta", "Login Error", "OK");
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Autorización Biométrica no disponible.  Configurar el dispositivo", "Cerrar");
                return;
            }
        }

        public async void get_Login()
        {
            var UrlLogin = Url + txtUsuario.Text;

            var content = await client.GetStringAsync(UrlLogin);

            //await DisplayAlert("Advertencia", UrlLogin, "OK");

            if (content == "[]") 
            {
            
            }
            else
            {

                string cadenaOrig = content;
                string[] separadas;
                separadas = cadenaOrig.Split('"');

                lblidok.Text = separadas[3];
                lblloginok.Text = separadas[11];
                lblnombok.Text = separadas[19];
                lblapelliok.Text = separadas[27];
                lblpassiok.Text = separadas[35];
                lblcorreook.Text = separadas[43]; ;

                //List<GalenoSYS.Ws.bd_t_usuario> posts = JsonConvert.DeserializeObject<List<GalenoSYS.Ws.bd_t_usuario>>(content);
                //_post = new ObservableCollection<GalenoSYS.Ws.bd_t_usuario>(posts);
                //ListDataUser.ItemsSource = _post;
            }
            }
    }



}
