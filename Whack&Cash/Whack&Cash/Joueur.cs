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
        private ItemTemporaire _itemTemporaire;
        private List<ItemPermanent> _lesItemsPermanents;

        public int DegatAttaque { get => _degatAttaque; set => _degatAttaque = value; }
        public int ArgentDansPartie { get => _argentDansPartie; set => _argentDansPartie = value; }
        public int ArgentTotal { get => _argentTotal; set => _argentTotal = value; }
        public int NbEnnemiTuerPartie { get => _nbEnnemiTuerPartie; set => _nbEnnemiTuerPartie = value; }
        public int NbEnnemiTuerTotal { get => _nbEnnemiTuerTotal; set => _nbEnnemiTuerTotal = value; }
        public ItemTemporaire ItemTemporaire { get => _itemTemporaire; set => _itemTemporaire = value; }
        public List<ItemPermanent> LesItemsPermanents { get => _lesItemsPermanents; set => _lesItemsPermanents = value; }
        public Joueur(int argentDansPartie, int argentTotal, int nbEnnemiTuerPartie, int nbEnnemiTuerTotal)
        {
            DegatAttaque = 1;
            ArgentDansPartie = argentDansPartie;
            ArgentTotal = argentTotal;
            NbEnnemiTuerPartie = nbEnnemiTuerPartie;
            NbEnnemiTuerTotal = nbEnnemiTuerTotal;
            LesItemsPermanents = new List<ItemPermanent>();
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
