using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatitasFelices2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        public Principal()
        {
            InitializeComponent();
        }

        private async void btnMisMascotas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoMascotas());
        }

        private async void btnMiPerfil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizaUsuarios());
        }
    }
}