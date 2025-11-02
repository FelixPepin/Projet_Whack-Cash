using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Whack_Cash
{
    /// <summary>
    /// Classe pour les commandes SQL.
    /// </summary>
    internal static class BD
    {
        private const string INFO_CONNEXION = "server=localhost;database=whack_cash;uid=root;pwd=";
        /// <summary>
        /// Permet de charger les items temporaire de la bd et retourne ceux-ci dans une liste d'item temporaire
        /// </summary>
        /// <returns>Liste d'item temporaire</returns>
        public static List<ItemTemporaire> ChargerItemTemporaire()
        {
            string chargerItemTempo = "select * FROM itemtemporaire";

            MySqlConnection laConnection = new MySqlConnection(INFO_CONNEXION);

            laConnection.Open();

            MySqlCommand laCommande = new MySqlCommand(chargerItemTempo, laConnection);

            MySqlDataReader leLecteur = laCommande.ExecuteReader();

            List<ItemTemporaire> lesItems = new List<ItemTemporaire>();

            while (leLecteur.Read())
            {
                ItemTemporaire item = new ItemTemporaire(leLecteur.GetInt32("degatsSup"), leLecteur.GetInt32("prix"), leLecteur.GetInt32("nbTour"), leLecteur.GetString("nom"), leLecteur.GetInt32("id"));
                lesItems.Add(item);
            }

            leLecteur.Close();

            laConnection.Close();

            return lesItems;
        }
        /// <summary>
        /// Permet de charger les items permanent de la bd et retourne ceux-ci dans une liste d'item permanent
        /// </summary>
        /// <returns>Liste d'item permanent</returns>
        public static List<ItemPermanent> ChargerItemPermanent()
        {
            string chargerItemPerm = "select * FROM itempermanent";

            MySqlConnection laConnection = new MySqlConnection(INFO_CONNEXION);

            laConnection.Open();

            MySqlCommand laCommande = new MySqlCommand(chargerItemPerm, laConnection);

            MySqlDataReader leLecteur = laCommande.ExecuteReader();

            List<ItemPermanent> lesItems = new List<ItemPermanent>();

            while (leLecteur.Read())
            {
                ItemPermanent item = new ItemPermanent(leLecteur.GetString("nom"), leLecteur.GetInt32("degatsSup"), leLecteur.GetInt32("prix"), leLecteur.GetInt32("id"));
                lesItems.Add(item);
            }

            leLecteur.Close();

            laConnection.Close();

            return lesItems;
        }

        public static List<Ennemi> ChargerEnnemi(string univers)
        {
            string chargerEnnemi = "select * FROM ennemie WHERE univers = @univers";

            MySqlConnection laConnection = new MySqlConnection(INFO_CONNEXION);

            laConnection.Open();

            MySqlCommand laCommande = new MySqlCommand(chargerEnnemi, laConnection);

            laCommande.Prepare();
            laCommande.Parameters.Add("@univers", MySqlDbType.String).Value = univers;


            MySqlDataReader leLecteur = laCommande.ExecuteReader();

            List<Ennemi> lesEnnemis = new List<Ennemi>();

            while (leLecteur.Read())
            {
                Ennemi item = new Ennemi(leLecteur.GetInt32("ptsVie"), leLecteur.GetString("nom"), leLecteur.GetString("sourceImage"), leLecteur.GetInt32("recompense"));
                lesEnnemis.Add(item);
            }

            leLecteur.Close();

            laConnection.Close();

            return lesEnnemis;
        }
    }
}
