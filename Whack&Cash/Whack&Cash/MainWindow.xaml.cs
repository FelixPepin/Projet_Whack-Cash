using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Whack_Cash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _univers;

        private Joueur _leJoueur;

        public string Univers { get => _univers; set => _univers = value; }
        internal Joueur LeJoueur { get => _leJoueur; set => _leJoueur = value; }
        /// <summary>
        /// Permet d'initialiser le main window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            btn_leaderboard.IsEnabled = false;

        }
        /// <summary>
        /// Permet de lancer une partie
        /// </summary>
        private void btn_jouer_Click(object sender, RoutedEventArgs e)
        {
            if (Univers == null)
                Univers = "Fantaisie";
            string nomJoueur = "";
            if (LeJoueur != null)
                nomJoueur = LeJoueur.Nom;
            FenetreJouer fenetreJouer = new FenetreJouer(Univers, nomJoueur);
            fenetreJouer.Show();
            this.Close();
        }
        /// <summary>
        /// Permet d'ouvrir la fenêtre connexion.
        /// </summary>
        private void btn_connexion_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FenetreConnexion fenetreConnexion = new FenetreConnexion();
            fenetreConnexion.ShowDialog();
            LeJoueur = FenetreConnexion.LeJoueurConnecte;

            if (LeJoueur is not null)
                btn_leaderboard.IsEnabled = true;

            this.Show();

        }
        /// <summary>
        /// Permet d'ouvrir la fenêtre univers.
        /// </summary>
        private void btn_univers_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FenetreUnivers fenetreUnivers = new FenetreUnivers();
            fenetreUnivers.ShowDialog();
            Univers = fenetreUnivers.Univers;
            this.Show();
        }
        /// <summary>
        /// Permet d'ouvrir la fenêtre leaderboard.
        /// </summary>
        private void btn_leaderboard_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FenetreLeaderboard fenetreLeaderboard = new FenetreLeaderboard();
            fenetreLeaderboard.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// Permet d'ouvrir la fenêtre crédits.
        /// </summary>
        private void btn_credits_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FenetreCredits fenetreCredits = new FenetreCredits();
            fenetreCredits.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// Permet de fermer le jeu.
        /// </summary>
        private void btn_quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Permet d'ouvrir la fenêtre inscription. 
        /// </summary>

        private void btn_inscription_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FenetreInscription fenetreInscription = new FenetreInscription();
            fenetreInscription.ShowDialog();
            this.Show();
        }
        /// <summary>
        /// Permet d'ouvrir la fenêtre tutoriel.
        /// </summary>
        private void btn_tutoriel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FenetreTutoriel fenetreTutoriel = new FenetreTutoriel();
            fenetreTutoriel.ShowDialog();
            this.Show();
        }
    }
}