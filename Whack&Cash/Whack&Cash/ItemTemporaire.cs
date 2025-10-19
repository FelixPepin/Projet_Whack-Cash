using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whack_Cash
{
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

        public ItemTemporaire(int degatSup, int prix, int nbDeTours, string nom, int id)
        {
            DegatSup = degatSup;
            Prix = prix;
            NbDeTours = nbDeTours;
            Nom = nom;
            Type = "Temporaire";
            Id = id;
        }

        public override string ToString()
        {
            return $"{Nom,-15} {DegatSup,-10} {NbDeTours,-10} {Prix,-10} {Type,-10}";
        }
    }
}
