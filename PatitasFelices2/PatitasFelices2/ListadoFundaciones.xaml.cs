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
    public partial class ListadoFundaciones : ContentPage
    {

        private const string Url = "http://200.12.169.100/patitas/Fundaciones/postlistaFundaciones.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<PatitasFelices2.WS.Fundaciones> _post;

        public ListadoFundaciones()
        {
            InitializeComponent();
            LoginPF login = new LoginPF();
            string codigousuario = login.traeusuario();
            litarFundaciones();
            btnNuevaFundacion.IsVisible.Equals(false);

            if (codigousuario == "99")
            { 
                btnNuevaFundacion.IsVisible.Equals(true);  
            }

        }


        public async void litarFundaciones()
        {
            try
            {
                string Url2 = "http://200.12.169.100/patitas/Fundaciones/postlistaFundaciones.php";
               
                HttpResponseMessage response = await client.GetAsync($"{Url2}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //var content = await client.GetStringAsync($"{Url2}");

                    List<PatitasFelices2.WS.Fundaciones> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Fundaciones>>(json);
                    _post = new ObservableCollection<PatitasFelices2.WS.Fundaciones>(posts);

                    cllFundaciones.ItemsSource = _post;

                }
                else
                {
                    var content = await client.GetStringAsync($"{Url2}");

                    List<PatitasFelices2.WS.Fundaciones> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Fundaciones>>(content);
                    _post = new ObservableCollection<PatitasFelices2.WS.Fundaciones>(posts);
                }

            }
            catch (Exception e)
            {

                await DisplayAlert("Alerta", e.Message, "Ok");
            }

        }
        private void btnNuevaFundacion_Clicked(object sender, EventArgs e)
        {

        }

        private async void cllFundaciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (WS.Fundaciones)e.SelectedItem;
            var item = obj.Cod_Fundacion.ToString();
            int codigofundacion = Convert.ToInt32(item);

            await Navigation.PushAsync(new ListadoAnimaleaAdoptar(0, 0, 0, 0, codigofundacion));
        }
    }
}