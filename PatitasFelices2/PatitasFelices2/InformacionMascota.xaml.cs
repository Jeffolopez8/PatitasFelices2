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
    public partial class InformacionMascota : ContentPage
    {
        public InformacionMascota(int id, String nombre, string raza, string fecha, string nombrecomp , string telefono, string correo)
        {
            InitializeComponent();
            txt_CodigoMascota.Text = Convert.ToString (id);
            lbl_principal.Text = "Información de: " + nombre;
            lbl_NombreMascotas.Text = nombre;
            txt_infomascota.Text= nombrecomp+" "+ telefono+" "+ correo;
            lbl_razas.Text = Convert.ToString (raza);
           // dp_FechaRegistro.Date = Convert.ToDateTime(fecha);
        }

        private void lbl_NombreMascotas_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_NombreMascotas_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_razas_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_razas_Completed(object sender, EventArgs e)
        {

        }

        private async void btn_Actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txt_CodigoMascota.Text);
                parametros.Add("nombre", lbl_NombreMascotas.Text);
                parametros.Add("raza", lbl_razas.Text);
                parametros.Add("fechaRegistro", Convert.ToString(dp_FechaRegistro.Date));
              

                cliente.UploadValues("http://200.12.169.100/patitas/mascota/actualizamascota.php?codigo="+txt_CodigoMascota.Text+"&nombre="+lbl_NombreMascotas.Text+"&raza="+lbl_razas.Text+"&fecharegistro="+Convert.ToString(dp_FechaRegistro.Date), "PUT", parametros);



                await DisplayAlert("Alerta", "Mascota Actualizada Correctamente", "Ok");

                await Navigation.PushAsync(new ListadoMascotas());


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Mascota No Actualizada" + ex.Message, "Ok");
            }


        }

        private async void btn_Eliminar_Clicked(object sender, EventArgs e)
        {

            string id = txt_CodigoMascota.Text;
            await Navigation.PushAsync(new ConfirmaciondeEliminaAnimal(id));
        }

        private async void btn_CodQR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QRMascota(txt_CodigoMascota.Text, lbl_NombreMascotas.Text, txt_infomascota.Text));
        }
    }
}