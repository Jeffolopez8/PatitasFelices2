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

        
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<PatitasFelices2.WS.Usuarios> _post;

        public PerfilUsuario(String codigoUsuario)
        {
            InitializeComponent();
            lbl_codigo.Text = codigoUsuario;
            PatitasFelices2.WS.Usuarios usuario = new PatitasFelices2.WS.Usuarios();
           // TraeInformacionUsuario();
            llamaUsuarios();
          

        }


        public async void llamaUsuarios()
        {
             string Url = "http://200.12.169.100/patitas/usuarios/post3.php?codigo="+ lbl_codigo.Text;
             WS.ViewModelUsuariocs client = new WS.ViewModelUsuariocs();
            var result = await client.Get<WS.Usuarios>(Url);
            string h = string.Empty;

            if (result != null)
            {
                lbl_codigo.Text = Convert.ToString(result.codigo);
                lbl_nombre.Text = result.nombre;
                lbl_apellido.Text = result.apellido;
                lbl_domicilio.Text = result.direccion;
                lbl_telefono.Text = result.telefono;
                lbl_correo.Text = result.correo;
                lbl_usuario.Text = result.nick;
                lbl_password.Text = result.clave;
                lbl_password2.Text = result.clave;
            }

        }


        public async void TraeInformacionUsuario()
        {
            string Url = "http://200.12.169.100/patitas/usuarios/post3.php?codigo=" + lbl_codigo.Text;
            PatitasFelices2.WS.Usuarios usuario = new PatitasFelices2.WS.Usuarios();
            HttpResponseMessage response = await client.GetAsync($"{Url}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                //var content = await client.GetStringAsync($"{Url2}");

                List<PatitasFelices2.WS.Usuarios> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Usuarios>>(json);
                _post = new ObservableCollection<PatitasFelices2.WS.Usuarios>(posts);

                lbl_codigo.Text = Convert.ToString (posts[0]);

                lbl_nombre.Text = Convert.ToString(posts[1]);



              


               
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

        private async void btn_RegresarU_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpcionesPP(lbl_codigo.Text, lbl_nombre.Text));
        }

        private void btnCambioContrasena_Clicked(object sender, EventArgs e)
        {
            lbl_password.IsVisible = true;
            lbl_password2.IsVisible = true; 
        }
    }
}