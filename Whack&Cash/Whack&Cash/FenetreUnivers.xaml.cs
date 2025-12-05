using System;
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
using System.Windows.Shapes;

namespace Whack_Cash
{
    /// <summary>
    /// Logique d'interaction pour FenetreUnivers.xaml
    /// </summary>
    public partial class FenetreUnivers : Window
    {
        private string _univers;

        public string Univers { get => _univers; set => _univers = value; }

        /// <summary>
        /// Initialise la fenêtre univers.
        /// </summary>
        public FenetreUnivers()
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
        /// Permet de sélectionner l'univers fantaisie.
        /// </summary>
        private void btn_fantaisie_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultat = MessageBox.Show("Confirmez-vous le choix de l'univers Fantaisie ?"
                ,"Choix Fantaisie" ,MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultat == MessageBoxResult.Yes)
            {
                Univers = "Fantaisie";
                this.Close();
            }
        }
        /// <summary>
        /// Permet de sélectionner l'univers Star Wars.
        /// </summary>
        private void btn_star_wars_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultat = MessageBox.Show("Confirmez-vous le choix de l'univers Star Wars ?"
                , "Choix Star Wars", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultat == MessageBoxResult.Yes)
            {
                Univers = "Star Wars";
                this.Close();
            }
        }
        /// <summary>
        /// Permet de sélectionner l'univers Gaming.
        /// </summary>
        private void btn_gaming_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultat = MessageBox.Show("Confirmez-vous le choix de l'univers Gaming ?"
                , "Choix Gaming", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultat == MessageBoxResult.Yes)
            {
                Univers = "Gaming";
                this.Close();
            }
        }
        /// <summary>
        /// Permet de sélectionner l'univers anime.
        /// </summary>
        private void btn_anime_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultat = MessageBox.Show("Confirmez-vous le choix de l'univers Anime ?"
                , "Choix Anime", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultat == MessageBoxResult.Yes)
            {
                Univers = "Anime";
                this.Close();
            }
        }
        /// <summary>
        /// Lorsqu'on clique sur se bouton, on retourne au menu principale.
        /// </summary>
        private void btn_retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
