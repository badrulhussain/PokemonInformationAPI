using PokemonInformationAPI.DTOs;
using PokemonInformationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonInformationAPI.Services
{
    public class PokemonSpeciesService : IPokemonSpeciesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PokemonSpeciesService(IHttpClientFactory httpClientFactor)
        {
            this._httpClientFactory = httpClientFactor;
        }

        public async Task<PokemonInfoDTO> Get(string name)
        {
            var httpClient = _httpClientFactory.CreateClient("PokemonSpecies");
     
            var pokeInfoModel = await httpClient.GetFromJsonAsync<PokemonInfoModel>(name);

            return new PokemonInfoDTO()
            {
                Name = pokeInfoModel.name,
                Description = pokeInfoModel.flavor_text_entries
                    .FirstOrDefault( e => e.language.name == "en")
                    .flavor_text
                    .Replace("\n", " ")
                    .Replace("\f", " "),
                Habitat = pokeInfoModel.habitat.name,
                IsLegendary = pokeInfoModel.is_legendary

            };
        }
    }
}
