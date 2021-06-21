using PokemonFuntranslationAPI.DTOs;
using PokemonFuntranslationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonFuntranslationAPI.Services
{
    public class PokemonSpeciesService : IPokemonSpeciesService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFuntranslationsService _funtranslationsService;

        public PokemonSpeciesService(IHttpClientFactory httpClientFactor,
            IFuntranslationsService funtranslationsService)
        {
            this._httpClientFactory = httpClientFactor;
            this._funtranslationsService = funtranslationsService;
        }

        public async Task<PokemonInfoDTO> Get(string name)
        {
            var httpClient = _httpClientFactory.CreateClient("PokemonSpecies");
     
            var pokeInfoModel = await httpClient.GetFromJsonAsync<PokemonInfoModel>(name);

            return new PokemonInfoDTO()
            {
                Name = pokeInfoModel.name,
                Description = pokeInfoModel.flavor_text_entries
                    .FirstOrDefault( e => e.language.name == "en").flavor_text,
                Habitat = pokeInfoModel.habitat.name,
                IsLegendary = pokeInfoModel.is_legendary

            };
        }

        public async Task<PokemonInfoDTO> GetWithTranslation(string name)
        {
            var pokeInfoDTO = await Get(name);

            pokeInfoDTO.Description = pokeInfoDTO.Description
                .Replace("\n", " ")
                .Replace("\f", " ");

            if (pokeInfoDTO.IsLegendary || pokeInfoDTO.Habitat == "cave")
                pokeInfoDTO.Description = await _funtranslationsService
                    .GetYoda(pokeInfoDTO.Description);
            else
                pokeInfoDTO.Description = await _funtranslationsService
                    .GetShakespeare(pokeInfoDTO.Description);

            return pokeInfoDTO;
        }
    }
}
