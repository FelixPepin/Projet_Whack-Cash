using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whack_Cash
{
    /// <summary>
    /// Représente un item permanent, contient son nom, ses dégâts supplémentaires, son type, son prix et son id.
    /// </summary>
    internal class ItemPermanent
    {
        private int _id;
        private string _type;
        private string _nom;
        private int _degatSup;
        private int _prix;

        public string Nom { get => _nom; set => _nom = value; }
        public int DegatSup { get => _degatSup; set => _degatSup = value; }
        public int Prix { get => _prix; set => _prix = value; }
        public string Type { get => _type; set => _type = value; }
        public int Id { get => _id; set => _id = value; }

        /// <summary>
        /// Initialise un nouvelle item permanent grâce au nom, ses dégâts supplémentaires, son prix et son id.
        /// </summary>
        /// <param name="nom">Nom de l'item</param>
        /// <param name="degatSup">Les dégâts supplémentaires de l'item</param>
        /// <param name="prix">Le prix de l'item</param>
        /// <param name="id">L'id de l'item</param>
        public ItemPermanent(string nom, int degatSup, int prix, int id)
        {
            Nom = nom;
            DegatSup = degatSup;
            Prix = prix;
            Type = "Permanent";
            Id = id;
        }
        /// <summary>
        /// ToString pour afficher les item permanent.
        /// </summary>
        /// <returns>Retourne la façon d'écrire l'item permanent.</returns>
        public override string ToString()
        {
            return string.Format(Nom);
        }
    }
}
