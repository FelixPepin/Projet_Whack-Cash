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
    /// Logique d'interaction pour FenetreJouer.xaml
    /// </summary>
    public partial class FenetreJouer : Window
    {
        private int compteur = 0;
        public FenetreJouer()
        {
            InitializeComponent();
            this.Focus();
            this.Loaded += FenetreJouer_Loaded;
            
        }
        /// <summary>
        /// Fonction qui se lance quand la page fini de load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FenetreJouer_Loaded(object sender, RoutedEventArgs e)
        {

            LancementPartie();
        }

        /// <summary>
        /// Permet de faire apparaître un menu pause lorsque le joueur clic sur Echap
        /// </summary>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MessageBoxResult resultat = MessageBox.Show("Voulez vous quitter cette partie ? \nOui = Retour au menu principal" +
                    "\nNon = Continuer la partie \nAnnuler = Retour au desktop", "Menu Pause", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (resultat == MessageBoxResult.Yes)
                {
                    MainWindow menuPrincipale = new MainWindow();
                    menuPrincipale.Show();
                    this.Close();
                }
                else if (resultat == MessageBoxResult.Cancel)
                {
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Gère le lancement d'une partie dépendant si une sauvegarde est présente ou non.
        /// </summary>
        private void LancementPartie()
        {
            // Si une sauvegarde existe, on demande au joueur si il veut continuer sa partie,
            // commencer une nouvelle partie ou retourner au menu.
            if (FenetreConnexion.Sauvegarde == true) 
            { 
                MessageBoxResult resultat = MessageBox.Show("Voulez vous continuer votre partie ?\nOui = Continuer" +
                    "\nNon = Nouvelle Partie\nAnnuler = Retour au menu", "Continuer ou Nouvelle Partie", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (resultat == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Chargement de la partie existante !");
                }
                else if (resultat == MessageBoxResult.No)
                {
                    MessageBox.Show("Lancement de la nouvelle partie !");
                }
                else if (resultat == MessageBoxResult.Cancel)
                {
                    MainWindow menuPrincipale = new MainWindow();
                    menuPrincipale.Show();
                    this.Close();
                }
            }
            // Si aucune sauvegarde existe, on demande au jouer si il veut commencer une nouvelle partie
            // ou retourner au menu
            else
            {
                MessageBoxResult resultat = MessageBox.Show("Voulez vous commencer une Nouvelle partie ?\n OK = Nouvelle partie" +
                    "\n Annuler = Retour au menu", "Nouvelle Partie", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (resultat == MessageBoxResult.OK)
                {
                    MessageBox.Show("Lancement de la nouvelle partie !");
                }
                else if (resultat == MessageBoxResult.Cancel)
                {
                    MainWindow menuPrincipale = new MainWindow();
                    menuPrincipale.Show();
                    this.Close();
                }
            }
        }

        private void btn_attaquer_Click(object sender, RoutedEventArgs e)
        {
            compteur++;

            if (compteur % 10 == 0)
            {
                MessageBox.Show("Vous avez cliquer " + compteur + " fois sur le bouton Attaquer!");
            }
        }

        private void btn_boutique_Click(object sender, RoutedEventArgs e)
        {
            FenetreBoutique boutique = new FenetreBoutique();
            boutique.Owner = this;
            boutique.ShowDialog();
        }
    }
}
