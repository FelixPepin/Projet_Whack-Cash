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

        public int DegatAttaque { get => _degatAttaque; set => _degatAttaque = value; }
        public int ArgentDansPartie { get => _argentDansPartie; set => _argentDansPartie = value; }
        public int ArgentTotal { get => _argentTotal; set => _argentTotal = value; }
        public int NbEnnemiTuerPartie { get => _nbEnnemiTuerPartie; set => _nbEnnemiTuerPartie = value; }
        public int NbEnnemiTuerTotal { get => _nbEnnemiTuerTotal; set => _nbEnnemiTuerTotal = value; }
        public ItemTemporaire? ItemTemporaire { get => _itemTemporaire; set => _itemTemporaire = value; }
        public List<ItemPermanent> LesItemsPermanents { get => _lesItemsPermanents; set => _lesItemsPermanents = value; }
        public string Nom { get => nom; set => nom = value; }
        internal Ennemi EnnemiEnCours { get => ennemiEnCours; set => ennemiEnCours = value; }
        public string UniversEnCours { get => universEnCours; set => universEnCours = value; }

        public Joueur()
        {
            DegatAttaque = 1;
            ArgentDansPartie = 0;
            ArgentTotal = 0;
            NbEnnemiTuerPartie = 0;
            NbEnnemiTuerTotal = 0;
            LesItemsPermanents = new List<ItemPermanent>();
        }
        public Joueur(int ennemiEnCours, int pvEnnemiEnCours, int argentDansPartie, int itemTemporaire, string lesItemsPermanent, string univers)
        {
            _degatAttaque = 1;
            EnnemiEnCours = BD.ChargerEnnemiEnCours(ennemiEnCours);
            EnnemiEnCours.PtsVie = pvEnnemiEnCours;
            ArgentDansPartie = argentDansPartie;
            ItemTemporaire = BD.ChargerItemTemporaire(itemTemporaire);

            string[] idItemsPermanent = lesItemsPermanent.Split(',');
            LesItemsPermanents = new List<ItemPermanent>();
            foreach (string id in idItemsPermanent)
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    int idItemPermanent = int.Parse(id);
                    LesItemsPermanents.Add(BD.ChargerItemPermanent(idItemPermanent));
                }
       
            }
            UniversEnCours = univers;
        }
        public void AjouterItemPermanent(ItemPermanent item)
        {
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

        public void EnleverItemTemporaire()
        {
            DegatAttaque = DegatAttaque - ItemTemporaire.DegatSup;
            ItemTemporaire = null;
        }

    }
}
