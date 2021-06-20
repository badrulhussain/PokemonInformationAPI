using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PokemonFuntranslationAPI.Services
{
    public class FuntranslationsService : IFuntranslationsService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FuntranslationsService(IHttpClientFactory httpClientFactor)
        {
            this._httpClientFactory = httpClientFactor;
        }

        public async Task<string> GetYoda(string Description)
        {
            return await _httpClientFactory.CreateClient("FunTranslation")
                .GetFromJsonAsync<string>($"yoda.json?text={Description}");
        }

        public async Task<string> GetShakespeare(string Description)
        {
            return await _httpClientFactory.CreateClient("FunTranslation")
                .GetFromJsonAsync<string>($"shakespeare.json?text={Description}");
        }
    }
}
