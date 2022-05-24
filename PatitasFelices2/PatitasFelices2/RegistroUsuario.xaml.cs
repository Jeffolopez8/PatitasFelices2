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
    public partial class RegistroUsuario : ContentPage
    {
        public RegistroUsuario()
        {
            InitializeComponent();
            progress.ProgressTo(.0, 250, Easing.Linear);
            lbl_progress.Text = "0%";
        }

        private void lbl_nombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            string nombre = lbl_nombre.Text.ToString();
            string cadena = $"Bienvenido  {nombre}, llena tus datos";
            lbl_principal1.Text = cadena;
            progress.ProgressTo(.10, 250, Easing.Linear);
            lbl_progress.Text = "10%";
        }

        private void lbl_apellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            progress.ProgressTo(.20, 250, Easing.Linear);
            lbl_progress.Text = "20%";
        }

        private void lbl_domicilio_TextChanged(object sender, TextChangedEventArgs e)
        {
            progress.ProgressTo(.30, 250, Easing.Linear);
            lbl_progress.Text = "30%";
        }

        private void lbl_telefono_TextChanged(object sender, TextChangedEventArgs e)
        {
            progress.ProgressTo(.40, 250, Easing.Linear);
            lbl_progress.Text = "40%";
        }

        private void lbl_usuario_Completed(object sender, EventArgs e)
        {
            progress.ProgressTo(.80, 250, Easing.Linear);
            lbl_progress.Text = "80%";
        }

        private void lbl_password_Completed(object sender, EventArgs e)
        {
            progress.ProgressTo(1, 250, Easing.Linear);
            lbl_progress.Text = "100%";
        }

        private void lbl_password2_Completed(object sender, EventArgs e)
        {

        }

        private void cbox_terminos_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

            if (cbox_terminos.IsChecked)
                btn_registrar.IsEnabled = true;
            else
                btn_registrar.IsEnabled = false;


        }

        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            if (lbl_progress.Text == "100%") { 

                if (lbl_password.Text == lbl_password2.Text)
                {
                    try
                    {
                        WebClient cliente = new WebClient();
                        var parametros = new System.Collections.Specialized.NameValueCollection();

                        parametros.Add("codigo", "");
                        parametros.Add("nombre", lbl_nombre.Text);
                        parametros.Add("apellido", lbl_apellido.Text);
                        parametros.Add("direccion", lbl_domicilio.Text);
                        parametros.Add("telefono", lbl_telefono.Text);
                        parametros.Add("correo", lbl_correo.Text);
                        parametros.Add("nick", lbl_usuario.Text);
                        parametros.Add("clave", lbl_password.Text);

                        cliente.UploadValues("http://200.12.169.100/patitas/usuarios/post.php","POST",parametros);

                      

                        await DisplayAlert("Alerta","Usuario Ingresado Correctamente","Ok");


                    }
                    catch (Exception ex)
                    {

                        await DisplayAlert("Error", "Usuario No Ingresado" + ex.Message , "Ok");
                    }
                    
                    limpiarRegistros();




                }
                else
                {
                    await DisplayAlert("Contraseña diferente", "Ambas contraseñas deben ser iguales", "modificar");
                    lbl_password.Text = "";
                    lbl_password2.Text = "";
                }
            }
            else
                
            {
                await DisplayAlert("Registro Faliido", "Debe llenar todos los campos reuqeridos", "Ok");
            }
            
        }

        private void lbl_nombre_Completed(object sender, EventArgs e)
        {
            progress.ProgressTo(.10, 250, Easing.Linear);
            lbl_progress.Text = "10%";
        }

        private void lbl_apellido_Completed(object sender, EventArgs e)
        {
            progress.ProgressTo(.20, 250, Easing.Linear);
            lbl_progress.Text = "20%";
        }

        private void lbl_domicilio_Completed(object sender, EventArgs e)
        {
            progress.ProgressTo(.30, 250, Easing.Linear);
            lbl_progress.Text = "30%";
        }

        private void lbl_telefono_Completed(object sender, EventArgs e)
        {
            progress.ProgressTo(.40, 250, Easing.Linear);
            lbl_progress.Text = "40%";
        }

        private void lbl_correo_Completed(object sender, EventArgs e)
        {
            progress.ProgressTo(.60, 250, Easing.Linear);
            lbl_progress.Text = "60%";
        }

        private void limpiarRegistros()
        {
            lbl_nombre.Text = "";
            lbl_apellido.Text = "";
            lbl_telefono.Text = "";
            lbl_correo.Text = "";
            lbl_domicilio.Text = "";
            lbl_usuario.Text = "";
            lbl_password.Text = "";
            lbl_password2.Text = "";
        }
    }
}