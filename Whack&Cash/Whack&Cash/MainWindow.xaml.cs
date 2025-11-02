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

        public string Univers { get => _univers; set => _univers = value; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_jouer_Click(object sender, RoutedEventArgs e)
        {
            if (Univers == null)
                Univers = "Fantaisie";
            FenetreJouer fenetreJouer = new FenetreJouer(Univers);
            fenetreJouer.Show();
            this.Close();
        }

        private void btn_connexion_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FenetreConnexion fenetreConnexion = new FenetreConnexion();
            fenetreConnexion.ShowDialog();
            this.Show();

        }

        private void btn_univers_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FenetreUnivers fenetreUnivers = new FenetreUnivers();
            fenetreUnivers.ShowDialog();
            Univers = fenetreUnivers.Univers;
            this.Show();
        }

        private void btn_leaderboard_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FenetreLeaderboard fenetreLeaderboard = new FenetreLeaderboard();
            fenetreLeaderboard.Show();
            this.Show();
        }

        private void btn_credits_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FenetreCredits fenetreCredits = new FenetreCredits();
            fenetreCredits.Show();
            this.Show();
        }

        private void btn_quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}