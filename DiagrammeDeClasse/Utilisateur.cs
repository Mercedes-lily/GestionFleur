public abstract class Utilisateur
{
	protected string nom;
	protected string prenom;

	public string Nom
	{
		get
		{
			return this.nom;
		}
		set
		{
			this.nom = value;
		}
	}

	public string Prenom
	{
		get
		{
			return this.prenom;
		}
		set
		{
			this.prenom = value;
		}
	}

	public Utilisateur(string nom, string prenom)
	{
		this.nom = nom;
		this.prenom = prenom;

	}

	public abstract void EnregistrerDonneesUtilisateur(Utilisateur u);
}
