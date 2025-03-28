using Json.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Vendeur : Utilisateur, IVendeur
{
	private string noVendeur;
	private static List<Vendeur> vendeurs = new List<Vendeur>();
	public Vendeur(string n, string p, string addr, string tel, string no) : base(n, p, addr, tel)
	{
		this.nom = n;
		this.prenom = p;
		this.adresse = addr;
		this.telephone = tel;
		this.noVendeur = no;
		Console.WriteLine("Vendeur créé");
	}
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
		Console.WriteLine("Enregistrement des données du client");
		string ClientJSON = JsonNet.Serialize(vendeurs);
		//Ajouter une separation avec des \n
		File.WriteAllText(PathFile, ClientJSON);
	}	
}
