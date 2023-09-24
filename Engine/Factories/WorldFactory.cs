using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();


            newWorld.AddLocation(-1, -1, "Trainer", "Here you can train against trainers", "/Engine;component/Images/Locations/Trainer.png");
            newWorld.AddLocation(0, -1, "Grass", "Good chance of finding Grass type pokemon", "/Engine;component/Images/Locations/Grass.png");
            newWorld.LocationAt(0, -1).AddPokemonToLocation(1, 1);

            newWorld.AddLocation(0, 0, "Home", "This is your house", "/Engine;component/Images/Locations/Home.png");
            newWorld.AddLocation(-1, 0, "PokeMart", "Here you can buy things", "/Engine;component/Images/Locations/PokeMart.png");
            newWorld.AddLocation(-2, 0, "Water", "Good chance of finding Water type pokemon", "/Engine;component/Images/Locations/Water.png");
            newWorld.LocationAt(-2, 0).AddPokemonToLocation(7, 2);

            newWorld.AddLocation(1, 0, "PokeCenter", "Here you can heal your pokemon", "/Engine;component/Images/Locations/PokeCenter.png");
            newWorld.AddLocation(2, 0, "Cave", "Good chance of finding Ground and Rock type pokemon", "/Engine;component/Images/Locations/Cave.png");
            newWorld.LocationAt(2, 0).AddPokemonToLocation(74, 2);

            newWorld.AddLocation(0, 1, "House", "Someone lives here", "/Engine;component/Images/Locations/House.png");
            newWorld.AddLocation(0, 2, "Gym", "Here you can get a Badge", "/Engine;component/Images/Locations/Gym.png");

            return newWorld;
        }
    }
}
