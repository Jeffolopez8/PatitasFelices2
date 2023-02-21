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
    public partial class PrincipalAdopciones : ContentPage
    {
        public PrincipalAdopciones()
        {
            InitializeComponent();
        }

        private async void  btnFundaciones_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoFundaciones());
        }

        private void btnMascotas_Clicked(object sender, EventArgs e)
        {
            //LoginPF login = new LoginPF();

            //string codigousuario = login.traeusuario();




           // await Navigation.PushAsync(new PerfilUsuario(codigousuario));
        }

        private async void btnAnimalesAdopcion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpcionesBusquedaAnimal());
        }

     
    }
}