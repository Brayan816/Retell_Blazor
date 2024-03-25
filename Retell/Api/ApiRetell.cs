using Newtonsoft.Json;
using Retell.Commons;
using Retell.Model.Login;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using Retell.Model.Llanta;
using Retell.Services;
using Retell.Components.Pages.Llanta;

namespace Retell.Api
{
    public interface IApiRetell
    {
        Task<User> LoginAsync(User user);
        Task<List<LlantaGrid>> GetAllLantas(string texto);
    }
    public class ApiRetell : IApiRetell
    {
        private string baseuri = Helpers.GetApiUrl();
        private readonly HttpClient _httpClient;
        private readonly ISessionService _sesion;

        public ApiRetell(HttpClient httpClient, ISessionService session)
        {
            _httpClient = httpClient;
            _sesion = session;
        }
        public async Task<User> LoginAsync(User user)
        {
            User user1 = new User();
            string uri = $"{baseuri}/Retell/Login?empresa={Security.Encrypt(user.EMPRESA)}&userName={Security.Encrypt(user.USERNAME)}&password={Security.Encrypt(user.PASSWORD)}";
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Send a GET request to the API
                    HttpResponseMessage response = await httpClient.GetAsync(uri);

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and print the response content
                        string responseBody = await response.Content.ReadAsStringAsync();
                        User data = JsonConvert.DeserializeObject<User>(responseBody);
                        return data;
                        Console.WriteLine(responseBody);
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return user1;

        }
        public async Task<List<LlantaGrid>> GetAllLantas(string texto)
        {
            List<LlantaGrid> data = new List<LlantaGrid>();
            string token = await _sesion.GetSessionValue(SessionVariables.TOKEN);
            //return data;
            string uri = $"{baseuri}/Retell/Llanta/ListarLlantas?text={texto}";
            using (HttpClient client = new HttpClient())
            {
                // Agregar el token de autorización al encabezado de la solicitud

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Realizar la solicitud GET a la API
                HttpResponseMessage response = await client.GetAsync(uri);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // Leer y mostrar la respuesta
                    string responseBody = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<LlantaGrid>>(responseBody);
                    return data;
                }
                else
                {
                    // Mostrar el código de estado en caso de error
                    Console.WriteLine($"La solicitud falló con el código de estado: {response.StatusCode}");
                }
            }
            return null;
        }
    }
}
