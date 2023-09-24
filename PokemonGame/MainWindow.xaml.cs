﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Engine.EventArgs;
using Engine.ViewModels;

namespace PokemonGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession _gameSession;
        public MainWindow()
        {
            InitializeComponent();

            _gameSession = new GameSession();

            _gameSession.OnMessageRaised += OnGameMessageRaised;

            DataContext = _gameSession;
        }

        private void OnClick_MoveUp(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveUp();
        }
        private void OnClick_MoveLeft(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveLeft();
        }
        private void OnClick_MoveRight(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveRight();
        }
        private void OnClick_MoveDown(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveDown();
        }
        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }
        private void OnClick_AttackPokemon(object sender, RoutedEventArgs e)
        {
            _gameSession.AttackCurrentPokemon();
        }
    }
}
