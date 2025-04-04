using Json.Net;
using System;
using System.Linq;
using System.IO;


public class Proprietaire : Utilisateur, IFournisseur, IVendeur
{
	public Proprietaire(string n, string p) : base(n, p) {}

	/********************************************--Fonctions--**************************************************/

	//Fonction qui regarde si l'utilisateur existe déja.
	public bool NouvelUtilisateur(string no)
	{
		if (no[0] == 'C')
		{
			foreach(Client c in Client.GetClients())
			{
				if (c.NoClient == no)
					return false;
			}
		}
		if (no[0] == 'V')
		{
			foreach (Vendeur c in Vendeur.GetVendeurs())
			{
				if (c.NoVendeur == no)
					return false;
			}
		if (no[0] == 'F')
			{
				foreach (Fournisseur c in Fournisseur.GetFournisseurs())
				{
					if (c.NoFournisseur == no)
						return false;
				}
			}
		}
		return true;
	}

	//Fonction qui permet de créer un utilisateur et de le retourner
	public Utilisateur AjouterUtilisateur()
	{
		Console.WriteLine("Veuillez entrer le nom de l'utilisateur");
		string nom = Console.ReadLine();
		while (String.IsNullOrEmpty(nom))
		{
			Console.WriteLine("Entrée invalide. Veuillez entrer le nom de l'utilisateur");
			nom = Console.ReadLine();
		}
		Console.WriteLine("Veuillez entrer le prénom de l'utilisateur");
		string prenom = Console.ReadLine();
		while (String.IsNullOrEmpty(prenom))
		{
			Console.WriteLine("Entrée invalide. Veuillez entrer le prénom de l'utilisateur");
			prenom = Console.ReadLine();
		}

		Console.WriteLine("Veuillez entrer le numéro de l'utilisateur");
		string numero = Console.ReadLine();
		while (String.IsNullOrEmpty(numero))
		{
			Console.WriteLine("Entrée invalide. Veuillez entrer le numéro de l'utilisateur");
			numero = Console.ReadLine();
		}
		while (numero[0] != 'C' && numero[0] != 'F' && numero[0] != 'V')
		{
			Console.WriteLine("Le numéro de l'utilisateur doit commencer par C pour un Client, F pour un Fournisseur ou V pour un Vendeur");
			Console.WriteLine("Veuillez entrer le numéro de l'utilisateur");
			numero = Console.ReadLine().Trim(' ');
			;
		}
		if(!NouvelUtilisateur(numero))
		{
			Console.WriteLine("Numéro d'utilisateur déjà attribué. Utilisateur non créé");
			return null;
		}
		if (numero[0] == 'C')
			return(new Client(nom, prenom, numero));
		else if (numero[0] == 'F')
			return(new Fournisseur(nom, prenom, numero));
		else if (numero[0] == 'V')
			return(new Vendeur(nom, prenom, numero));
		return null;
	}

	//Fonction qui permet de gérer le commerce Interface Utilisateur du Propriétaire
	public void GestionCommerce()
	{
		Console.Clear();
		while (true)
		{
			Console.WriteLine("Bonjour {0} {1}, que voulez-vous faire?", prenom, nom);
			Console.WriteLine("1. Ajouter un utilisateur");
			Console.WriteLine("2. Attribuer les vendeurs aux commandes");
			Console.WriteLine("3. Effectuer l'approvisionnement");
			Console.WriteLine("4. Effectuer le suivi des commandes");
			Console.WriteLine("5. Mettre à jour les enregistrements");
			Console.WriteLine("6. Quitter");
			string reponse = Console.ReadLine();
			if (reponse.Trim(' ') == "1")
			{
				Console.Clear();
				AjouterUtilisateur();
				Console.WriteLine("Appuyez sur Entrée pour retourner au menu");
				Console.ReadLine();
				Console.Clear();
			}
			else if (reponse.Trim(' ') == "2")
			{
				Console.Clear();
				AttribuerVendeur();
				Console.WriteLine("Appuyez sur Entrée pour retourner au menu");
				Console.ReadLine();
				Console.Clear();
			}
			else if (reponse.Trim(' ') == "3")
			{
				Console.Clear();
				EffectuerApprovisionnement();
			}
			else if (reponse.Trim(' ') == "4")
			{
				Console.Clear();
				GestionCommande();
			}
			else if (reponse.Trim(' ') == "5")
			{
				Console.Clear();
				EnregistrerDonneesUtilisateurs();
				EnregistrerDonnees();
				Console.WriteLine("Appuyez sur Entrée pour retourner au menu");
				Console.ReadLine();
				Console.Clear() ;
			}
			else if (reponse.Trim(' ') == "6")
				return;
			else
			{
				Console.WriteLine("Mauvaise Entrée");
				Console.WriteLine();
			}
		}
	}

	//Attribuer les vendeurs aux commandes
	public void AttribuerVendeur()
	{
		string reponse;
		bool attribution = false;
		while (!attribution)
		{
			if (AfficherCommandeNonComplete() == 0)
				return;
			Console.WriteLine("Veuillez entrer le numéro de la commande pour faire l'attribution");
			Console.WriteLine("Entrez N pour quitter");
			reponse = Console.ReadLine().Trim(' ');
			if (reponse == "N" || reponse == "n")
				return;
			if (!(attribution = RechercheVendeur(reponse)))
				Console.WriteLine("Commande introuvable");
		}
	}

