namespace DiagrammeDeClasse
{
	class Program
	{
		static public void Main()
		{
			Fleur.ImporterDonnees("..\\..\\fleurs_db.csv");
			Proprietaire P = new Proprietaire("Boulanger", "Vincent");
			Client c = new Client("a", "a","C32");
			c.PasserCommande();
			P.GestionCommerce();

		}
	}
}