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

	public Utilisateur(string nom, string prenom, string adresse, string telephone)
	{
		this.nom = nom;
		this.prenom = prenom;
		this.adresse = adresse;
		this.telephone = telephone;
	}

	public abstract void EnregistrerDonneesUtilisateur();
}
