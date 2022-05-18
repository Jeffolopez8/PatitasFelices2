using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatitasFelices2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformacionMascota : ContentPage
    {
        public InformacionMascota(String id)
        {
            InitializeComponent();
            txt_CodigoMascota.Text = id;
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
            await DisplayAlert("Mensaje", "Se ha actualizado con éxito", "Ok");
        }

        private async void btn_Eliminar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Mensaje", "La Mascota Tobby se ha eliminado con éxito", "Ok");
        }
    }
}