using PokemonInformationAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonInformationAPI.Services
{
    public interface IPokemonSpeciesService
    {
        Task<PokemonInfoDTO> Get(string name);
    }
}
