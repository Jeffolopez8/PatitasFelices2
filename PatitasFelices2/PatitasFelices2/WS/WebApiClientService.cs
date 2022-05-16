using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices2.WS
{
   


    public class WebApiClientService
    {
        Uri urlBase = new Uri("http://200.12.169.100");

        public async Task<T> executeRequestPost<T>(object objectParams)
        {
            string requestUri = "/patitas/mascota/post.php";

            var client = new HttpClient();
            client.BaseAddress = urlBase;

            string jsonData = JsonConvert.SerializeObject(objectParams);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(requestUri, content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }
    }
}
