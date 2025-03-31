namespace DiagrammeDeClasse
{
	class Program
	{
		static public void Main()
		{
			Fleur.ImporterDonnees("..\\..\\fleurs_db.csv");
			Proprietaire P = new Proprietaire("Boulanger", "Vincent");
			Client c = new Client("Jean", "Létourneau","C32");
			Fournisseur f = new Fournisseur("Gerard", "Boileau", "F32");
			Vendeur v = new Vendeur("Germaine", "Dumas", "V32");
			
			c.ActionClient();
			f.ActionFournisseur();
			v.GestionCommande();
			P.GestionCommerce();

		}
	}
}