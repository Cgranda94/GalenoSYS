using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GalenoSYS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contactos : ContentPage
    {
        public Contactos()
        {
            InitializeComponent();
        }

        private async void SMS_Clicked(object sender, EventArgs e)
        {
            //List<string> numbers = new List<string>
            //{
            // Caja de texto ej: EntryNumber.text;
            //};

            var TextintSMS = "Por favor necesito comunicarme URGENTE!";
            var TextintNUM = "0995036710";

            await SendSms(TextintSMS, TextintNUM);
        }

        public async Task SendSms(string messageText, string recipient)  //List<string> recipient
        {
            try
            {
                var message = new SmsMessage(messageText, recipient);
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("Alerta", "SMS no está soportado para este dispositivo.", "Cerrar");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ocurrió un error inesperado.", "Cerrar");
            }
        }


        private async void Callphone_Clicked(object sender, EventArgs e)
        {
            var TextintNUM = "0995036710";
            await Call(TextintNUM);
        }

        public async Task Call(string TextintNUM)
        {
            try
            {
                PhoneDialer.Open(TextintNUM);
            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("Alerta", "Llamadas no está soportado para este dispositivo.", "Cerrar");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ocurrió un error inesperado.", "Cerrar");
            }
        }

        private async void CORREO_Clicked(object sender, EventArgs e)
        {
            var TextintTO = "soporte@escazuit.com";
            var TextintSUB = "Contacto desde APP GalenoSys";
            var TextintBODY = "¡Por favor necesito comunicarme URGENTE! con ustedes.";

            try
            {
                var mensaje = new EmailMessage(TextintSUB, TextintBODY, TextintTO);
                mensaje.BodyFormat = EmailBodyFormat.PlainText;
                await Email.ComposeAsync(mensaje);
            }
            catch (FeatureNotSupportedException fbsEx)
            {
                await DisplayAlert("Alerta", "El Correo no está soportado para este dispositivo.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ocurrió un error inesperado.", "Cerrar");
            }
        }





    }
}