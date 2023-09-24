using Engine.EventArgs;
using Engine.Factories;
using Engine.Models;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotificationClass
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        private Location _currentLocation;
        private Pokemon _currentPokemon;
        private Pokemon _myCurretnPokemon;
        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationUp));
                OnPropertyChanged(nameof(HasLocationLeft));
                OnPropertyChanged(nameof(HasLocationRight));
                OnPropertyChanged(nameof(HasLocationDown));

                GetPokemonAtLocation();
            }
        }

        public Pokemon CurrentPokemon
        {
            get { return _currentPokemon; }
            set
            {
                _currentPokemon = value;
                OnPropertyChanged(nameof(CurrentPokemon));
                OnPropertyChanged(nameof(HasPokemon));

                if (CurrentPokemon != null)
                {
                    RaiseMessage("");
                    RaiseMessage($"A wild {CurrentPokemon.Name} appeared!");
                }
            }
        }

        public Pokemon MyCurrentPokemon
        { get { return _myCurretnPokemon; } set { _myCurretnPokemon = value; } }

        public bool HasLocationUp
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordainate, CurrentLocation.YCoordinate + 1) != null;
            }
        }

        public bool HasLocationLeft
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordainate - 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public bool HasLocationRight
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordainate + 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public bool HasLocationDown
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordainate, CurrentLocation.YCoordinate - 1) != null;
            }
        }

        public bool HasPokemon => CurrentPokemon != null;

        public GameSession()
        {
            CurrentPlayer = new Player
            {
                Name = "Olli",
                Money = 0
            };
            if (CurrentPlayer.Pokemons.Count == 0)
            {
                CurrentPlayer.AddPokeToInventory(PokemonFactory.CreatePokemon(4));
            }

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 0);
        }

        public void MoveUp()
        {
            if (HasLocationUp)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordainate, CurrentLocation.YCoordinate + 1);
            }
        }

        public void MoveLeft()
        {
            if (HasLocationLeft)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordainate - 1, CurrentLocation.YCoordinate);
            }
        }

        public void MoveRight()
        {
            if (HasLocationRight)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordainate + 1, CurrentLocation.YCoordinate);
            }
        }

        public void MoveDown()
        {
            if (HasLocationDown)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordainate, CurrentLocation.YCoordinate - 1);
            }
        }

        private void GetPokemonAtLocation()
        {
            CurrentPokemon = CurrentLocation.GetPokemon();
        }

        public void AttackCurrentPokemon()
        {
            if (MyCurrentPokemon == null)
            {
                RaiseMessage("You must select pokemon to battle.");
                return;
            }

            List<Pokemon> battlePokes = new List<Pokemon>();
            foreach (Pokemon p in CurrentPlayer.Pokemons)
            {
                battlePokes.Add(p);
            }
            foreach (Pokemon p in battlePokes)
            {
                //determain damage to monster
                int damageToEnemy = RandomNumberGenerator.NumberBetween(MyCurrentPokemon.MinDamage, MyCurrentPokemon.MaxDamage);
                if (damageToEnemy == 0)
                {
                    RaiseMessage($"{MyCurrentPokemon.Name} missed {CurrentPokemon.Name}!");
                }
                else
                {
                    CurrentPokemon.HP -= damageToEnemy;
                    RaiseMessage($"You hit the {CurrentPokemon.Name} for {damageToEnemy} points.");
                }

                //If monster is killed, collect reward and loot
                if (CurrentPokemon.HP <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"You defeated the {CurrentPokemon.Name}!");

                    MyCurrentPokemon.XP += CurrentPokemon.RewardXP;
                    RaiseMessage($"You recieve {CurrentPokemon.RewardXP} XP!");
                }
                else
                {
                    //MOnster is still alive
                    int damageToMyPoke = RandomNumberGenerator.NumberBetween(CurrentPokemon.MinDamage, CurrentPokemon.MaxDamage);
                    if (damageToMyPoke == 0)
                    {
                        RaiseMessage("The Monster missed");
                    }
                    else
                    {
                        MyCurrentPokemon.HP -= damageToMyPoke;
                        RaiseMessage($"The {CurrentPokemon.Name} hit you for {damageToMyPoke} points");
                    }

                    if (MyCurrentPokemon.HP <= 0)
                    {
                        RaiseMessage("");
                        RaiseMessage($"The {CurrentPokemon.Name} killed you.");

                        battlePokes.Remove(p);

                    }
                }
            }
        }

        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
    }
}