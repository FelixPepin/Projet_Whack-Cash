using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whack_Cash
{
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

        public ItemPermanent(string nom, int degatSup, int prix, int id)
        {
            Nom = nom;
            DegatSup = degatSup;
            Prix = prix;
            Type = "Permanent";
            Id = id;
        }

        public override string ToString()
        {
            return $"{Nom,-15} {DegatSup,-10} {"-",-10} {Prix,-10} {Type,-10}";
        }
    }
}
