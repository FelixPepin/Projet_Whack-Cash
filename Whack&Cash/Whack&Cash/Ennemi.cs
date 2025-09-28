using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Whack_Cash
{
    internal class Ennemi
    {
        private int _ptsVie;
        private bool _vivant;
        private string _nom;
        private ImageSource _cheminVersImageEnnemi;

        public int PtsVie { get => _ptsVie; set => _ptsVie = value; }
        public bool Vivant { get => _vivant; set => _vivant = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public ImageSource CheminVersImageEnnemi { get => _cheminVersImageEnnemi; set => _cheminVersImageEnnemi = value; }

        public Ennemi(int ptsVie, string nom, ImageSource cheminVersImageEnnemi)
        {
            PtsVie = ptsVie;
            Vivant = true;
            Nom = nom;
            CheminVersImageEnnemi = cheminVersImageEnnemi;
        }
    }
}
