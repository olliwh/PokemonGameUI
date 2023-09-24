using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class PokeBall : GameItem
    {
        public int ChanceOfCatch { get; set; }
        public PokeBall(int id, string name, int price, int chanceOfCatch) 
            : base(id, name, price)
        {
            ChanceOfCatch = chanceOfCatch;
        }
    }
}
