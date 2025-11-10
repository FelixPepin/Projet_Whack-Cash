using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Logique d'interaction pour FenetreConnexion.xaml
    /// </summary>
    public partial class FenetreConnexion : Window
    {
        private static bool _sauvegarde;

        private static string _nom;

        private static string _mdp;

        private static Joueur leJoueurConnecte;

        private static List<(string, string)> _lesInfosJoueurs;
        public static bool Sauvegarde { get => _sauvegarde; set => _sauvegarde = value; }
        public static string Nom { get => _nom; set => _nom = value; }
        public static string Mdp { get => _mdp; set => _mdp = value; }
        public static List<(string, string)> LesInfosJoueurs { get => _lesInfosJoueurs; set => _lesInfosJoueurs = value; }
        internal static Joueur LeJoueurConnecte { get => leJoueurConnecte; set => leJoueurConnecte = value; }

        public FenetreConnexion()
        {
            InitializeComponent();
            this.Focus();
            Sauvegarde = true;
            LesInfosJoueurs = new List<(string, string)>();
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

        private void btn_authentification_Click(object sender, RoutedEventArgs e)
        {
            Nom = txt_nom.Text;
            Mdp = txt_mdp.Password;
            string messageErreur = "";


            if (Nom.Length < 4 || Nom.Length > 16)
                messageErreur = "Votre nom doit être entre 4 et 16 caractères";
            else if (Mdp.Length < 4 || Mdp.Length > 16)
                messageErreur = "Votre mot de passe doit être entre 4 et 16 caractères";
            else
            {
                LesInfosJoueurs = BD.ChargerInfoTousLesJoueurs();
                foreach ((string, string) infoJoueur in LesInfosJoueurs)
                    if (infoJoueur.Item1 == Nom)
                        messageErreur = "Vous ne pouvez pas avoir un nom déjà utiliser par un autre joueur.";
            }
            
            if (messageErreur != "")
                MessageBox.Show(messageErreur, "Erreur dans l'authentification", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                BD.CreerUtilisateur(Nom, Mdp);
                MessageBox.Show("Votre compte à été créé avec succès!", "Création compte", MessageBoxButton.OK, MessageBoxImage.Information);
                LeJoueurConnecte = BD.ChargerJoueur(Nom);
                this.Close();
            }

        }

        private void btn_connexion_Click(object sender, RoutedEventArgs e)
        {
            Nom = txt_nom.Text;
            Mdp = txt_mdp.Password;
            string messageErreur = "";
            int i = 0;
            bool bTrouve = false;

            if (Nom.Length < 4 || Nom.Length > 16)
                messageErreur = "Votre nom doit être entre 4 et 16 caractères";
            else if (Mdp.Length < 4 || Mdp.Length > 16)
                messageErreur = "Votre mot de passe doit être entre 4 et 16 caractères";
            else
            {
                LesInfosJoueurs = BD.ChargerInfoTousLesJoueurs();
                while (!bTrouve && i < LesInfosJoueurs.Count)
                {
                    if (LesInfosJoueurs[i].Item1 == Nom && LesInfosJoueurs[i].Item2 == Mdp)
                        bTrouve = true;
                    else
                        i++;
                }
                if (!bTrouve)
                    messageErreur = "Aucun utilisateur ne correspond à ce nom ou ce mot de passe.";
            }

            if (messageErreur != "")
                MessageBox.Show(messageErreur, "Erreur dans la connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                LeJoueurConnecte = BD.ChargerJoueur(Nom);
                MessageBox.Show("Bienvenue " + Nom + " , vous êtes maintenant connecté à votre compte!", "Connexion Réussi",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }

        }
    }
}
