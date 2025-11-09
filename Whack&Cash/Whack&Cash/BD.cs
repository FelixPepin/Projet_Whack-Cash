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
        public static List<ItemTemporaire> ChargerLesItemTemporaire()
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
        public static ItemTemporaire ChargerItemTemporaire(int id)
        {
            string chargerItemTempo = "select * FROM itemtemporaire WHERE id = @id";

            MySqlConnection laConnection = new MySqlConnection(INFO_CONNEXION);

            laConnection.Open();

            MySqlCommand laCommande = new MySqlCommand(chargerItemTempo, laConnection);

            laCommande.Prepare();
            laCommande.Parameters.Add("@id", MySqlDbType.Int32).Value = id;


            MySqlDataReader leLecteur = laCommande.ExecuteReader();

            ItemTemporaire item = null;

            if (leLecteur.Read())
                item = new ItemTemporaire(leLecteur.GetInt32("degatsSup"), leLecteur.GetInt32("prix"), leLecteur.GetInt32("nbTour"), leLecteur.GetString("nom"), leLecteur.GetInt32("id"));

            leLecteur.Close();

            laConnection.Close();

            return item;
        }
        /// <summary>
        /// Permet de charger les items permanent de la bd et retourne ceux-ci dans une liste d'item permanent
        /// </summary>
        /// <returns>Liste d'item permanent</returns>
        public static List<ItemPermanent> ChargerLesItemPermanent()
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
        public static ItemPermanent ChargerItemPermanent(int id)
        {
            string chargerItemTempo = "select * FROM itempermanent WHERE id = @id";

            MySqlConnection laConnection = new MySqlConnection(INFO_CONNEXION);

            laConnection.Open();

            MySqlCommand laCommande = new MySqlCommand(chargerItemTempo, laConnection);

            laCommande.Prepare();
            laCommande.Parameters.Add("@id", MySqlDbType.Int32).Value = id;


            MySqlDataReader leLecteur = laCommande.ExecuteReader();

            ItemPermanent item = null;

            if (leLecteur.Read())
                item = new ItemPermanent(leLecteur.GetString("nom"), leLecteur.GetInt32("degatsSup"), leLecteur.GetInt32("prix"), leLecteur.GetInt32("id"));

            leLecteur.Close();

            laConnection.Close();

            return item;
        }
        public static List<Ennemi> ChargerLesEnnemi(string univers)
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
                Ennemi ennemi = new Ennemi(leLecteur.GetInt32("ptsVie"), leLecteur.GetString("nom"), leLecteur.GetString("sourceImage"), leLecteur.GetInt32("recompense"),
                    leLecteur.GetInt32("id"));
                lesEnnemis.Add(ennemi);
            }

            leLecteur.Close();

            laConnection.Close();

            return lesEnnemis;
        }

        public static Ennemi ChargerEnnemiEnCours(int id)
        {
            string chargerEnnemi = "select * FROM ennemie WHERE id = @id";

            MySqlConnection laConnection = new MySqlConnection(INFO_CONNEXION);

            laConnection.Open();

            MySqlCommand laCommande = new MySqlCommand(chargerEnnemi, laConnection);

            laCommande.Prepare();
            laCommande.Parameters.Add("@id", MySqlDbType.Int32).Value = id;


            MySqlDataReader leLecteur = laCommande.ExecuteReader();

            Ennemi ennemi = null;

            if (leLecteur.Read())
                ennemi = new Ennemi(leLecteur.GetInt32("ptsVie"), leLecteur.GetString("nom"), leLecteur.GetString("sourceImage"), leLecteur.GetInt32("recompense"),
                    leLecteur.GetInt32("id"));


                leLecteur.Close();

            laConnection.Close();

            return ennemi;
        }
        public static void CreerUtilisateur(string nom, string mdp)
        {
            string creerUtilisateur = "insert into utilisateurs (nom, mot_de_passe) values (@nom, @mdp)";

            MySqlConnection laConnection = new MySqlConnection(INFO_CONNEXION);

            laConnection.Open();

            MySqlCommand laCommande = new MySqlCommand(creerUtilisateur, laConnection);

            laCommande.Prepare();
            laCommande.Parameters.Add("@nom", MySqlDbType.String).Value = nom;
            laCommande.Parameters.Add("@mdp", MySqlDbType.String).Value = mdp;


            laCommande.ExecuteNonQuery();

            laConnection.Close();
        }
        public static void SauvegarderUtilisateur(Joueur leJoueur, Ennemi ennemiEnCours)
        {
            string sauvegarderUtilisateur = "update utilisateurs set ennemi_en_cours = @ennemi_en_cours, pv_ennemi_en_cours = @pv_ennemi_en_cours, " +
                " ennemis_totaux_tues = @ennemis_totaux_tues, argent_en_cours = @argent_en_cours, argent_total = @argent_total, " +
                "item_temporaire_id = @item_temporaire_id, items_permanents = @items_permanents WHERE nom = @nom";

            string itemPermanents = "";

            foreach (ItemPermanent item in leJoueur.LesItemsPermanents)
            {
                if (itemPermanents.Length > 0)
                    itemPermanents += ",";
                itemPermanents += item.Id;
            }

            MySqlConnection laConnection = new MySqlConnection(INFO_CONNEXION);

            laConnection.Open();

            MySqlCommand laCommande = new MySqlCommand(sauvegarderUtilisateur, laConnection);

            laCommande.Prepare();
            laCommande.Parameters.Add("@ennemi_en_cours", MySqlDbType.Int32).Value = ennemiEnCours.Id;
            laCommande.Parameters.Add("@pv_ennemi_en_cours", MySqlDbType.Int32).Value = ennemiEnCours.PtsVie;
            laCommande.Parameters.Add("@ennemis_totaux_tues", MySqlDbType.Int32).Value = leJoueur.NbEnnemiTuerTotal;
            laCommande.Parameters.Add("@argent_en_cours", MySqlDbType.Int32).Value = leJoueur.ArgentDansPartie;
            laCommande.Parameters.Add("@argent_total", MySqlDbType.Int32).Value = leJoueur.ArgentTotal;
            laCommande.Parameters.Add("@item_temporaire_id", MySqlDbType.Int32).Value = (object?)leJoueur.ItemTemporaire?.Id ?? DBNull.Value;
            laCommande.Parameters.Add("@items_permanents", MySqlDbType.String).Value = itemPermanents;
            laCommande.Parameters.Add("@nom", MySqlDbType.String).Value = leJoueur.Nom;

            laCommande.ExecuteNonQuery();

            laConnection.Close();
        }

        public static Joueur ChargerJoueur(string nom)
        {
            string chargerJoueur = "select * FROM utilisateurs WHERE nom = @nom";

            MySqlConnection laConnection = new MySqlConnection(INFO_CONNEXION);

            laConnection.Open();

            MySqlCommand laCommande = new MySqlCommand(chargerJoueur, laConnection);

            laCommande.Prepare();
            laCommande.Parameters.Add("@nom", MySqlDbType.String).Value = nom;


            MySqlDataReader leLecteur = laCommande.ExecuteReader();

            Joueur leJoueur = null;

            if (leLecteur.Read())
                leJoueur = new Joueur(leLecteur.GetInt32("ennemi_en_cours"), leLecteur.GetInt32("pv_ennemi_en_cours"), leLecteur.GetInt32("argent_en_cours") 
                    ,leLecteur.GetInt32("item_temporaire_id"), leLecteur.GetString("items_permanents"), leLecteur.GetString("univers"));

            leLecteur.Close();

            laConnection.Close();

            return leJoueur;
        }

        public static List<string> ChargerNomTousLesJoueurs()
        {
            string chargerJoueurs = "select nom FROM utilisateurs";

            MySqlConnection laConnection = new MySqlConnection(INFO_CONNEXION);

            laConnection.Open();

            MySqlCommand laCommande = new MySqlCommand(chargerJoueurs, laConnection);

            MySqlDataReader leLecteur = laCommande.ExecuteReader();

            List<string> lesNoms = new List<string>();

            while (leLecteur.Read())
            {
                string nom = leLecteur.GetString("nom");
                lesNoms.Add(nom);
            }

            leLecteur.Close();

            laConnection.Close();

            return lesNoms;
        }
    }
}
