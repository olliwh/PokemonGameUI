using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Engine.Models
{
    public class Pokemon : BaseNotificationClass
    {
        private int _hp;
        private int _xp;
        private int _level;
        public int ID { get; set; }
        public string ImageName { get; set; }
        public string Name { get; set; }
        public int HP
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
                OnPropertyChanged(nameof(HP));
            }
        }
        public int XP
        {
            get
            {
                return _xp;
            }
            set
            {
                _xp = value;
                OnPropertyChanged(nameof(XP));
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int RewardXP { get; set; }
        //list atack

        public Pokemon(int id, string name, int hp, int level, string imageName, int minDamage, int maxDamage, int rewardXP)
        {
            ID = id;
            Name = name;
            HP = hp;
            Level = level;
            ImageName = $"C:\\Users\\olivi\\source\\repos\\PokemonGameUI\\Engine\\Images\\Pokemons/{imageName}";
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            RewardXP = rewardXP * level;
        }
        public Pokemon Clone()
        {
            return new Pokemon(ID, Name, HP, Level, ImageName, MinDamage, MaxDamage, RewardXP);
        }

    }
}
