using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whack_Cash
{
    /// <summary>
    /// Représente un item temporaire, contient son id, son type, son nom, ses dégats supplémentaires, son prix et le nombre de tours.
    /// </summary>
    internal class ItemTemporaire
    {
        private int _id;
        private string _type;
        private string _nom;
        private int _degatSup;
        private int _prix;
        private int _nbDeTours;

        public int DegatSup { get => _degatSup; set => _degatSup = value; }
        public int Prix { get => _prix; set => _prix = value; }
        public int NbDeTours { get => _nbDeTours; set => _nbDeTours = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Type { get => _type; set => _type = value; }
        public int Id { get => _id; set => _id = value; }
        /// <summary>
        /// Permet d'initialiser un item temporaire grâce à ses dégâts supplémentaire, son prix, le nombre de tours, son nom et son id.
        /// </summary>
        /// <param name="degatSup">Les dégâts supplémentaire de l'item</param>
        /// <param name="prix">Le prix de l'item</param>
        /// <param name="nbDeTours">Le nombre de tours que l'item reste actif.</param>
        /// <param name="nom">Le nom de l'item</param>
        /// <param name="id">L'id de l'item</param>
        public ItemTemporaire(int degatSup, int prix, int nbDeTours, string nom, int id)
        {
            DegatSup = degatSup;
            Prix = prix;
            NbDeTours = nbDeTours;
            Nom = nom;
            Type = "Temporaire";
            Id = id;
        }
        /// <summary>
        /// ToString pour afficher l'item temporaire
        /// </summary>
        /// <returns>Retourne la façon d'affiche</returns>
        public override string ToString()
        {
            return string.Format(Nom);
        }
    }
}
