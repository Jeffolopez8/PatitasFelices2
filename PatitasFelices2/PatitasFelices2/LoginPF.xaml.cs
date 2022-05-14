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
    public partial class LoginPF : ContentPage
    {
        public LoginPF()
        {
            InitializeComponent();
        }

        private async void iniciarsesionLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpcionesPP());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void AbreRegistro()
        {
            
        }

        void lblClickFuncion()
        {
            lblregistroApp.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
               {
                   AbreRegistro();

               }
               )
             });
        }

        private async void BtnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUsuario());
        }
    }
}