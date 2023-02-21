using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PatitasFelices2.WS;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatitasFelices2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoAnimaleaAdoptar : ContentPage
    {

        private const string Url = "http://200.12.169.100/patitas/Fundaciones/listadoanimalesporbusqueda.php?";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<PatitasFelices2.WS.MascotasAdoptar> _post;

        public ListadoAnimaleaAdoptar(int vienede, int tipo, int sexo, int edad, int fundacion)
        {
            InitializeComponent();

            InitializeComponent();
            LoginPF login = new LoginPF();

            string codigousuario = login.traeusuario();

           
            
            if (vienede == 0)
            {
                animalesporfundacion(fundacion);

            }
            else{

                animalesporbusqueda(tipo,sexo,edad);

            }         


        }


        public async void animalesporfundacion(int codigoFundacion)
        {
            try
            {

            

                string Url2 = "http://200.12.169.100/patitas/Fundaciones/listadoanimalesporFundaciones.php?fundacionquepertenece_Animal=" + codigoFundacion;
                HttpResponseMessage response = await client.GetAsync($"{Url2}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //var content = await client.GetStringAsync($"{Url2}");

                    List<PatitasFelices2.WS.MascotasAdoptar> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.MascotasAdoptar>>(json);
                    _post = new ObservableCollection<PatitasFelices2.WS.MascotasAdoptar>(posts);

                    cllvanimales.ItemsSource = _post;


                }
                else
                {
                    var content = await client.GetStringAsync($"{Url2}");

                    List<PatitasFelices2.WS.MascotasAdoptar> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.MascotasAdoptar>>(content);
                    _post = new ObservableCollection<PatitasFelices2.WS.MascotasAdoptar>(posts);
                }

            }
            catch (Exception e)
            {

                await DisplayAlert("Alerta", e.Message, "Ok");
            }





        }



        public async void animalesporbusqueda(int tipo, int sexo, int edad)
        {
            try
            {

            
                string Url2 = "http://200.12.169.100/patitas/Fundaciones/listadoanimalesporbusqueda.php?tipo_Animal=" + tipo + "&sexo_Animal=" + sexo + "&edad_Animal" + edad;
                HttpResponseMessage response = await client.GetAsync($"{Url2}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //var content = await client.GetStringAsync($"{Url2}");

                    List<PatitasFelices2.WS.MascotasAdoptar> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.MascotasAdoptar>>(json);
                    _post = new ObservableCollection<PatitasFelices2.WS.MascotasAdoptar>(posts);

                    cllvanimales.ItemsSource = _post;


                }
                else
                {
                    var content = await client.GetStringAsync($"{Url2}");

                    List<PatitasFelices2.WS.MascotasAdoptar> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.MascotasAdoptar>>(content);
                    _post = new ObservableCollection<PatitasFelices2.WS.MascotasAdoptar>(posts);
                }

            }
            catch (Exception e)
            {

                await DisplayAlert("Alerta", e.Message, "Ok");
            }





        }




        private void cllvanimales_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}