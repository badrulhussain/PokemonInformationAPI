using Microsoft.AspNetCore.Mvc;
using PokemonFuntranslationAPI.DTOs;
using PokemonFuntranslationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonFuntranslationAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonSpeciesService _pokemonSpeciesService;
        public PokemonController(IPokemonSpeciesService pokemonSpeciesService)
        {
            this._pokemonSpeciesService = pokemonSpeciesService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("translated")]
        public async Task<PokemonInfoDTO> Get(string name)
        {
            return await _pokemonSpeciesService.GetWithTranslation(name);
        }
    }
}
