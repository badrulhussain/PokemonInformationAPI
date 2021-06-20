using PokemonFuntranslationAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonFuntranslationAPI.Services
{
    public interface IPokemonSpeciesService
    {
        Task<PokemonInfoDTO> Get(string name);
        Task<PokemonInfoDTO> GetWithTranslation(string name);
    }
}
