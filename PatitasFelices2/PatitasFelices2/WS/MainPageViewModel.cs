using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace PatitasFelices2.WS
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        #region Properties
        private string codigo;
        private string nombre;
        private string apellido;
        private string direccion;
        private string telefono;
        private string correo;
        private string nick;
        private string clave;






        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
                OnPropertyChanged();
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
                OnPropertyChanged();
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
                OnPropertyChanged();
            }
        }


        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
                OnPropertyChanged();
            }
        }


        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
                OnPropertyChanged();
            }
        }

        public string Nick
        {
            get
            {
                return nick;
            }

            set
            {
                nick = value;
                OnPropertyChanged();
            }
        }

        public string Clave
        {
            get
            {
                return clave;
            }

            set
            {
                clave = value;
                OnPropertyChanged();
            }
        }


        #endregion

        public async Task GetWeatherAsync(string url)
        {
            //Creamos una instancia de HttpClient
            var client = new HttpClient();
            //Asignamos la URL
            client.BaseAddress = new Uri(url);
            //Llamada asíncrona al sitio
            var respuesta = await client.GetAsync(client.BaseAddress);
            //Nos aseguramos de recibir una respuesta satisfactoria
            respuesta.EnsureSuccessStatusCode();
            //Convertimos la respuesta a una variable string
            var jsonResult = respuesta.Content.ReadAsStringAsync().Result;
            //Se deserializa la cadena y se convierte en una instancia de WeatherResult
            var usuarios = JsonConvert.DeserializeObject <WS.ViewModelUsuariocs> (jsonResult);
            //Asignamos el nuevo valor de las propiedades
            SetValue(usuarios);
        }


        private void SetValue(ViewModelUsuariocs usuarios)
        {
            var nombreusuario = usuarios.nombre;
            var apellidousuario = usuarios.apellido;
            var direccionusuario = usuarios.direccion;
            var telefonousuario = usuarios.telefono;

            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

      



    }
}
