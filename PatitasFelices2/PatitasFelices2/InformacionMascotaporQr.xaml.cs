using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatitasFelices2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformacionMascotaporQr : ContentPage
    {
        public InformacionMascotaporQr(string codiomascota, string nombremascotas, string raza, string fecha, string nombredueno, string telefonodueno, string correodueno )
        {
            InitializeComponent();
            lbl_NombreMascotas.Text= nombremascotas;
            lbl_razas.Text= raza;   
            lbl_nombre.Text = nombredueno;
            txtNumero.Text= telefonodueno;
            txtCorreo.Text= correodueno;
         

        }

        private void btn_llamar_Clicked(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("+593"+txtNumero.Text);

            }
            catch (Exception ex)
            {

                DisplayAlert("No se puede hacer llamada", "Intentelo mas tarde", "ok");
            }
        }

        private async void btn_correo_Clicked(object sender, EventArgs e)
        {

           
               

           
        }
    }
}