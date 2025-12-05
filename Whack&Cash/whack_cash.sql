-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 05 déc. 2025 à 04:14
-- Version du serveur : 9.1.0
-- Version de PHP : 8.3.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `whack_cash`
--

-- --------------------------------------------------------

--
-- Structure de la table `ennemie`
--

DROP TABLE IF EXISTS `ennemie`;
CREATE TABLE IF NOT EXISTS `ennemie` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `ptsVie` int NOT NULL,
  `sourceImage` varchar(255) NOT NULL,
  `recompense` int NOT NULL,
  `univers` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `ennemie`
--

INSERT INTO `ennemie` (`id`, `nom`, `ptsVie`, `sourceImage`, `recompense`, `univers`) VALUES
(1, 'Maraudeur cuirassé', 300, 'Images/maraudeur.png', 100, 'Fantaisie'),
(2, 'Loup alpha des crêtes', 450, 'Images/loup_alpha.png', 150, 'Fantaisie'),
(3, 'Garde d’acier', 650, 'Images/garde_acier.png', 220, 'Fantaisie'),
(4, 'Chevalier noir', 850, 'Images/chevalier_noir.png', 300, 'Fantaisie'),
(5, 'Golem basaltique', 1100, 'Images/golem_basaltique.png', 380, 'Fantaisie'),
(6, 'Spectre vengeur', 1400, 'Images/spectre_vengeur.png', 480, 'Fantaisie'),
(7, 'Seigneur troll', 1750, 'Images/seigneur_troll.png', 600, 'Fantaisie'),
(8, 'Archimage renégat', 2100, 'Images/archimage_renegat.png', 720, 'Fantaisie'),
(9, 'Colosse mécanique', 2500, 'Images/colosse_meca.png', 860, 'Fantaisie'),
(10, 'Dragon ancestral', 3000, 'Images/dragon_ancestral.png', 1020, 'Fantaisie'),
(11, 'Marine', 300, 'Images/marine.png', 100, 'Anime'),
(12, 'Ninja', 450, 'Images/ninja.png', 150, 'Anime'),
(13, 'Killua', 650, 'Images/killua.png', 220, 'Anime'),
(14, 'Eren', 850, 'Images/eren.png', 300, 'Anime'),
(15, 'Korosensei', 1100, 'Images/korosensei.png', 380, 'Anime'),
(16, 'Ichigo', 1400, 'Images/ichigo.png', 480, 'Anime'),
(17, 'Goku', 1750, 'Images/goku.png', 600, 'Anime'),
(18, 'Naruto', 2100, 'Images/naruto.png', 720, 'Anime'),
(19, 'Gon', 2500, 'Images/gon.png', 860, 'Anime'),
(20, 'Luffy', 3000, 'Images/luffy.png', 1020, 'Anime'),
(21, 'Mario', 300, 'Images/mario.png', 100, 'Gaming'),
(22, 'Crash', 450, 'Images/crash.png', 150, 'Gaming'),
(23, 'Doom', 650, 'Images/doom.png', 220, 'Gaming'),
(24, 'Donkey Kong', 850, 'Images/dk.png', 300, 'Gaming'),
(25, 'Evoli', 1100, 'Images/evoli.png', 380, 'Gaming'),
(26, 'BJ', 1400, 'Images/bj.png', 480, 'Gaming'),
(27, 'Terrorist (CS2)', 1750, 'Images/terrorist_cs2.png', 600, 'Gaming'),
(28, 'CT', 2100, 'Images/ct.png', 720, 'Gaming'),
(29, 'Steve', 2500, 'Images/steve.png', 860, 'Gaming'),
(30, 'Kratos', 3000, 'Images/kratos.png', 1020, 'Gaming'),
(31, 'Clone', 300, 'Images/clone.png', 100, 'Star Wars'),
(32, 'Boba Fett', 450, 'Images/bobba.png', 150, 'Star Wars'),
(33, 'Starfighter', 650, 'Images/starfighter.png', 220, 'Star Wars'),
(34, 'Chewbacca', 850, 'Images/chewbacca.png', 300, 'Star Wars'),
(35, 'BB-8', 1100, 'Images/bb8.png', 380, 'Star Wars'),
(36, 'Kylo Ren', 1400, 'Images/kylo.png', 480, 'Star Wars'),
(37, 'Rey', 1750, 'Images/rey.png', 600, 'Star Wars'),
(38, 'Destroyer', 2100, 'Images/destroyer.png', 720, 'Star Wars'),
(39, 'Yoda', 2500, 'Images/yoda.png', 860, 'Star Wars'),
(40, 'Darth Vader', 3000, 'Images/darth.png', 1020, 'Star Wars');

