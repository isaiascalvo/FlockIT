using ExamenTecnico.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ExamenTecnico.Services
{
    public class MainService : IMainService
    {
        public async Task<ProvData> GetProvByName(string provName)
        {
            var client = new HttpClient();
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?nombre=" + provName;

            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
                request_.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                var response_ = await client.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead);

                var responseText_ = await response_.Content.ReadAsStringAsync();

                if (response_.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseBody = JsonConvert.DeserializeObject<ProvAPIResponse>(responseText_);
                    if (responseBody.Provincias.Count > 0)
                    {
                        return responseBody.Provincias.FirstOrDefault().Centroide;
                    }
                }
                else
                if (response_.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new Exception("401 Unauthorized." + responseText_);
                }
                else
                if (response_.StatusCode != System.Net.HttpStatusCode.OK && response_.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
                    throw new Exception((int)response_.StatusCode + ". No se esperaba el código de estado HTTP de la respuesta. " +
                        responseText_);
                }
                
                return default(ProvData);
            }
        }

        public async Task<User> Login(Login login)
        {
            if (login.Username == "isaías" && login.Password == "isaías")
                return new User
                {
                    Id = 1,
                    Username = "isaías",
                    FirstName = "Isaías",
                    LastName = "Calvo"
                };
            else
                return null;
        }
    }
}
