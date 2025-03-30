using Json.Net;
using System;
using System.Collections.Generic;
using System.IO;

public class Fournisseur : Utilisateur, IFournisseur
{
	private string noFournisseur;
	private static List<Fournisseur> fournisseurs = new List<Fournisseur>();

	public Fournisseur(string nom, string prenom, string noFournisseur) : base(nom, prenom)
	{
		this.noFournisseur = noFournisseur;
		fournisseurs.Add(this);
	}

	//Acesseur 
	public string NoFournisseur { get { return noFournisseur;} }
	public static List<Fournisseur> GetFournisseurs() { return fournisseurs ; }

	public void EffectuerApprovisionnement(Fleur fleur)
	{
		Fleur.ApprovisionnerTout();
	}
}
