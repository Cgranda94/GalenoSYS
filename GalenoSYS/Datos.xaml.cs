using Acr.UserDialogs.Extended;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalenoSYS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Datos : ContentPage
    {



        public Datos( string id, string log, string nom, string ape, string pass, string corr  )
        {
            InitializeComponent();

            txt_pacid.Text = id;
            txt_paclogin.Text = log;
            txt_pacnombre.Text = nom;
            txt_pacapelli.Text = ape;
            txt_pacpass1.Text = pass;
            txt_pacemail.Text = corr;


            txt_pacnombre.Focus();

        }

        private async void btnActuliza_Clicked(object sender, EventArgs e)
        {
            if (validarDatos()) //Campos LLenos
            {
                if (validaContra()) //Password coincida
                {
                    using (var httpClient = new HttpClient())
                    {
                        var parametros = new System.Collections.Specialized.NameValueCollection();

                        parametros.Add("usr_id", txt_pacid.Text);
                        parametros.Add("usr_login", txt_paclogin.Text);
                        parametros.Add("usr_nombre", txt_pacnombre.Text);
                        parametros.Add("usr_apellido", txt_pacapelli.Text);
                        parametros.Add("usr_pass", txt_pacpass1.Text);
                        //parametros.Add("usr_rol", "paciente");
                        //parametros.Add("usr_estado", "activo");
                        parametros.Add("usr_correo", txt_pacemail.Text);
                        //parametros.Add("usr_pathfoto", "");

                        var Urlbase = "http://172.25.208.1/usuarios/post.php?"; // usr_id=1&usr_rol=administrador";

                        var param1 = "usr_id=" + txt_pacid.Text;
                        var param2 = "&usr_login=" + txt_paclogin.Text;
                        var param3 = "&usr_nombre=" + txt_pacnombre.Text;
                        var param4 = "&usr_apellido=" + txt_pacapelli.Text;
                        var param5 = "&usr_pass=" + txt_pacpass1.Text;
                        //var param6 = "&usr_rol=" + "paciente";
                        //var param7 = "&usr_estado=" + "activo";
                        var param8 = "&usr_correo=" + txt_pacemail.Text;
                        //var param9 = "&usr_pathfoto=" + "";

                        var paramtot = param1 + param2 + param3 + param4 + param5 + param8;
                        var Urlpost = Urlbase + paramtot;

                        UserDialogs.Instance.ShowLoading("Actualizando registro, un momento por favor..."); //Activity Indicator
                        var response = await httpClient.PutAsync(Urlpost, null);
                        await Task.Delay(3000);
                        UserDialogs.Instance.HideLoading();

                        if (response.IsSuccessStatusCode)
                        {
                            await DisplayAlert("Información", "OK Registro Actualizado", "Cerrar");
                            await Navigation.PushAsync(new Login());
                        }
                        else
                        {
                            await DisplayAlert("Error", "Problemas al actualizar el registro.", "Cerrar");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "Por favor Validar password que sean idénticos", "OK");
                    txt_pacpass1.Focus();
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
            if (string.IsNullOrEmpty(txt_pacnombre.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Nombre", "OK");
                txt_pacnombre.Focus();
            }
            else if (string.IsNullOrEmpty(txt_pacapelli.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Apellido", "OK");
                txt_pacapelli.Focus();
            }
            else if (string.IsNullOrEmpty(txt_pacpass1.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Password1", "OK");
                txt_pacpass1.Focus();
            }
            else if (string.IsNullOrEmpty(txt_pacpass2.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Password2", "OK");
                txt_pacpass2.Focus();
            }
            else if (string.IsNullOrEmpty(txt_pacemail.Text))
            {
                respuesta = false;
                DisplayAlert("Advertencia", "Ingrersar el campo de Email", "OK");
                txt_pacemail.Focus();
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
            if (txt_pacpass1.Text != txt_pacpass2.Text)
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