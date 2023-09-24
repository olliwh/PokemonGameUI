using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using System.Linq;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _gameItems;

        static ItemFactory()
        {
            _gameItems = new List<GameItem>();
            _gameItems.Add(new PokeBall(1001, "Poke Ball", 70, 7));
            _gameItems.Add(new GameItem(2001, "HP UP", 150));
        }
        public static GameItem CreateGameItem(int id)
        {
            GameItem gameItem = _gameItems.FirstOrDefault(item => item.ItemTypeID == id);
            if(gameItem != null)
            {
                return gameItem;
            }
            return null;
        }
    }
}
