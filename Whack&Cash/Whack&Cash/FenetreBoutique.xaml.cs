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
    /// Logique d'interaction pour FenetreBoutique.xaml
    /// </summary>
    public partial class FenetreBoutique : Window
    {
        private List<ItemPermanent> lesItemsPermanents;
        private List<ItemTemporaire> lesItemsTemporaires;
        private Joueur leJoueur;

        internal Joueur LeJoueur { get => leJoueur; set => leJoueur = value; }

        public FenetreBoutique()
        {
            InitializeComponent();
            ChargerListeItems();
        }

        private void btn_retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_acheter_Click(object sender, RoutedEventArgs e)
        {

            if (lst_items.SelectedItem is ItemTemporaire)
            {
                ItemTemporaire itemAAcheter = (ItemTemporaire) lst_items.SelectedItem;
                if (itemAAcheter.Prix > LeJoueur.ArgentDansPartie)
                {
                    MessageBox.Show("Vous n'avez pas assez d'argent pour acheter l'item"
                        , "Manque d'argent", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (LeJoueur.ItemTemporaire is not null)
                {
                    MessageBox.Show("Vous possédez déjà un item temporaire"
                        , "1 item temporaire max", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                    LeJoueur.AjouterItemTemporaire(itemAAcheter);
            }
            else if (lst_items.SelectedItem is ItemPermanent)
            {
                ItemPermanent itemAAcheter = (ItemPermanent)lst_items.SelectedItem;
                if (itemAAcheter.Prix > LeJoueur.ArgentDansPartie)
                {
                    MessageBox.Show("Vous n'avez pas assez d'argent pour acheter l'item"
                        , "Manque d'argent", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else if (leJoueur.LesItemsPermanents.Contains(lst_items.SelectedItem))
                    MessageBox.Show("Vous possédez déjà cette item permanent"
                        , "Manque d'argent", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                            LeJoueur.AjouterItemPermanent(itemAAcheter);
            }
        }

        private void ChargerListeItems()
        {
            if (lesItemsPermanents == null && lesItemsTemporaires == null)
            {
                lesItemsPermanents = BD.ChargerItemPermanent();
                lesItemsTemporaires = BD.ChargerItemTemporaire();
                foreach (ItemTemporaire item in lesItemsTemporaires)
                {
                    lst_items.Items.Add(item);
                }
                foreach (ItemPermanent item in lesItemsPermanents)
                {
                    lst_items.Items.Add(item);
                }
            }
        }

        private void lst_items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lst_items.SelectedItem is ItemTemporaire itemTemp)
            {
                MessageBox.Show(
                    $"Nom : {itemTemp.Nom}\n" +
                    $"Dégâts supplémentaires : {itemTemp.DegatSup}\n" +
                    $"Nombre de tours : {itemTemp.NbDeTours}\n" +
                    $"Prix : {itemTemp.Prix}$\n" +
                    $"Type : {itemTemp.Type}",
                    "Item temporaire");
            }
            else if (lst_items.SelectedItem is ItemPermanent itemPerm)
            {
                MessageBox.Show(
                    $"Nom : {itemPerm.Nom}\n" +
                    $"Dégâts supplémentaires : {itemPerm.DegatSup}\n" +
                    $"Prix : {itemPerm.Prix}$\n" +
                    $"Type : {itemPerm.Type}",
                    "Item permanent");
            }
        }
    }
}
