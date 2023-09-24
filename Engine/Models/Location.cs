using Engine.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordainate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public List<PokemonEncounter> PokemonHere { get; set; } = new List<PokemonEncounter>();

        public void AddPokemonToLocation(int pokemonID, int chanceOfEncounter)
        {
            if(PokemonHere.Exists(p => p.PokemonID == pokemonID))
            {
                //pokemon is here so edit chance of encounter
                PokemonHere.First(p => p.PokemonID == pokemonID).ChanceOfEncounter = chanceOfEncounter;
            }
            else
            {
                PokemonHere.Add(new PokemonEncounter(pokemonID, chanceOfEncounter));
            }
        }
        public Pokemon GetPokemon()
        {
            if(!PokemonHere.Any())
            {
                return null;
            }
            int totalChanceOfEncounter = PokemonHere.Sum(p => p.ChanceOfEncounter);
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChanceOfEncounter);

            int runningTotal = 0;
            foreach(PokemonEncounter pokeE in PokemonHere)
            {
                runningTotal += 1;
                if(randomNumber <= runningTotal)
                {
                    return PokemonFactory.GetPokemon(pokeE.PokemonID);
                }
            }

            //if there is a problem return last in list
            return null;
        }
    }
}
