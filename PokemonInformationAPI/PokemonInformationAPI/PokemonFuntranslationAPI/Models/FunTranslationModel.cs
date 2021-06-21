using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonFuntranslationAPI.Models
{
    public class FunTranslationModel
    {
        public Contents contents { get; set; }
    }

    public class Contents
    {
        public string translated { get; set; }
    }


}
