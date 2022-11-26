using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs.Extended;

namespace GalenoSYS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PacRegis : ContentPage
    {
        public PacRegis()
        {
            InitializeComponent();
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            if (validarDatos()) //Campos LLenos
            {
                if (validaContra()) //Password coincida
                {
                    WebClient client = new WebClient();

                    try
                    {
                        var useridnum = DateTime.Now.ToString("mmss");
                        var parametros = new System.Collections.Specialized.NameValueCollection();
                        parametros.Add("usr_id", useridnum);
                        parametros.Add("usr_login", txt_usrlogin.Text);
                        parametros.Add("usr_nombre", txt_usrnombre.Text);
                        parametros.Add("usr_apellido", txt_usrapelli.Text);
                        parametros.Add("usr_pass", txt_usrpass1.Text);
                        parametros.Add("usr_rol", "paciente");
                        parametros.Add("usr_estado", "activo");
                        parametros.Add("usr_correo", txt_usrcorreo.Text);

                        UserDialogs.Instance.ShowLoading("Ingresando registro, un momento por favor..."); //Activity Indicator
                        client.UploadValues("http://192.168.100.15/galenosys/post.php", "POST", parametros);
                        await Task.Delay(3000);
                        UserDialogs.Instance.HideLoading();
                        await DisplayAlert("Registro", "Se guardó con éxito el Usuario", "OK");

                        await Navigation.PushAsync(new Login());

                    }

                    catch (Exception ex)
                    {
                        await DisplayAlert("Alerta", ex.Message, "Cerrar");
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "Por favor Validar password que sean idénticos", "OK");
                    txt_usrpass1.Focus();
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
            if (string.IsNullOrEmpty(txt_usrlogin.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Cédula", "OK");
                txt_usrlogin.Focus();
            }
            else if (string.IsNullOrEmpty(txt_usrnombre.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Nombre", "OK");
                txt_usrnombre.Focus();
            }
            else if (string.IsNullOrEmpty(txt_usrapelli.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Apellido", "OK");
                txt_usrapelli.Focus();
            }
            else if (string.IsNullOrEmpty(txt_usrpass1.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Password1", "OK");
                txt_usrpass1.Focus();
            }
            else if (string.IsNullOrEmpty(txt_usrpass2.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Password2", "OK");
                txt_usrpass2.Focus();
            }
            else if (string.IsNullOrEmpty(txt_usrcorreo.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Email", "OK");
                txt_usrcorreo.Focus();
            }
            else 
            {
                respuesta = true;
            }
            return respuesta;
        }

        public bool validaContra()
        {
            bool resp;
            if (txt_usrpass1.Text != txt_usrpass2.Text )
            {
                resp = false;
            }
            else
            {
                resp = true;
            }
            return resp;
        }

    }
}