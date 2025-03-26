using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Utilisateur
{
	protected string nom;
	protected string prenom;
	protected string adresse;
	protected string telephone;

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
	public string Telephone
	{
		get
		{
			return this.telephone;
		}
		set
		{
			this.telephone = value;
		}
	}

	public string Adresse
	{
		get
		{
			return this.adresse;
		}
		set
		{
			this.adresse = value;
		}
	}

	public Utilisateur(string nom, string prenom, string adresse, string telephone)
	{
		this.nom = nom;
		this.prenom = prenom;
		this.adresse = adresse;
		this.telephone = telephone;
	}

	public abstract void EnregistrerDonneesUtilisateur(Utilisateur u);
}
