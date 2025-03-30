public abstract class Utilisateur
{
	protected string nom;
	protected string prenom;
	
	//Constructeur
	public Utilisateur(string nom, string prenom)
	{
		this.nom = nom;
		this.prenom = prenom;

	}

	//Acessseur
	public string Nom
	{
		get{return this.nom;}
		set{this.nom = value;}
	}
	public string Prenom
	{
		get{return this.prenom;}
		set{this.prenom = value;}
	}
}
