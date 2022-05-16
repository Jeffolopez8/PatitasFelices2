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
    public partial class ListadoMascotas : ContentPage
    {

        private const string Url = "http://200.12.169.100/patitas/mascota/postbusqueda.php?";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<PatitasFelices2.WS.Usuarios> _post;


        public ListadoMascotas()
        {
            InitializeComponent();

            animalesporusuario();
        }


       public async void animalesporusuario()
        {

            int stParams = 1;

            HttpResponseMessage response = await client.GetAsync($"{Url}{stParams}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                //var content = await client.GetStringAsync($"{Url}");
                
                List<PatitasFelices2.WS.Usuarios> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Usuarios>>(json);
                _post = new ObservableCollection<PatitasFelices2.WS.Usuarios>(posts);

                cllvanimales.ItemsSource = _post;


            }
            else
            {
                var content = await client.GetStringAsync($"{Url}");

                List<PatitasFelices2.WS.Usuarios> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Usuarios>>(content);
                _post = new ObservableCollection<PatitasFelices2.WS.Usuarios>(posts);
            }


           

          

            //listListadeMascotas.ItemsSource = _post;

            /*Uri urlBase = new Uri("http://200.12.169.100");
            string requestUri = "/patitas/animales/post.php?";
            var client = new HttpClient();
            client.BaseAddress = urlBase;
            int stParams = 1;

            HttpResponseMessage response = await client.GetAsync($"{requestUri}{stParams}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }*/







        }


        private async void btnConsultaUsuarios_Clicked(object sender, EventArgs e)
        {
            string stParams = "2";
            var content = await client.GetStringAsync($"{Url}{stParams}");
            List<PatitasFelices2.WS.Usuarios> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Usuarios>>(content);
            _post = new ObservableCollection<PatitasFelices2.WS.Usuarios>(posts);
        }

        private  void btnConsultaUsuarios_Clicked_1(object sender, EventArgs e)
        {
           
        }

        private async void cllvanimales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Navigation.PushAsync(new InformacionMascota());
        }
    }
}