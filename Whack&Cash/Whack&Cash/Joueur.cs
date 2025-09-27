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
        // private ItemTemporaire _itemTemporaire;
        // private List<ItemPermanent> _lesItemsPermanents;

        public int DegatAttaque { get => _degatAttaque; set => _degatAttaque = value; }
        // public ItemTemporaire ItemTemporaire { get => _itemTemporaire; set => _itemTemporaire = value; }
        // public List<ItemPermanent> LesItemsPermanents { get => _lesItemsPermanents; set => _lesItemsPermanents = value; }
        public Joueur()
        {
            DegatAttaque = 0;
        }

    }
}
