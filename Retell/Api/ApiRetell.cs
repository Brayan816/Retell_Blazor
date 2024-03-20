using Newtonsoft.Json;
using Retell.Commons;
using Retell.Model.Login;

namespace Retell.Api
{
    public interface IApiRetell
    {
        Task<User> LoginAsync(User user);
    }
    public class ApiRetell : IApiRetell
    {
        private string baseuri = Helpers.GetApiUrl();
        public async Task<User> LoginAsync(User user)
        {
            User user1 = new User();
            string uri = $"{baseuri}/Retell/Login?empresa={Security.Encrypt(user.EMPRESAID)}&userName={Security.Encrypt(user.USERNAME)}&password={Security.Encrypt(user.PASSWORD)}";
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
                        return (User)JsonConvert.DeserializeObject(responseBody, typeof(User));
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
    }
}
