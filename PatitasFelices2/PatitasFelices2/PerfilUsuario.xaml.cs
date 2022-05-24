using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatitasFelices2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilUsuario : ContentPage
    {

        private const string Url = "http://200.12.169.100/patitas/usuarios/post3.php?codigo=1";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<PatitasFelices2.WS.Usuarios> _post;

          public PerfilUsuario( String codigoUsuario)
        {
            InitializeComponent();
            TraeInformacionUsuario();
        }


        public async void TraeInformacionUsuario()
        {
            HttpResponseMessage response = await client.GetAsync($"{Url}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                //var content = await client.GetStringAsync($"{Url}");

                List<PatitasFelices2.WS.Usuarios> result = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Usuarios>>(json);
                _post = new ObservableCollection<PatitasFelices2.WS.Usuarios>(result);
                                       


            }
            else
            {
                var content = await client.GetStringAsync($"{Url}");

                List<PatitasFelices2.WS.Usuarios> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Usuarios>>(content);
                _post = new ObservableCollection<PatitasFelices2.WS.Usuarios>(posts);
            }


        }

        private async void btn_ActualizarUsuario_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", lbl_codigo.Text);
                parametros.Add("nombre", lbl_nombre.Text);
                parametros.Add("apellido", lbl_apellido.Text);
                parametros.Add("direccion", lbl_domicilio.Text);
                parametros.Add("telefono", lbl_telefono.Text);
                parametros.Add("correo", lbl_correo.Text);

                parametros.Add("nick", lbl_usuario.Text);
                parametros.Add("clave", lbl_password2.Text);



                cliente.UploadValues("http://200.12.169.100/patitas/usuarios/actualizarusuario.php?codigo=" + lbl_codigo.Text + "&nombre=" + lbl_nombre.Text + 
                    
                                     "&apellido=" + lbl_apellido.Text + "&direccion=" + lbl_domicilio.Text +

                                      "&telefono=" + lbl_telefono.Text + "&correo=" + lbl_correo.Text+
                                       "&nick=" + lbl_usuario.Text + "&clave=" + lbl_password2.Text, "PUT",parametros);




                await DisplayAlert("Alerta", "Usuario Actualizado Correctamente", "Ok");

                await Navigation.PushAsync(new PerfilUsuario(lbl_codigo.Text));


            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Usuario No Actualizad" + ex.Message, "Ok");
            }



        }

        private void btn_RegresarU_Clicked(object sender, EventArgs e)
        {

        }

        private void btnCambioContrasena_Clicked(object sender, EventArgs e)
        {
            lbl_password.IsVisible = true;
            lbl_password2.IsVisible = true; 
        }
    }
}