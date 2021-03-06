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

        [HttpGet("translated")]
        public async Task<ActionResult<PokemonInfoDTO>> Get(string name)
        {
            var pokemonInfoDTO = await _pokemonSpeciesService.GetWithTranslation(name);

            if (pokemonInfoDTO == null)
                return NotFound();

            return pokemonInfoDTO;
        }
    }
}
