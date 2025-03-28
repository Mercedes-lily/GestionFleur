using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiagrammeDeClasse
{
	class Program
	{
		static public void Main()
		{
			Proprietaire P = new Proprietaire("Jean", "Dupont", "123 rue des fleurs", "514-123-4567");
			P.AjouterUtilisateur("Jeanne", "Duponte", "456 rue des fleurs", "514-123-4567", "C123");
			P.AjouterUtilisateur("Jeanne", "Duponte", "456 rue des fleurs", "514-123-4567", "F123");
			P.AjouterUtilisateur("Jeanny", "Dupond", "789 rue des fleurs", "514-123-4567", "V123");
			Fleur.ImporterDonnees("..\\..\\fleurs_db.csv");
			Bouquet bouquet = new Bouquet();
			//Commande commande = new Commande();
			//commande.SelectionDesArticles();
		}
	}
}