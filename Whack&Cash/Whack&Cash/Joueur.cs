using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whack_Cash
{
    /// <summary>
    /// Représente un jouer, contient le nombre de dégâts qu'il fait, l'argent dans la partie, l'argent total accumulé, le nombre d'ennemi total
    /// tués, son item temporaire, ses items permanents, son nom, l'ennemi en cours, l'univers en cours, si il contient une sauvegarde et s'il il 
    /// est connecté à un compte.
    /// </summary>
    internal class Joueur
    {
        private int _degatAttaque;
        private int _argentDansPartie;
        private int _argentTotal;
        private int _nbEnnemiTuerTotal;
        private ItemTemporaire? _itemTemporaire;
        private List<ItemPermanent> _lesItemsPermanents;
        private string nom;
        private Ennemi ennemiEnCours;
        private string universEnCours;
        private bool sauvegarde;
        private bool est_connecte;

        public int DegatAttaque { get => _degatAttaque; set => _degatAttaque = value; }
        public int ArgentDansPartie { get => _argentDansPartie; set => _argentDansPartie = value; }
        public int ArgentTotal { get => _argentTotal; set => _argentTotal = value; }
        public int NbEnnemiTuerTotal { get => _nbEnnemiTuerTotal; set => _nbEnnemiTuerTotal = value; }
        public ItemTemporaire? ItemTemporaire { get => _itemTemporaire; set => _itemTemporaire = value; }
        public List<ItemPermanent>? LesItemsPermanents { get => _lesItemsPermanents; set => _lesItemsPermanents = value; }
        public string Nom { get => nom; set => nom = value; }
        internal Ennemi EnnemiEnCours { get => ennemiEnCours; set => ennemiEnCours = value; }
        public string UniversEnCours { get => universEnCours; set => universEnCours = value; }
        public bool Sauvegarde { get => sauvegarde; set => sauvegarde = value; }
        public bool Est_connecte { get => est_connecte; set => est_connecte = value; }
        /// <summary>
        /// Premier constructeur d'un joueur si il est non connecté.
        /// </summary>
        public Joueur()
        {
            DegatAttaque = 1;
            ArgentDansPartie = 0;
            ArgentTotal = 0;
            NbEnnemiTuerTotal = 0;
            LesItemsPermanents = new List<ItemPermanent>();
            Nom = "";
            Est_connecte = false;
        }
        /// <summary>
        /// Deuxième constructeur d'un joueur, il est construit grâce à l'ennemi en cours,
        /// les points de vie de l'ennemi en cours, l'argent dans la pratie, l'item temporaire
        /// (si il en as un), les items permanent (si il en as), l'univers des ennemis, si une sauvegarde est présente
        /// et le nom du joueur.
        /// </summary>
        /// <param name="ennemiEnCours"></param>
        /// <param name="pvEnnemiEnCours"></param>
        /// <param name="argentDansPartie"></param>
        /// <param name="itemTemporaire"></param>
        /// <param name="lesItemsPermanent"></param>
        /// <param name="univers"></param>
        /// <param name="sauvegarde"></param>
        /// <param name="nom"></param>
        public Joueur(int ennemiEnCours, int pvEnnemiEnCours, int argentDansPartie, int itemTemporaire, string lesItemsPermanent
            , string univers, bool sauvegarde, string nom)
        {
            DegatAttaque = 1;
            Nom = nom;
            if (sauvegarde)
            {
                EnnemiEnCours = BD.ChargerEnnemiEnCours(ennemiEnCours);
                EnnemiEnCours.PtsVie = pvEnnemiEnCours;
                ArgentDansPartie = argentDansPartie;
                if (itemTemporaire != 0)
                {
                    ItemTemporaire item = BD.ChargerItemTemporaire(itemTemporaire);
                    AjouterItemTemporaireSauvegarder(item);
                }
                string[] idItemsPermanent = lesItemsPermanent.Split(',');
                LesItemsPermanents = new List<ItemPermanent>();
                foreach (string id in idItemsPermanent)
                {
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        int idItemPermanent = int.Parse(id);
                        ItemPermanent item = BD.ChargerItemPermanent(idItemPermanent);
                        AjouterItemPermanentSauvegarder(item);
                    }

                }
               
                UniversEnCours = univers;
            }
            Est_connecte = true;
            Sauvegarde = sauvegarde;
        }
        /// <summary>
        /// Permet d'acheter et d'ajouter un item permanent au joueur.
        /// </summary>
        /// <param name="item">L'item qu'on veut acheter.</param>
        public void AjouterItemPermanent(ItemPermanent item)
        {
            if (LesItemsPermanents is null)
                LesItemsPermanents = new List<ItemPermanent>();
            ArgentDansPartie = ArgentDansPartie - item.Prix;
            DegatAttaque = DegatAttaque + item.DegatSup;
            LesItemsPermanents.Add(item);
        }
        /// <summary>
        /// Permet d'acheter et d'ajouter un item temporaire au joueur.
        /// </summary>
        /// <param name="item"></param>
        public void AjouterItemTemporaire(ItemTemporaire item)
        {
            ArgentDansPartie = ArgentDansPartie - item.Prix;
            DegatAttaque = DegatAttaque + item.DegatSup;
            ItemTemporaire = item;
        }
        /// <summary>
        /// Permet de charger un item permanent déjà acheter par le joueur dans
        /// une partie précédente.
        /// </summary>
        /// <param name="item"></param>
        public void AjouterItemPermanentSauvegarder(ItemPermanent item)
        {
            if (LesItemsPermanents is null)
                LesItemsPermanents = new List<ItemPermanent>();
            DegatAttaque = DegatAttaque + item.DegatSup;
            LesItemsPermanents.Add(item);
        }
        /// <summary>
        /// Permet de supprimer un intem temporaire quand le nombre de tours est épuisé.
        /// </summary>
        public void SupprimerItemTemporaire()
        {
            DegatAttaque = DegatAttaque - ItemTemporaire.DegatSup;
            ItemTemporaire = null;
        }
        /// <summary>
        /// Permet de charger un item temporaire déjà acheter par le joueur dans
        /// une partie précédente.
        /// </summary>
        /// <param name="item"></param>
        public void AjouterItemTemporaireSauvegarder(ItemTemporaire item)
        {
            DegatAttaque = DegatAttaque + item.DegatSup;
            ItemTemporaire = item;
        }
    }
}