	//Affiche les commande non attribuer et retourne le nombre de commande non attribuer
	public int AfficherCommandeNonComplete()
	{
		int attributionNonComplete = 0;
		Console.WriteLine("Voici les commandes qui n'ont pas de vendeur attribué");
		
		foreach (Commande c in Commande.GetListCommande())
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
	public bool RechercheVendeur(string str)
	{
		foreach (Commande c in Commande.GetListCommande())
		{
			if (c.No == int.Parse(str))
			{
				c.AttribuerVendeur();
				return true;
			}
		}
		return false;
	}

	//Fonction qui permet de gérer les commandes (Annulation et Facturation)
	public void GestionCommande()
	{
		if (Commande.GetListCommande().Count() == 0)
		{
			Console.WriteLine("Il n'y a aucune commande active");
			return;
		}
		while(true)
		{
			Console.WriteLine("Quelle action voulez-vous effectuer?");
			Console.WriteLine("1. Annuler une commande");
			Console.WriteLine("2. Facturer une commande");
			Console.WriteLine("Entrez N pour quitter");
			string reponse = Console.ReadLine().Trim(' ');
			if (reponse == "1")
				Annulation();
			else if (reponse == "2")
				Facturer();
			else if (reponse == "N" || reponse == "n")
				return;
			else
				Console.WriteLine("Entrée invalide");
		}
	}

	//Fonction qui permet d'annuler une commande
	public void Annulation()
	{
		string reponse;
		Console.WriteLine("Voici la liste des commandes");
		foreach (Commande c in Commande.GetListCommande())
			Console.WriteLine(c.No);
		while (true)
		{
			Console.WriteLine("Quelle commande voulez-vous annuler");
			reponse = Console.ReadLine().Trim(' ');
			if (reponse == "N" || reponse == "n")
				return;
			foreach (Commande c in Commande.GetListCommande())
			{
				if (Convert.ToInt32(reponse) == c.No)
				{
					c.Annuler();
					return;
				}
			}
			Console.WriteLine("Entrée Invalide");
		}
	}

	//Fonction qui permet de facturer une commande
	public void Facturer()
	{
		string reponse;
		int aFacturer = 0;
		Console.WriteLine("Voici la liste des commandes non Facturé");
		foreach (Commande c in Commande.GetListCommande())
		{
			if (c.FactureClient.PaiementEffectue == false)
			{
				Console.WriteLine(c.No);
				aFacturer++;
			}
		}
		if (aFacturer == 0)
		{
			Console.WriteLine("Il n'y a aucune commande à facturer");
			return;
		}
		while (true)
		{
			Console.WriteLine("Quelle commande voulez-vous facturer?");
			reponse = Console.ReadLine().Trim(' ');
			if (reponse == "N" || reponse == "n")
				return;
			foreach (Commande c in Commande.GetListCommande())
			{
				if (Convert.ToInt32(reponse) == c.No && c.FactureClient.PaiementEffectue == false)
				{
					c.ProcesserFactureClient();
					return;
				}
			}
			Console.WriteLine("Entrée Invalide");
		}
	}

	//Fonction qui permet l'enregistrement des données des utilisateurs
	public void EnregistrerDonneesUtilisateurs()
	{
		string PathFile = "../../Proprietaire/Proprietaire.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données du Propriétaire");
		string ClientJSON = JsonNet.Serialize(this);
		using (StreamWriter writer = new StreamWriter(PathFile))
		{
			writer.Write(ClientJSON);
		}

		PathFile = "../../Client/Client.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données des Clients");
		ClientJSON = JsonNet.Serialize(Client.GetClients());
		using (StreamWriter writer = new StreamWriter(PathFile))
		{
			writer.Write(ClientJSON);
		}

		PathFile = "../../Fournisseur/Fournisseurs.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données des Fournisseurs");
		ClientJSON = JsonNet.Serialize(Fournisseur.GetFournisseurs());
		using (StreamWriter writer = new StreamWriter(PathFile))
		{
			writer.Write(ClientJSON);
		}

		PathFile = "../../Vendeur/Vendeurs.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données des Vendeurs");
		ClientJSON = JsonNet.Serialize(Vendeur.GetVendeurs());
		using (StreamWriter writer = new StreamWriter(PathFile))
		{
			writer.Write(ClientJSON);
		}
	}

	//Fonction qui permet l'enregistrement des données
	public void EnregistrerDonnees()
	{
		string PathFile = "../../Commande/Commandes.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données des commmandes");
		string ClientJSON = JsonNet.Serialize(Commande.GetListCommande());
		using (StreamWriter writer = new StreamWriter(PathFile))
		{
			writer.Write(ClientJSON);
		}

		PathFile = "../../Facture/Factures.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données des Factures");
		ClientJSON = JsonNet.Serialize(Facture.GetFactures());
		using (StreamWriter writer = new StreamWriter(PathFile))
		{
			writer.Write(ClientJSON);
		}

		PathFile = "../../Bouquet/Bouquets.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données des Bouquets");
		ClientJSON = JsonNet.Serialize(Bouquet.GetBouquetsPredefini());
		using (StreamWriter writer = new StreamWriter(PathFile))
		{
			writer.Write(ClientJSON);
		}
	}

	//Fonction qui permet d'effectuer l'approvisionnement
	public void EffectuerApprovisionnement()
	{
		Fleur.ApprovisionnerTout();
	}
}
