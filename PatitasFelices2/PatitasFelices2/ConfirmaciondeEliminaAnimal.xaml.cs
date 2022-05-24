using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatitasFelices2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmaciondeEliminaAnimal : ContentPage
    {
        public ConfirmaciondeEliminaAnimal(String Id)
        {
           
            InitializeComponent();
            txtCodigomascota.Text = Id;

            lblMascota.Text = "¿Está seguro de eliminar esta mascota?";
        }

        private async void btnAceptar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", "");

                cliente.UploadValues("http://200.12.169.100/patitas/mascota/borrarmascota.php?codigo="+txtCodigomascota.Text,parametros);

                await DisplayAlert("Alerta", "Mascota Eliminada Correctamente", "Ok");

                await Navigation.PushAsync(new ListadoMascotas());


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Usuario No Eliminado" + ex.Message, "Ok");
            }
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoMascotas());
        }
    }
}