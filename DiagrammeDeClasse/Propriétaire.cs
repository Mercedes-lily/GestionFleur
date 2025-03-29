using Json.Net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper.Configuration.Attributes;
using System.Security.Cryptography.X509Certificates;

public class Proprietaire : Utilisateur
{
	public Proprietaire(string n, string p, string addr, string tel) : base(n, p, addr, tel)
	{
		this.nom = n;
		this.prenom = p;
		this.adresse = addr;
		this.telephone = tel;
	}

	public Utilisateur AjouterUtilisateur()
	{
		Console.WriteLine("Veuillez entrer le nom de l'utilisateur");
		string nom = Console.ReadLine();
		Console.WriteLine("Veuillez entrer le prenom de l'utilisateur");
		string prenom = Console.ReadLine();
		Console.WriteLine("Veuillez entrer l'adresse de l'utilisateur");
		string adresse = Console.ReadLine();
		Console.WriteLine("Veuillez entrer le telephone de l'utilisateur");
		string telephone = Console.ReadLine();
		Console.WriteLine("Veuillez entrer le numero de l'utilisateur");
		string numero = Console.ReadLine();
		while (numero[0] != 'C' && numero[0] != 'F' && numero[0] != 'V')
		{
			Console.WriteLine("Le numero de l'utilisateur doit commencer par C pour un Client, F pour un Fournisseur ou V pour un Veudeur");
			Console.WriteLine("Veuillez entrer le numero de l'utilisateur");
			numero = Console.ReadLine().Trim(' ');
			;
		}
		if (numero[0] == 'C')
			return(new Client(nom, prenom, adresse, telephone, numero));
		else if (numero[0] == 'F')
			return(new Fournisseur(nom, prenom, adresse, telephone, numero));
		else if (numero[0] == 'V')
			return(new Vendeur(nom, prenom, adresse, telephone, numero));
		return null;
	}

	public override void EnregistrerDonneesUtilisateur(Utilisateur p)
	{
		string PathFile = "../../Proprietaire/Proprietaire.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données du Fournisseur");
		string ClientJSON = JsonNet.Serialize(this);
		//Ajouter une separation avec des \n
		File.WriteAllText(PathFile, ClientJSON);
	}

	public void GestionCommerce()
	{
		while (true)
		{
			Console.WriteLine("Bonjour {0} {1}, que voulez-vous faire?", prenom, nom);
			Console.WriteLine("1. Ajouter un utilisateur");
			Console.WriteLine("2. Attribuer les vendeurs au commandes");
			Console.WriteLine("3. Effectuer l'approvisionnement");
			Console.WriteLine("4. Effectuer une transaction");
			Console.WriteLine("5. Quitter");
			string reponse = Console.ReadLine();
			if (reponse.Trim(' ') == "1")
				AjouterUtilisateur();
			else if (reponse.Trim(' ') == "2")
				AttribuerVendeur();
			//else if (reponse.Trim(' ') == "3")
			//	Fleur.Approvisionner();
			//else if (reponse.Trim(' ') == "4")
			//	Commande.FacturerClient();
			else if (reponse.Trim(' ') == "5")
				return;
		}

	}

	//Attribuer les vendeurs aux commandes
	public void AttribuerVendeur()
	{
		string reponse;
		bool attribution = false;
		while (!attribution)
		{
			if (afficherCommandeNonComplete() == 0)
				return;
			Console.WriteLine("Veuillez entrer le numero de la commande pour faire l'attribution");
			Console.WriteLine("Entrée N pour quitter");
			reponse = Console.ReadLine().Trim(' ');
			if (reponse == "N" || reponse == "n")
				return;
			if (!(attribution = rechercheVendeur(reponse)))
				Console.WriteLine("Commande introuvable");
		}
	}

	//Affiche les commande non attribuer et retourne le nombre de commande non attribuer
	public int afficherCommandeNonComplete()
	{
		int attributionNonComplete = 0;
		Console.WriteLine("Voici les commandes qui n'ont pas de vendeur attribué");
		
		foreach (Commande c in Commande.getListCommande())
		{
			if (c.Vendeur == null)
			{
				attributionNonComplete++;
				Console.WriteLine(c.No);
			}
		}
		if (attributionNonComplete == 0)
			Console.WriteLine("Toutes les commandes ont un vendeur attribué");
		return attributionNonComplete;
	}

	//Recherche si le vendeur s/lectionne est une entr/e valide vendeur pour une commande
	public bool rechercheVendeur(string str)
	{
		foreach (Commande c in Commande.getListCommande())
		{
			if (c.No == int.Parse(str))
			{
				c.AttribuerVendeur();
				return true;
			}
		}
		return false;
	}
}
