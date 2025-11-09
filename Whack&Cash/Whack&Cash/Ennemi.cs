using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Whack_Cash
{
    internal class Ennemi
    {
        private int _ptsVie;
        private string _nom;
        private ImageSource _cheminVersImageEnnemi;
        private int _recompense;
        private int id;

        public int PtsVie { get => _ptsVie; set => _ptsVie = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public ImageSource CheminVersImageEnnemi { get => _cheminVersImageEnnemi; set => _cheminVersImageEnnemi = value; }
        public int Recompense { get => _recompense; set => _recompense = value; }
        public int Id { get => id; set => id = value; }

        public Ennemi(int ptsVie, string nom, string cheminVersImageEnnemi, int recompense, int id)
        {
            PtsVie = ptsVie;
            Nom = nom;
            CheminVersImageEnnemi = new BitmapImage(new Uri(cheminVersImageEnnemi, UriKind.Relative));
            Recompense = recompense;
            Id = id;
        }
    }
}
