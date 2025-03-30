public abstract class Article
{
	protected double prixUnitaire;

	public double PrixUnitaire
	{
		get { return prixUnitaire; }
	}
	public Article()
	{

	}
	public Article(double prixUnitaire)
	{
		this.prixUnitaire = prixUnitaire;
	}

	public abstract void Afficher();
}
