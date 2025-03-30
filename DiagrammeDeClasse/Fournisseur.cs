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

	public override void EnregistrerDonneesUtilisateur(Utilisateur f)
	{
		string PathFile = "../../Fournisseur/Fournisseur.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des donn�es du Fournisseur");
		string ClientJSON = JsonNet.Serialize(fournisseurs);
		//Ajouter une separation avec des \n
		File.WriteAllText(PathFile, ClientJSON);
	}
	public void EffectuerApprovisionnement(Fleur fleur)
	{
		List<Fleur> fleurs = Fleur.Fleurs;
		foreach (Fleur f in fleurs)
		{
			if (f.Quantite < 10)
				f.Quantite = 10;
		}
		Console.WriteLine("Toutes les fleurs ont �t� r�approvisionn�es.");
	}
}
