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
    /// Interaction logic for FenetreInscription.xaml
    /// </summary>
    public partial class FenetreInscription : Window
    {
        private static List<(string, string)> _lesInfosJoueurs;
        public static List<(string, string)> LesInfosJoueurs { get => _lesInfosJoueurs; set => _lesInfosJoueurs = value; }


        public FenetreInscription()
        {
            InitializeComponent();
            this.Focus();
            LesInfosJoueurs = new List<(string, string)>();
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void btn_inscription_Click(object sender, RoutedEventArgs e)
        {
            string nom = txt_nom.Text;
            string mdp = txt_mdp.Password;
            string mdpConfirmation = txt_mdpConfirmation.Password;
            string messageErreur = "";


            if (nom.Length < 4 || nom.Length > 16)
                messageErreur = "Votre nom doit être entre 4 et 16 caractères";
            else if (mdp.Length < 4 || mdp.Length > 16)
                messageErreur = "Votre mot de passe doit être entre 4 et 16 caractères";
            else if (mdp != mdpConfirmation)
                messageErreur = "Le mot de passe et sa confirmation doivent être identiques.";
            else
            {
                LesInfosJoueurs = BD.ChargerInfoTousLesJoueurs();
                foreach ((string, string) infoJoueur in LesInfosJoueurs)
                    if (infoJoueur.Item1 == nom)
                        messageErreur = "Vous ne pouvez pas avoir un nom déjà utiliser par un autre joueur.";
            }

            if (messageErreur != "")
                MessageBox.Show(messageErreur, "Erreur dans l'authentification", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                BD.CreerUtilisateur(nom, mdp);
                MessageBox.Show("Votre compte à été créé avec succès, vous pouvez maintenant vous connecter!", "Création compte", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

        }

        private void btn_entre(object sender, EventArgs e)
        {
            img_btn_inscription.Opacity = 0.5;
        }
        private void btn_quitte(object sender, EventArgs e)
        {
            img_btn_inscription.Opacity = 1;
        }
    }
}
