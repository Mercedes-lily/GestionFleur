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
			P.AjouterUtilisateur();
			Client client = new Client("Jean", "Dupont", "123 rue des fleurs", "514-123-4567", "C123");
			Fleur.ImporterDonnees("..\\..\\fleurs_db.csv");
			client.PasserCommande();
			//Bouquet bouquet = new Bouquet();
			//Commande commande = new Commande();
			//commande.SelectionDesArticles();
		}
	}
}