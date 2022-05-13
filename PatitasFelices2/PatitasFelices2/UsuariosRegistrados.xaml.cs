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
    public partial class UsuariosRegistrados : ContentPage
    {
        private const string Url = "http://200.12.169.100/patitas/usuarios/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<PatitasFelices2.WS.Usuarios> _post; 

        public UsuariosRegistrados()
        {
            InitializeComponent();
        }

        private async void btnConsultaUsuarios_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url); 
            List<PatitasFelices2.WS.Usuarios> posts = JsonConvert.DeserializeObject<List<PatitasFelices2.WS.Usuarios>>(content);
            _post = new ObservableCollection<PatitasFelices2.WS.Usuarios>(posts);

            listListadeUsuarios.ItemsSource = _post;    
        }
    }   
}