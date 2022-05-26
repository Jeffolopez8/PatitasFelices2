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
    public partial class ListadoMascotasporQR : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<PatitasFelices2.WS.MascotaUsuario> _post;

        public ListadoMascotasporQR(string id)
        {

            InitializeComponent();
            txtcodigomascota.Text = id;
            animalesporcodigo();



        }

        public async void animalesporcodigo()
        {
            try
            {
                string Url2 = "http://200.12.169.100/patitas/consultas/post.php?codigo=" + txtcodigomascota.Text;

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

                await DisplayAlert("Alerta",e.Message.ToString(),"OK");
            }

           





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


            string fecha = "";

            var nombreusu = obj.nombre.ToString();
            string nombreusuario = nombreusu.ToString();

            var apeusu = obj.apellido.ToString();
            string apellidousuario = apeusu.ToString();

            var telfonousu = obj.telefono.ToString();
            string telefonousuario = telfonousu.ToString();

            var correousu = obj.correo.ToString();
            string correousuario = correousu.ToString();



            await Navigation.PushAsync(new InformacionMascotaporQr(Convert.ToString(codigoanimal), nombre, raza, fecha, nombreusuario + " " + apellidousuario, telefonousuario, correousuario));


        }
    }
}
   
