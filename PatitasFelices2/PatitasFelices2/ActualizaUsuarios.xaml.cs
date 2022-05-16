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
    public partial class ActualizaUsuarios : ContentPage
    {
        public ActualizaUsuarios()
        {
            InitializeComponent();
        }

        private void btn_registrar_Clicked(object sender, EventArgs e)
        {

        }

        private async void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Mensaje", "El Registro ha sido actualizado correctamente..", "Ok");
        }

        private async void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Mensaje", "El Registro ha sido eliminado correctamente..","Ok");
        }

        private void lbl_nombre_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_apellido_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_domicilio_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_telefono_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_correo_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_usuario_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_password_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_password2_Completed(object sender, EventArgs e)
        {

        }

        private void lbl_nombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_apellido_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_domicilio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbl_telefono_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbox_terminos_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }
    }
}