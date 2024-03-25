using Microsoft.AspNetCore.Components;
using Retell.Api;
using Retell.Components.Pages.Llanta;
using Retell.Model.Llanta;
using Retell.Model.Login;
using Retell.Services;

namespace Retell.Dao
{
    public class LlantaDao
    {
        private readonly IApiRetell _apiRetell;
        public LlantaDao(IApiRetell apiRetell) { 
            _apiRetell = apiRetell;
        }
        public async Task<List<LlantaGrid>> GetAllLlantas(string texto)
        {
            List<LlantaGrid> data = await _apiRetell.GetAllLantas("");
            return data;
        }
    }
}
