using Json.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Net.NetworkInformation;

public class Fournisseur : Utilisateur, IFournisseur
{
	private string noFournisseur;
	private static List<Fournisseur> fournisseurs = new List<Fournisseur>();

	public Fournisseur(string nom, string prenom, string adresse, string telephone, string noFournisseur) : base(nom, prenom, adresse, telephone)
	{
		this.noFournisseur = noFournisseur;
		fournisseurs.Add(this);
	}

	public override void EnregistrerDonneesUtilisateur(Utilisateur f)
	{
		string PathFile = "../../Fournisseur/Fournisseur.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données du Fournisseur");
		string ClientJSON = JsonNet.Serialize(fournisseurs);
		//Ajouter une separation avec des \n
		File.WriteAllText(PathFile, ClientJSON);
	}
	public void EffectuerApprovisionnement(Fleur fleur)
	{
		List<Fleur> fleurs = Fleur.Fleurs;
		foreach (Fleur f in fleurs)
		{
			while (f.Quantite < 10)
				f.Quantite++;
		}
	}
}
