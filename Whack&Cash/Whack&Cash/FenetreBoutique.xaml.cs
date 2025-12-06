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

        /// <summary>
        /// Initilalise la fenêtre boutique.
        /// </summary>
        public FenetreBoutique()
        {
            InitializeComponent();
            ChargerListeItems();
            this.Loaded += FenetreBoutique_Loaded;
        }
        /// <summary>
        /// Permet de retourner au jeu.
        /// </summary>
        private void btn_retour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Permet d'afficher le nombre d'argent qu'un utilisateur as
        /// </summary>
        private void FenetreBoutique_Loaded(object sender, RoutedEventArgs e)
        {
            txtArgent.Text = "💰 " + LeJoueur.ArgentDansPartie + " $";
        }
        /// <summary>
        /// Permet d'acheter un item.
        /// </summary>
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
                {
                    LeJoueur.AjouterItemTemporaire(itemAAcheter);
                    MessageBox.Show($"Félicitations! Vous êtes l'heureux propriétaire de {itemAAcheter.Nom}", "Confirmation d'achat d'item.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

            }
            else if (lst_items.SelectedItem is ItemPermanent)
            {
                ItemPermanent itemAAcheter = (ItemPermanent)lst_items.SelectedItem;
                if (itemAAcheter.Prix > LeJoueur.ArgentDansPartie)
                {
                    MessageBox.Show("Vous n'avez pas assez d'argent pour acheter l'item"
                        , "Manque d'argent", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                else if (leJoueur.LesItemsPermanents != null && leJoueur.LesItemsPermanents.Contains(lst_items.SelectedItem))
                    MessageBox.Show("Vous possédez déjà cette item permanent"
                        , "Manque d'argent", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    LeJoueur.AjouterItemPermanent(itemAAcheter);
                    MessageBox.Show($"Félicitations! Vous êtes l'heureux propriétaire de {itemAAcheter.Nom}", "Confirmation d'achat d'item.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            txtArgent.Text = "💰 " + LeJoueur.ArgentDansPartie + " $";
        }
        /// <summary>
        /// Permet de charger tous les items et de l'afficher dans un listbox.
        /// </summary>
        private void ChargerListeItems()
        {
            if (lesItemsPermanents == null && lesItemsTemporaires == null)
            {
                lesItemsPermanents = BD.ChargerLesItemPermanent();
                lesItemsTemporaires = BD.ChargerLesItemTemporaire();
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
        /// <summary>
        /// Quand la sélection d'un item change, on affiche son prix, ses dégats 
        /// supplémentaires, le type et le nombre de tours si l'item est temporaire.
        /// </summary>
        private void lst_items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lst_items.SelectedItem is ItemTemporaire itemTemp)
            {
                txt_prix.Text = "Prix : " + itemTemp.Prix;
                txt_degat.Text = "Dégâts : " + itemTemp.DegatSup;
                txt_type.Text = "Type : " + itemTemp.Type;
                txt_tour.Text = "Nb tours : " + itemTemp.NbDeTours;
            }
            else if (lst_items.SelectedItem is ItemPermanent itemPerm)
            {
                txt_prix.Text = "Prix : " + itemPerm.Prix;
                txt_degat.Text = "Dégâts : " + itemPerm.DegatSup;
                txt_type.Text = "Type : " + itemPerm.Type;
                txt_tour.Text = "";
            }
        }
    }
}
