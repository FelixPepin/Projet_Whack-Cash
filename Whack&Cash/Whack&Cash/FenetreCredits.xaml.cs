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
    /// Logique d'interaction pour FenetreCredits.xaml
    /// </summary>
    public partial class FenetreCredits : Window
    {
        /// <summary>
        /// Initialise la fenêtre crédit
        /// </summary>
        public FenetreCredits()
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
        /// Lorsqu'on clique sur se bouton, on retourne au menu principale.
        /// </summary>
        private void btn_retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
