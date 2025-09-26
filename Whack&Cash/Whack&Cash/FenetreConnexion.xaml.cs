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
    /// Logique d'interaction pour FenetreConnexion.xaml
    /// </summary>
    public partial class FenetreConnexion : Window
    {
        public FenetreConnexion()
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
                MainWindow menuPrincipale = new MainWindow();
                menuPrincipale.Show();
                this.Close();
            }
        }
    }
}
