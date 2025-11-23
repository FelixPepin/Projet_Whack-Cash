using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whack_Cash
{
    internal class Joueur
    {
        private int _degatAttaque;
        private int _argentDansPartie;
        private int _argentTotal;
        private int _nbEnnemiTuerPartie;
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
        public int NbEnnemiTuerPartie { get => _nbEnnemiTuerPartie; set => _nbEnnemiTuerPartie = value; }
        public int NbEnnemiTuerTotal { get => _nbEnnemiTuerTotal; set => _nbEnnemiTuerTotal = value; }
        public ItemTemporaire? ItemTemporaire { get => _itemTemporaire; set => _itemTemporaire = value; }
        public List<ItemPermanent>? LesItemsPermanents { get => _lesItemsPermanents; set => _lesItemsPermanents = value; }
        public string Nom { get => nom; set => nom = value; }
        internal Ennemi EnnemiEnCours { get => ennemiEnCours; set => ennemiEnCours = value; }
        public string UniversEnCours { get => universEnCours; set => universEnCours = value; }
        public bool Sauvegarde { get => sauvegarde; set => sauvegarde = value; }
        public bool Est_connecte { get => est_connecte; set => est_connecte = value; }

        public Joueur()
        {
            DegatAttaque = 1;
            ArgentDansPartie = 0;
            ArgentTotal = 0;
            NbEnnemiTuerPartie = 0;
            NbEnnemiTuerTotal = 0;
            LesItemsPermanents = new List<ItemPermanent>();
            Nom = "";
            Est_connecte = false;
        }
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
        public void AjouterItemPermanent(ItemPermanent item)
        {
            if (LesItemsPermanents is null)
                LesItemsPermanents = new List<ItemPermanent>();
            ArgentDansPartie = ArgentDansPartie - item.Prix;
            DegatAttaque = DegatAttaque + item.DegatSup;
            LesItemsPermanents.Add(item);
        }

        public void AjouterItemTemporaire(ItemTemporaire item)
        {
            ArgentDansPartie = ArgentDansPartie - item.Prix;
            DegatAttaque = DegatAttaque + item.DegatSup;
            ItemTemporaire = item;
        }
        public void AjouterItemPermanentSauvegarder(ItemPermanent item)
        {
            if (LesItemsPermanents is null)
                LesItemsPermanents = new List<ItemPermanent>();
            DegatAttaque = DegatAttaque + item.DegatSup;
            LesItemsPermanents.Add(item);
        }

        public void AjouterItemTemporaireSauvegarder(ItemTemporaire item)
        {
            DegatAttaque = DegatAttaque + item.DegatSup;
            ItemTemporaire = item;
        }

        public void EnleverItemTemporaire()
        {
            DegatAttaque = DegatAttaque - ItemTemporaire.DegatSup;
            ItemTemporaire = null;
        }

    }
}
