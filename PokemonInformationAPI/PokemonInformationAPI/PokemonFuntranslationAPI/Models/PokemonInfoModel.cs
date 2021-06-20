using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonFuntranslationAPI.Models
{
    public class PokemonInfoModel
    {
        public Flavor_Text_Entries[] flavor_text_entries { get; set; }
        public Habitat habitat { get; set; }
        public bool is_legendary { get; set; }
        public string name { get; set; }
    }

    public class Habitat
    {
        public string name { get; set; }
    }

    public class Flavor_Text_Entries
    {
        public string flavor_text { get; set; }
        public Language language { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
    }
}
