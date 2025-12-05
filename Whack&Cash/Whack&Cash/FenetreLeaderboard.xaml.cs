using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Whack_Cash
{
    /// <summary>
    /// Logique d'interaction pour FenetreLeaderboard.xaml
    /// </summary>
    public partial class FenetreLeaderboard : Window
    {
        /// <summary>
        /// Initialise la fenêtre leaderboard.
        /// </summary>
        public FenetreLeaderboard()
        {
            InitializeComponent();
            this.Focus();
        }
        /// <summary>
        /// Permet de retourner au menu principale lorsqu'on clique sur ESC
        /// </summary>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
        /// <summary>
        /// Permet de charger les leaderboard lorsque la fenêtre se load.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LeaderboardArgent();
            LeaderboardEnnemi();
        }
        /// <summary>
        /// Permet d'afficher le leaderboard pour l'argent total accumulé.
        /// </summary>
        private void LeaderboardArgent()
        {
            List<(string, int)> topArgent = BD.ChargerLeaderboardArgent();

            _1_nbArgent.Text = $"1. {topArgent[0].Item1} {topArgent[0].Item2} $";
            _2_nbArgent.Text = $"2. {topArgent[1].Item1} {topArgent[1].Item2} $";
            _3_nbArgent.Text = $"3. {topArgent[2].Item1} {topArgent[2].Item2} $";
        }
        /// <summary>
        /// Permet d'afficher le leaderboard pour le nombre ennemi total tués.
        /// </summary>
        private void LeaderboardEnnemi()
        {
            // Try catch ici, recherche catch all app.cs
            List<(string, int)> topEnnemi = BD.ChargerLeaderboardEnnemi();

            _1_nbEnnemi.Text = $"1. {topEnnemi[0].Item1} {topEnnemi[0].Item2} ennemis tués";
            _2_nbEnnemi.Text = $"2. {topEnnemi[1].Item1} {topEnnemi[1].Item2} ennemis tués";
            _3_nbEnnemi.Text = $"3. {topEnnemi[2].Item1} {topEnnemi[2].Item2} ennemis tués";

        }
    }
}
