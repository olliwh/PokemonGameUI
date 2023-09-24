using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class PokemonEncounter
    {
        public int PokemonID { get; set; }
        public int ChanceOfEncounter { get; set; }
        public PokemonEncounter(int pokemonID, int chanceOfEncounter)
        {
            PokemonID = pokemonID;
            ChanceOfEncounter = chanceOfEncounter;
        }
    }
}
