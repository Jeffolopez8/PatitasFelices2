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
        private ObservableCollection<PatitasFelices2.WS.Animales> _post;

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
                string Url2 = "http://200.12.169.100/patitas/mascota/postqr.php?codigo=" + txtcodigomascota.Text;

                HttpResponseMessage response = await client.GetAsync($"{Url2}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //var content = await client.GetStringAsync($"{Url2}");

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
            catch (Exception e)
            {

                await DisplayAlert("Alerta",e.Message.ToString(),"OK");
            }

           





        }

        private void cllvanimales_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
   
