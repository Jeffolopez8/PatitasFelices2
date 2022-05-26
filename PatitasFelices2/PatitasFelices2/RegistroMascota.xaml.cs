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
    public partial class RegistroMascota : ContentPage
    {
        public RegistroMascota()
        {
            InitializeComponent();
            progress.ProgressTo(.0, 250, Easing.Linear);
            lbl_progress.Text = "0%";

        }

        private void lbl_NombreMascota_Completed(object sender, EventArgs e)
        {
            progress.ProgressTo(.50, 250, Easing.Linear);
            lbl_progress.Text = "50%";
        }

        private void lbl_NombreMascota_TextChanged(object sender, TextChangedEventArgs e)
        {
            progress.ProgressTo(.50, 250, Easing.Linear);
            lbl_progress.Text = "50%";
        }

        private void lbl_raza_TextChanged(object sender, TextChangedEventArgs e)
        {
            progress.ProgressTo(1, 250, Easing.Linear);
            lbl_progress.Text = "100%";
        }

        private void lbl_raza_Completed(object sender, EventArgs e)
        {
            progress.ProgressTo(1, 250, Easing.Linear);
            lbl_progress.Text = "100%";
        }

        private async void btn_registrarMacota_Clicked(object sender, EventArgs e)
        {
            if (lbl_progress.Text == "100%")
            {
                try
                {
                    WebClient cliente = new WebClient();
                    var parametros = new System.Collections.Specialized.NameValueCollection();

                    parametros.Add("codigo", "");
                    parametros.Add("nombremascota", lbl_NombreMascota.Text);
                    parametros.Add("raza", lbl_raza.Text);
                    parametros.Add("fechaRegistro", Convert.ToString (dp_FechaRegistro.Date));
                    parametros.Add("estado","1");


                    //Ingresar codigo usuario
                    parametros.Add("codigoUsuario", "1");

                    //Ingresar codigo usuario

                    cliente.UploadValues("http://200.12.169.100/patitas/mascota/post.php?codigo="+""+"nombremascota="+lbl_NombreMascota.Text+"raza="+lbl_raza.Text+ "fechaRegistro="+Convert.ToString(dp_FechaRegistro.Date)+"estado=1"+"codigoUsuario=1", "POST", parametros);



                    await DisplayAlert("Registro Exitoso", "La mascota " + lbl_NombreMascota.Text + "se ha registrado correctamente", "Ok");

                   await Navigation.PushAsync(new ListadoMascotas());
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Error", "Mascota No  ha sido Registrada" + ex.Message, "Ok");
                }


                limpiarRegistros();

               
            }
            else
            {
                 await DisplayAlert("Registro Fallido", "Debe llenar todos los campos requeridos", "Ok");
            }
        }

        private void limpiarRegistros()
        {

            lbl_NombreMascota.Text = " ";
            lbl_raza.Text = " ";



        }
    }
}