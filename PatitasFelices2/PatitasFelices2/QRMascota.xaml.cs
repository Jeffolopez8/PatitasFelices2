using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PatitasFelices2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRMascota : ContentPage
    {

        ZXingBarcodeImageView qr;
        public QRMascota(string id, string nombre )
        {
            InitializeComponent();
            lblNombreMascota.Text="Código Qr de: "+nombre;
            txtValorQR.Text = "*Codigo:"+id +"*Nombre: "+ nombre;
           
            generaAutoQR();

        }

        public void generaAutoQR()
        {
            qr = new ZXingBarcodeImageView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeOptions.Width = 500;
            qr.BarcodeOptions.Height = 500;
            qr.BarcodeValue = txtValorQR.Text;
            stkQR.Children.Add(qr);

            

        }

      
    }
}