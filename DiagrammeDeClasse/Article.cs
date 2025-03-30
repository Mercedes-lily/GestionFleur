public abstract class Article
{
	protected double prixUnitaire;

	//Constructeur par defaut pour permettre la lecture cohérente du fichier csv
	public Article()
	{

	}
	//Constructeur
	public Article(double prixUnitaire)
	{
		this.prixUnitaire = prixUnitaire;
	}

	//Acesseur
	public double PrixUnitaire
	{ get { return prixUnitaire; } }

	/********************************************--Fonctions--**************************************************/
	public abstract void Afficher();
}
