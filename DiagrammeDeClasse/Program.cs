using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiagrammeDeClasse
{
	class Program
	{
		static public void Main()
		{
			Fleur.ImporterDonnees("..\\..\\fleurs_db.csv");
			Proprietaire P = new Proprietaire("Boulanger", "Vincent", "123 rue des fleurs", "418-839-0101");
			Client c = new Client("a", "a", "a", "a", "C32");
			c.PasserCommande();
			P.GestionCommerce();

		}
	}
}