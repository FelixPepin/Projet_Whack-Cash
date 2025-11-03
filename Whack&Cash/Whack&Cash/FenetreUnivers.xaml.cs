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

        private void btn_retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
