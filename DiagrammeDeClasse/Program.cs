namespace DiagrammeDeClasse
{
	class Program
	{
		static public void Main()
		{
			Fleur.ImporterDonnees("..\\..\\fleurs_db.csv");
			Proprietaire P = new Proprietaire("Boulanger", "Vincent");
			Client c = new Client("a", "a","C32");
			Fournisseur f = new Fournisseur("b", "b", "F32");
			Vendeur v = new Vendeur("b", "b", "V32");
			//c.ActionClient();
			f.ActionFournisseur();
			//v.GestionCommande();


		}
	}
}