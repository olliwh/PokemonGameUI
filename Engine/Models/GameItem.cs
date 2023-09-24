using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class GameItem
    {
        public int ItemTypeID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public GameItem(int id, string name, int price)
        {
            ItemTypeID = id;
            Name = name;
            Price = price;
        }
    }
}
