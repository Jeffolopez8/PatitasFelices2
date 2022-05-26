using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatitasFelices2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPF : ContentPage
    {

       
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<PatitasFelices2.WS.LoginWS> _post;

        public LoginPF()
        {
            InitializeComponent();
        }

        private async void iniciarsesionLogin_Clicked(object sender, EventArgs e)
        {
            try
            {



                string Url = "http://200.12.169.100/patitas/consultas/postlogin.php?nick=" + usuarioLogin.Text + "clave=" + passwordLogin.Text;
                HttpResponseMessage response = await client.GetAsync($"{Url}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var content = await client.GetStringAsync($"{Url}");

                                       

                    if (content.Count() > 0)
                    {
                        await DisplayAlert("Bienvenido "+ usuarioLogin.Text, "Se ha Iniciado sesión correctamente", "Ok");

                        await Navigation.PushAsync(new OpcionesPP());

                    }

                    else
                    {
                        await DisplayAlert("Error", "Credenciales Incorrectas, vuelva a intentar", "Ok");
                        usuarioLogin.Text = "";
                        passwordLogin.Text = "";

                    }







                  


                }
                else
                {

                    await DisplayAlert("Error", "No se Encontraron Registros con el usuario Ingresado", "Ok");

                }




            }
            catch (Exception)
            {

                throw;
            }

            





           
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void AbreRegistro()
        {
            
        }

        void lblClickFuncion()
        {
           
        }

        private async void BtnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUsuario());
        }

        private void BtnRecuperarContrasena_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnRegistro_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}