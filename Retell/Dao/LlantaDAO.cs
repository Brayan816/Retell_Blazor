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
        public async Task<List<DeLlanta>> GetAllDeLlantas(string llantaId)
        {
            List<DeLlanta> data = await _apiRetell.GetAllDeLlantas(llantaId);
            return data;
        }
        public async Task<List<LlantaDoc>> GetAllDocLlantas(string llantaId)
        {
            List<LlantaDoc> data = await _apiRetell.GetAllDocLlantas(llantaId);
            return data;
        }
        public async Task<ModelLlanta> GetLlanta(string llantaId)
        {
            ModelLlanta data = await _apiRetell.GetLlanta(llantaId);
            return data;
        }
    }
}
