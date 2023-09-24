using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Player : BaseNotificationClass
    {
        private int _money;
        public ObservableCollection<Pokemon> Pokemons { get; set; }
        public string Name { get; set; }
        public int Money
        {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
                OnPropertyChanged(nameof(Money));
            }
        }
        
        public ObservableCollection<GameItem> Inventory { get; set; }



        //list of items
        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Pokemons = new ObservableCollection<Pokemon>();
        }

        public void AddPokeToInventory(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
            OnPropertyChanged(nameof(Pokemons));
        }


    }
}