-- --------------------------------------------------------

--
-- Structure de la table `itempermanent`
--

DROP TABLE IF EXISTS `itempermanent`;
CREATE TABLE IF NOT EXISTS `itempermanent` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `degatsSup` int NOT NULL,
  `prix` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `itempermanent`
--

INSERT INTO `itempermanent` (`id`, `nom`, `degatsSup`, `prix`) VALUES
(1, 'Gants d’initiation', 2, 90),
(2, 'Lame ébréchée', 5, 180),
(3, 'Poing renforcé', 10, 350),
(4, 'Gantelet en fer', 18, 600),
(5, 'Gantelet runique', 30, 950),
(6, 'Griffes de loup alpha', 45, 1500),
(7, 'Épée du justicier', 65, 2300),
(8, 'Frappe du titan', 100, 3400),
(9, 'Poing du colosse', 140, 4800),
(10, 'Marteau du dragon', 200, 7000);

-- --------------------------------------------------------

--
-- Structure de la table `itemtemporaire`
--

DROP TABLE IF EXISTS `itemtemporaire`;
CREATE TABLE IF NOT EXISTS `itemtemporaire` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `nom` varchar(100) NOT NULL,
  `degatsSup` int NOT NULL,
  `prix` int NOT NULL,
  `nbTour` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `itemtemporaire`
--

INSERT INTO `itemtemporaire` (`id`, `nom`, `degatsSup`, `prix`, `nbTour`) VALUES
(1, 'Potion d’énergie brute', 25, 350, 25),
(2, 'Breuvage de rage', 50, 700, 20),
(3, 'Élixir berserk', 90, 1200, 18),
(4, 'Totem de puissance', 140, 1900, 15),
(5, 'Rune de déchaînement', 200, 2700, 12),
(6, 'Injecteur d’adrénaline', 300, 3800, 10),
(7, 'Amulette draconique', 420, 5200, 8),
(8, 'Parchemin de fureur divine', 600, 7500, 6);

-- --------------------------------------------------------

--
-- Structure de la table `utilisateurs`
--

DROP TABLE IF EXISTS `utilisateurs`;
CREATE TABLE IF NOT EXISTS `utilisateurs` (
  `id` int UNSIGNED NOT NULL AUTO_INCREMENT,
  `ennemi_en_cours` int UNSIGNED NOT NULL DEFAULT '0',
  `pv_ennemi_en_cours` int UNSIGNED NOT NULL DEFAULT '0',
  `ennemis_totaux_tues` int UNSIGNED NOT NULL DEFAULT '0',
  `argent_en_cours` int UNSIGNED NOT NULL DEFAULT '0',
  `argent_total` int UNSIGNED NOT NULL DEFAULT '0',
  `item_temporaire_id` int UNSIGNED NOT NULL DEFAULT '0',
  `items_permanents` varchar(255) NOT NULL DEFAULT '',
  `nom` varchar(50) NOT NULL,
  `mot_de_passe` varchar(50) NOT NULL,
  `univers` varchar(50) NOT NULL DEFAULT '',
  `sauvegarde` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_utilisateur_itemtemp` (`item_temporaire_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `utilisateurs`
--

INSERT INTO `utilisateurs` (`id`, `ennemi_en_cours`, `pv_ennemi_en_cours`, `ennemis_totaux_tues`, `argent_en_cours`, `argent_total`, `item_temporaire_id`, `items_permanents`, `nom`, `mot_de_passe`, `univers`, `sauvegarde`) VALUES
(13, 32, 354, 59, 0, 400, 1, '1,2', 'Test', 'Test', 'Star Wars', 1),
(17, 35, 224, 0, 910, 0, 0, '1', 'MangeMaBiscotte', '1234', 'Star Wars', 1),
(18, 2, 404, 45, 100, 300, 0, '', 'Testeur', '12345678', 'Fantaisie', 1),
(19, 5, 873, 46, 260, 234, 1, '1', 'FuckMtl', 'Yessir', 'Fantaisie', 1),
(20, 23, 353, 2, 250, 250, 0, '1', 'Filou', 'Test', 'Gaming', 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
