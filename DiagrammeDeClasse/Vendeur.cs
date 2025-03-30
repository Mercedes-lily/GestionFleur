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
		Console.WriteLine("Vendeur crée");
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

	public void GestionCommande()
	{
		throw new NotImplementedException();
	}

	public void EffectuerTransaction()
	{
		throw new NotImplementedException();
	}

	public override void EnregistrerDonneesUtilisateur(Utilisateur v)
	{
		string PathFile = "../../Vendeurs/Vendeurs.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des donn�es du client");
		string ClientJSON = JsonNet.Serialize(vendeurs);
		//Ajouter une separation avec des \n
		File.WriteAllText(PathFile, ClientJSON);
	}	
}
