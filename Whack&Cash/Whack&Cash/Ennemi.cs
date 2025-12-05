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
    /// <summary>
    /// Représente un ennemi dans le jeu. Contient ses points de vie, son nom, 
    /// le chemin vers son image, la récompense qu'il donne à sa mort et son id.
    /// </summary>
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

        /// <summary>
        /// Initialise un nouveau ennemi.
        /// </summary>
        /// <param name="ptsVie">Le nombre de points de vie de l'ennemi</param>
        /// <param name="nom">Le nom de l'ennemi</param>
        /// <param name="cheminVersImageEnnemi">Le chemin vers l'image de l'ennemi</param>
        /// <param name="recompense">La récompense en argent de l'ennemi.</param>
        /// <param name="id">L'id de l'ennemi.</param>
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
