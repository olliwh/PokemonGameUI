using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using System.Linq;

namespace Engine.Factories
{
    public static class PokemonFactory
    {
        private static List<Pokemon> _pokemons;

        static PokemonFactory()
        {
            _pokemons = new List<Pokemon>();

            _pokemons.Add(new Pokemon(1, "Bulbasaur", 50, 5, "Bulbasaur.png", 10, 20, 10));
            _pokemons.Add(new Pokemon(4, "Charmander", 50, 5, "Charmander.png", 10, 20, 10));
            _pokemons.Add(new Pokemon(7, "Squirtle", 50, 5, "Squirtle.png", 10, 20, 10));
            _pokemons.Add(new Pokemon(74, "Geodude", 50, 5, "Geodude.png", 10, 20, 10));
        }
        public static Pokemon CreatePokemon(int id)
        {
            Pokemon pokemon = _pokemons.FirstOrDefault(item => item.ID == id);

            if(pokemon != null)
            {
                return pokemon.Clone();
            }
            return null;
        }
        public static Pokemon GetPokemon(int pokeID)
        {
            switch(pokeID)
            {
                case 1:
                    Pokemon bulbasaur = new Pokemon(1, "Bulbasaur", 50, 5, "Bulbasaur.png", 10, 20, 10);
                    return bulbasaur;
                case 4:
                    Pokemon charmander = new Pokemon(4, "Charmander", 50, 5, "Charmander.png", 10, 20, 10);
                    return charmander;
                case 7:
                    Pokemon squirtle = new Pokemon(7, "Squirtle", 50, 5, "Squirtle.png", 10, 20, 10);
                    return squirtle;
                case 74:
                    Pokemon geodude = new Pokemon(74, "Geodude", 50, 5, "Geodude.png", 10, 20, 10);
                    return geodude;
                default:
                    throw new ArgumentException(string.Format("PokeType '{0}' does not exist", pokeID));



            }
        }
    }
}
