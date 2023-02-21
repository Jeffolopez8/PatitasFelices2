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
    public partial class OpcionesBusquedaAnimal : ContentPage
    {

        int portipo = 0;
        int porsexo = 0;
        int poredad = 0;
        public OpcionesBusquedaAnimal()
        {
            InitializeComponent();

            LoginPF login = new LoginPF();

            string codigousuario = login.traeusuario();

            

        }

        private async void btn_iniciabusquedaanimal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoAnimaleaAdoptar(1,portipo,porsexo,poredad,0));
        }

        private void rbtperro_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            portipo = 0;
        }

        private void rbtGato_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            portipo = 1;
        }

        
        private void rbtmacho_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
        {
            porsexo = 0;
;        }

        private void rbthembra_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            porsexo = 1;
        }

        private void rbtcachorro_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            poredad= 0;
        }

        private void rbtAdulto_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            poredad = 1;
        }
    }
}