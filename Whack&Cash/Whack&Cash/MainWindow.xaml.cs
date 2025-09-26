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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_jouer_Click(object sender, RoutedEventArgs e)
        {
            FenetreJouer fenetreJouer = new FenetreJouer();
            fenetreJouer.Show();
            this.Close();
        }

        private void btn_connexion_Click(object sender, RoutedEventArgs e)
        {
            FenetreConnexion fenetreConnexion = new FenetreConnexion();
            fenetreConnexion.Show();
            this.Close();
        }

        private void btn_univers_Click(object sender, RoutedEventArgs e)
        {
            FenetreUnivers fenetreUnivers = new FenetreUnivers();
            fenetreUnivers.Show();
            this.Close();
        }

        private void btn_leaderboard_Click(object sender, RoutedEventArgs e)
        {
            FenetreLeaderboard fenetreLeaderboard = new FenetreLeaderboard();
            fenetreLeaderboard.Show();
            this.Close();
        }

        private void btn_credits_Click(object sender, RoutedEventArgs e)
        {
            FenetreCredits fenetreCredits = new FenetreCredits();
            fenetreCredits.Show();
            this.Close();
        }

        private void btn_quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}