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
        private ObservableCollection<PatitasFelices2.WS.Animales> _post;
     
        private const string Url2 = "http://200.12.169.100/patitas/mascota/post3.php?codigoUsuario=1";



        public ListadoMascotas()
        {
            InitializeComponent();

            animalesporusuario();
        }


       public async void animalesporusuario()
        {
                       
            HttpResponseMessage response = await client.GetAsync($"{Url2}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                //var content = await client.GetStringAsync($"{Url}");
                
                List<PatitasFelices2.WS.Animales> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Animales>>(json);
                _post = new ObservableCollection<PatitasFelices2.WS.Animales>(posts);

                cllvanimales.ItemsSource = _post;


            }
            else
            {
                var content = await client.GetStringAsync($"{Url2}");

                List<PatitasFelices2.WS.Animales> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Animales>>(content);
                _post = new ObservableCollection<PatitasFelices2.WS.Animales>(posts);
            }


           

       
        }


        private  void btnConsultaUsuarios_Clicked(object sender, EventArgs e)
        {
           
        }

        private  void btnConsultaUsuarios_Clicked_1(object sender, EventArgs e)
        {
           
        }

        private async void cllvanimales_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            var obj = (WS.Animales)e.SelectedItem;
            var item = obj.codigo.ToString();
            int codigoanimal = Convert.ToInt32(item);
            var nombremascota = obj.nombre.ToString();
            string nombre = nombremascota.ToString();
            var razaanimal = obj.raza.ToString();
            string raza = razaanimal.ToString();

            var fecharegistro =obj.fecharegistro.ToString();
            string fecha = fecharegistro.ToString();


            await Navigation.PushAsync(new InformacionMascota(codigoanimal,nombre, raza, fecha));
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
            var obj = (WS.Animales)e.SelectedItem;
            var item = obj.codigo.ToString();
            int codigoanimal = Convert.ToInt32(item);
            var nombremascota = obj.nombre.ToString();
            string nombre = nombremascota.ToString();
            var razaanimal = obj.raza.ToString();
            string raza = razaanimal.ToString();

            var fecharegistro = obj.fecharegistro.ToString();
            string fecha = fecharegistro.ToString();


            await Navigation.PushAsync(new InformacionMascota(codigoanimal, nombre, raza, fecha));
        }
    }
}