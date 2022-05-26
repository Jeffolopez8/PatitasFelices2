using Newtonsoft.Json;
using PatitasFelices2.WS;
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
    public partial class ListadoMascotas : ContentPage
    {

        private const string Url = "http://200.12.169.100/patitas/mascota/postbusqueda.php?";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<PatitasFelices2.WS.MascotaUsuario> _post;
     
    



        public ListadoMascotas()
        {
            InitializeComponent();
            LoginPF login = new LoginPF();

            string codigousuario = login.traeusuario();


            animalesporusuario(codigousuario);
        }


       public async void animalesporusuario(string codigousu)
        {
            try
            {
                    string Url2 = "http://200.12.169.100/patitas/consultas/post2.php?codigo="+codigousu;
                    HttpResponseMessage response = await client.GetAsync($"{Url2}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //var content = await client.GetStringAsync($"{Url2}");

                    List<PatitasFelices2.WS.MascotaUsuario> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.MascotaUsuario>>(json);
                    _post = new ObservableCollection<PatitasFelices2.WS.MascotaUsuario>(posts);

                    cllvanimales.ItemsSource = _post;


                }
                else
                {
                    var content = await client.GetStringAsync($"{Url2}");

                    List<PatitasFelices2.WS.MascotaUsuario> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.MascotaUsuario>>(content);
                    _post = new ObservableCollection<PatitasFelices2.WS.MascotaUsuario>(posts);
                }

            }
            catch (Exception e)
            {

                await DisplayAlert ("Alerta",e.Message,"Ok");
            }         
           

           

       
        }


        private  void btnConsultaUsuarios_Clicked(object sender, EventArgs e)
        {
           
        }

        private  void btnConsultaUsuarios_Clicked_1(object sender, EventArgs e)
        {
           
        }

        private  void cllvanimales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            /*var obj = (WS.Animales)e.CurrentSelection;
            var item = obj.codigo.ToString();
            int codigoanimal = Convert.ToInt32(item);
            var nombremascota = obj.nombre.ToString();
            string nombre = nombremascota.ToString();


            await Navigation.PushAsync(new InformacionMascota(codigoanimal, nombre));*/
        }

        private async void cllvanimales_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (WS.MascotaUsuario)e.SelectedItem;
            var item = obj.codigo.ToString();
            int codigoanimal = Convert.ToInt32(item);
            var nombremascota = obj.nombremascota.ToString();
            string nombre = nombremascota.ToString();
            var razaanimal = obj.raza.ToString();
            string raza = razaanimal.ToString();

            var fechareg = obj.fecharegistro.ToString();
            string fecha = fechareg.ToString();

            var nombreusu = obj.nombre.ToString();
            string nombreusuario = nombreusu.ToString();

            var apeusu = obj.apellido.ToString();
            string apellidousuario = apeusu.ToString();

            var telfonousu = obj.telefono.ToString();
            string telefonousuario = telfonousu.ToString();

            var correousu = obj.correo.ToString();
            string correousuario = correousu.ToString();



            await Navigation.PushAsync(new InformacionMascota(codigoanimal,nombre, raza, fecha, nombreusuario + " " + apellidousuario, telefonousuario, correousuario));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnNuevaMascota_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroMascota());
        }

        private async void cllvanimales_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (WS.MascotaUsuario)e.SelectedItem;
            var item = obj.codigo.ToString();
            int codigoanimal = Convert.ToInt32(item);
            var nombremascota = obj.nombremascota.ToString();
            string nombre = nombremascota.ToString();
            var razaanimal = obj.raza.ToString();
            string raza = razaanimal.ToString();

            var fechareg = obj.fecharegistro.ToString();
            string fecha = fechareg.ToString();

            var nombreusu = obj.nombre.ToString();
            string nombreusuario = nombreusu.ToString();

            var apeusu = obj.apellido.ToString();
            string apellidousuario = apeusu.ToString();

            var telfonousu = obj.telefono.ToString();
            string telefonousuario = telfonousu.ToString();

            var correousu = obj.correo.ToString();
            string correousuario = correousu.ToString();


            await Navigation.PushAsync(new InformacionMascota(codigoanimal, nombre, raza, fecha, nombreusuario + " " + apellidousuario, telefonousuario, correousuario));
        }
    }
}