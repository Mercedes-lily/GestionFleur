using System.Collections.Generic;
using System;

public class Fournisseur : Utilisateur, IFournisseur
{
	private string noFournisseur;
	private static List<Fournisseur> fournisseurs = new List<Fournisseur>();

	public Fournisseur(string prenom, string nom, string noFournisseur) : base(nom, prenom)
	{
		this.noFournisseur = noFournisseur;
		fournisseurs.Add(this);
	}

	//Acesseur 
	public string NoFournisseur { get { return noFournisseur;} }
	public static List<Fournisseur> GetFournisseurs() { return fournisseurs ; }

	/********************************************--Fonctions--**************************************************/
	
	//Fonction qui permet d'effectuer l'approvisionnement de toutes le fleurs
	public void EffectuerApprovisionnement()
	{
		Fleur.ApprovisionnerTout();
	}

	public void ActionFournisseur()
	{
		Console.Clear();
		Console.WriteLine("Bonjour {0} {1}, vous venez nous approvisionner?", prenom, nom);
		Console.WriteLine("Effectuons l'approvisionnement!");
		EffectuerApprovisionnement();
	}
}
