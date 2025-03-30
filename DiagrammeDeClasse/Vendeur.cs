using Json.Net;
using System;
using System.Collections.Generic;
using System.IO;

public class Vendeur : Utilisateur, IVendeur
{
	//Constructeur
	public Vendeur(string n, string p, string no) : base(n, p)
	{
		this.nom = n;
		this.prenom = p;
		this.noVendeur = no;
		vendeurs.Add(this);
		Console.WriteLine("Vendeur créé");
	}

	//Accesseur
	private string noVendeur;
	private static List<Vendeur> vendeurs = new List<Vendeur>();

	public string NoVendeur
	{
		get{return this.noVendeur;}
		set{this.noVendeur = value;}
	}

	public static List<Vendeur> getVendeurs(){return vendeurs;}


	/********************************************--Fonctions--**************************************************/
	public void GestionCommande()
	{
		throw new NotImplementedException();
	}
}
