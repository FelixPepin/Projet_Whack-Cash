using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Whack_Cash
{
    /// <summary>
    /// Logique d'interaction pour FenetreJouer.xaml
    /// </summary>
    public partial class FenetreJouer : Window
    {
        private SoundPlayer _musiqueJeu = new SoundPlayer();
        private int numEnnemi = 0;
        private List<Ennemi> lesEnnemis = new List<Ennemi>();
        private Joueur leJoueur = new Joueur();
        private string _univers;
        private int _compteurClic;
        private MediaPlayer _sfx = new MediaPlayer();

        internal Joueur LeJoueur { get => leJoueur; set => leJoueur = value; }
        /// <summary>
        /// Initialise la fenêtre joueur
        /// </summary>
        /// <param name="univers">L'univers des ennemis à charger</param>
        /// <param name="nomJoueur">Le nom du joueur qui joue</param>
        public FenetreJouer(string univers, string nomJoueur)
        {
            InitializeComponent();
            this.Focus();
            this.Loaded += FenetreJouer_Loaded;
            _univers = univers;


            if (nomJoueur != "")
                LeJoueur = BD.ChargerJoueur(nomJoueur);
            else
                LeJoueur = new Joueur();
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
            if (LeJoueur.Sauvegarde == true)
            {
                MessageBoxResult resultat = MessageBox.Show("Voulez vous continuer votre partie ?\nOui = Continuer" +
                    "\nNon = Nouvelle Partie\nAnnuler = Retour au menu", "Continuer ou Nouvelle Partie", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (resultat == MessageBoxResult.Yes)
                {
                    _univers = LeJoueur.UniversEnCours;
                    MessageBox.Show("Chargement de la partie existante !");
                    lesEnnemis = BD.ChargerLesEnnemi(LeJoueur.UniversEnCours);
                    while (lesEnnemis[numEnnemi].Id != LeJoueur.EnnemiEnCours.Id)
                    {
                        numEnnemi++;
                    }
                    lesEnnemis[numEnnemi].PtsVie = LeJoueur.EnnemiEnCours.PtsVie;
                    FaireApparaitreEnnemi(lesEnnemis[numEnnemi]);
                    txtArgent.Text = "💰 " + LeJoueur.ArgentDansPartie + " $";
                    _musiqueJeu = new SoundPlayer($"Sound/{LeJoueur.UniversEnCours}.wav");
                    _musiqueJeu.PlayLooping();

                }
                else if (resultat == MessageBoxResult.No)
                {
                    MessageBox.Show("Lancement de la nouvelle partie !");
                    CommencerUnePartieDuDebut();
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
                    CommencerUnePartieDuDebut();
                }
                else if (resultat == MessageBoxResult.Cancel)
                {
                    MainWindow menuPrincipale = new MainWindow();
                    menuPrincipale.Show();
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Code pour le bouton Attaquer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_attaquer_Click(object sender, RoutedEventArgs e)
        {
            barreDeVie.Value -= LeJoueur.DegatAttaque;
            txtVie.Text = barreDeVie.Value + " / " + barreDeVie.Maximum;
            lesEnnemis[numEnnemi].PtsVie -= LeJoueur.DegatAttaque;
            _compteurClic += 1;
            if (LeJoueur.ItemTemporaire is not null)
            {
                LeJoueur.ItemTemporaire.NbDeTours--;
                if (LeJoueur.ItemTemporaire.NbDeTours == 0)
                {
                    LeJoueur.SupprimerItemTemporaire();
                }
            }
            

            if (_compteurClic % 10 == 0)
            {
                _sfx.Open(new Uri("Sound/degat.wav", UriKind.Relative));
                _sfx.Play();
                ShakerImage();
            }

            if (lesEnnemis[numEnnemi].PtsVie <= 0 & lesEnnemis.Count != (numEnnemi + 1))
            {
                _sfx.Open(new Uri("Sound/death.wav", UriKind.Relative));
                _sfx.Play();
                LeJoueur.NbEnnemiTuerTotal++;
                LeJoueur.ArgentDansPartie += lesEnnemis[numEnnemi].Recompense;
                leJoueur.ArgentTotal += lesEnnemis[numEnnemi].Recompense;
                txtArgent.Text = "💰 " + LeJoueur.ArgentDansPartie + " $";
                numEnnemi++;
                FaireApparaitreEnnemi(lesEnnemis[numEnnemi]);
            }
            else if (lesEnnemis[numEnnemi].PtsVie <= 0 & lesEnnemis.Count == numEnnemi + 1)
            {
                LeJoueur.NbEnnemiTuerTotal += LeJoueur.NbEnnemiTuerTotal;
                leJoueur.ArgentTotal += lesEnnemis[numEnnemi].Recompense;
                MessageBoxResult resultat = MessageBox.Show("Vous avez terminer le jeu !\n Oui = Retour au menu" +
                   "\n Non = Retour au desktop", "Fin De Partie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (resultat == MessageBoxResult.Yes)
                {
                    MainWindow menuPrincipale = new MainWindow();
                    menuPrincipale.Show();
                    this.Close();
                }
                else
                    this.Close();

            }
        }
        /// <summary>
        /// La boutique s'ouvre lorsqu'on clique sur le bouton boutique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_boutique_Click(object sender, RoutedEventArgs e)
        {
            FenetreBoutique boutique = new FenetreBoutique();
            boutique.Owner = this;
            boutique.LeJoueur = LeJoueur;
            boutique.ShowDialog();

            txtArgent.Text = "💰 " + LeJoueur.ArgentDansPartie + " $";
        }
        /// <summary>
        /// Permet de faire apparaître un ennemi
        /// </summary>
        /// <param name="ennemi">L'ennemi à faire apparaître</param>
        private void FaireApparaitreEnnemi(Ennemi ennemi)
        {

            img_ennemi.Source = ennemi.CheminVersImageEnnemi;
            barreDeVie.Maximum = ennemi.PtsVie;
            barreDeVie.Value = ennemi.PtsVie;
            txtVie.Text = barreDeVie.Value + " / " + barreDeVie.Maximum;


        }
        /// <summary>
        /// Lance une nouvellep partie si aucun utilisateur est connecter ou 
        /// qu'il a choisi de faire une nouvelle partie.
        /// </summary>
        private void CommencerUnePartieDuDebut()
        {
            _musiqueJeu = new SoundPlayer($"Sound/{_univers}.wav");
            _musiqueJeu.PlayLooping();
            lesEnnemis = BD.ChargerLesEnnemi(_univers);
            FaireApparaitreEnnemi(lesEnnemis[numEnnemi]);
        }
        /// <summary>
        /// Permet de sauvegarder la progression du joueur quand on ferme la fenêtre.
        /// </summary>
        private void FenetreJouer_Closed(object sender, EventArgs e)
        {
            _musiqueJeu.Stop();
            if (LeJoueur.Est_connecte)
            {
                BD.SauvegarderUtilisateur(LeJoueur, lesEnnemis[numEnnemi], _univers);
            }
        }
        /// <summary>
        /// Permet de faire trembler l'ennemi à chaque 10 coups.
        /// </summary>
        private async void ShakerImage()
        {
            int amp = 3;
            int rapidite = 30;

            for (int i = 0; i < 3; i++)
            {
                imageShaker.X = amp;
                await Task.Delay(rapidite);
                imageShaker.X = -amp;
                await Task.Delay(rapidite);
            }

            imageShaker.X = 0;
        }
        /// <summary>
        /// Permet de faire apparaître une aura rouge autour du bouton quand on l'hover.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_entre(object sender, EventArgs e)
        {
            img_btn_attaque.Effect = new DropShadowEffect
            {
                Color = Colors.Red,
                BlurRadius = 15,
                ShadowDepth = 0
            };
        }
        /// <summary>
        /// Permet d'enlever l'aura rouge autour du bouton quand on ne l'hover plus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_quitte(object sender, EventArgs e)
        {
            img_btn_attaque.Effect = null;
        }
    }
}
