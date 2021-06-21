using PokemonFuntranslationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonFuntranslationAPI.Services
{
    public interface IFuntranslationsService
    {
        Task<string> GetShakespeare(string Description);
        Task<string> GetYoda(string Description);
    }
}
