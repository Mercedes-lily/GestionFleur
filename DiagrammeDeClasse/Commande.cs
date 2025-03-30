using Json.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Commande
{
	private int no;
	private static int dernierNumero = 0;
	private List<Article> ListeArticles = new List<Article>();
	private static List<Commande> commandes = new List<Commande>();
	private Vendeur vendeur = null;
	private Facture facture = new Facture();
	private Client client = null;



	//Constructeur de Commande
	public Commande()
	{
		this.no = dernierNumero + 1;
		dernierNumero = this.no;
	}

	public static List<Commande> getListCommande()
	{
		return commandes;
	}

	public Vendeur Vendeur { get { return vendeur; } set { vendeur = value; } }
	public int No { get { return no; }}

	public Facture FactureClient { get { return facture; } }


	//Fonction qui permet d<enregister la commande dans un json
	public void EnregistrerCommande()
	{
		string PathFile = "../../Commande/Commandes.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données de la commande {0}", no);
		string ClientJSON = JsonNet.Serialize(commandes);
		//Ajouter une separation avec des \n
		File.WriteAllText(PathFile, ClientJSON);
	}

	//Fonction qui permet au client de sélectionner les articles qu'il veut commander
	public void SelectionTypesFleurs()
	{
		bool ChoixFleurEnCours = true;
		List<Fleur> fleurs = Fleur.Fleurs;
		while (ChoixFleurEnCours)
		{
			Console.WriteLine("Veuillez entrer le nom de la fleur que vous voulez ajouter à votre commande");
			string reponse = Console.ReadLine();
			foreach (Fleur f in fleurs)
			{
				if (reponse.Trim(' ') == f.Nom)
				{
					int nb = 0;
					while (nb <= 0)
					{
						Console.Write("Veuiller entrer la quantité : ");
						reponse = Console.ReadLine();
						for (int i = 0; i < reponse.Length; i++)
							if (reponse[i] < '0' || reponse[i] > '9')
								continue;
						nb = int.Parse(reponse);
					}
					while (nb > 0)
					{
						ListeArticles.Add(f);
						nb--;
						f.Quantite--;
					}
					break;
				}
			}
			ChoixFleurEnCours = Continuer("Voulez-vous ajouter d'autres fleurs individuelles à votre commande? O/N");
		}
	}

	//Fonction qui permet au client de sélectionner les bouquets qu'il veut commander
	public void SelectionBouquets()
	{
		bool ChoixBouquetEnCours = true;
		string reponse;
		while (ChoixBouquetEnCours)
		{
			List<Bouquet> bouquets = Bouquet.GetBouquetsPredefini();

			if(bouquets.Count() == 0)
			{
				Console.WriteLine("Aucun bouquet prédéfinis n'est disponible pour le moment");
				Console.WriteLine("Voulez-vous créer un bouquet personnalisé? O/N");
				reponse  = Console.ReadLine();
				if (reponse == "O" || reponse == "o")
				{
					Bouquet bouquet = new Bouquet();
					bouquet.CreerBouquetPersonnalise();
					ListeArticles.Add(bouquet);
				}
				else if (reponse == "N" || reponse == "n")
					ChoixBouquetEnCours = false;
				else
					Console.WriteLine("Entrée invalide");
			}
			else
			{
				Console.WriteLine("Voici les bouquet disponibles pour la sélection");
				foreach (Bouquet b in bouquets)
					b.Afficher();
				Console.WriteLine("Veuillez entrer le numéro du bouquet que nous désirer ajouter ou P pour créer un bouquet personnalisé");
				Console.WriteLine("Entrée N pour quitter");
				reponse = Console.ReadLine();
				if (reponse == "P" || reponse == "p")
				{
					Bouquet bouquet = new Bouquet();
					bouquet.CreerBouquetPersonnalise();
					ListeArticles.Add(bouquet);
				}
				else if (reponse == "N" || reponse == "n")
					ChoixBouquetEnCours = false;
				else
				{
					bool trouver = false;
					foreach (Bouquet b in bouquets)
					{
						if (reponse.Trim(' ') == b.NoBouquet)
						{
							b.AjouterMessageCarte();
							ListeArticles.Add(b);//enlever les lfeur de l<inventaire   attetion le message va etre changer s<il ajoute le mem bouquet
							trouver = true;
							b.Afficher();
							break;
						}
					}
					if (!trouver)
						Console.WriteLine("Entrée invalide");
				}
			}
			ChoixBouquetEnCours = Continuer("Voulez-vous ajouter d'autres bouquets à votre commande? O/N");
		}
	}

	//Fonction qui permet au client de s/lectionner les articles qu'il veut commander
	public void SelectionDesArticles(Client c)
	{
		bool commandeEnCours = true;
		while (commandeEnCours)
		{
			Console.WriteLine("Selection des articles");
			Console.WriteLine("Voulez-vous ajouter des fleurs individuels ou des bouquets F/B");
			Console.WriteLine("Pour terminer l'ajout d'article, veuillez entrer N");
			string reponse = Console.ReadLine();
			if (reponse == "F" || reponse == "f")
				SelectionTypesFleurs();
			else if (reponse == "B" || reponse == "b")
				SelectionBouquets();
			else if(reponse == "N" || reponse == "n")
				commandeEnCours = false;
			else
				Console.WriteLine("Choix invalide");
		}
		Console.WriteLine("Voici les articles de la commande");
		if(ListeArticles.Count() != 0)
		{
			commandes.Add(this);
			client = c;
		}

	}

	public void IndiquerPreferance()
	{
		throw new NotImplementedException();
	}


	public void Annuler()
	{
		commandes.Remove (this);
		Console.WriteLine("Commande Annule");
	}

	public void Valider()
	{
		throw new NotImplementedException();
	}

	public void FaireLeSuivi()
	{
		throw new NotImplementedException();
	}

	public void AfficherDetailsCommandes()
	{
		throw new NotImplementedException();
	}

	public bool Continuer(string str)
	{
		Console.WriteLine(str);
		while (true)
		{
			string reponse = Console.ReadLine();
			if (reponse == "O" || reponse == "o")
				return (true);
			else if (reponse == "N" || reponse == "n")
				return (false);
			else
				Console.WriteLine("Veuillez choisir une option entre O ou N");
		}
	}

	//Verifie si c'est bien un nombre
	public bool VerificationNombre(string str)
	{
		for (int i = 0; i < str.Length; i++)
			if(str[i] < '0' || str[i] > '9')
				return false;
		return true;
	}
	public void AttribuerVendeur()
	{
		string reponse;
		if (Vendeur.getVendeurs().Count() == 0)
		{
			Console.WriteLine("Aucun vendeur n'est disponible pour l'attribution");
			return;
		}
		Console.WriteLine("Voici les vendeurs disponibles");
		foreach (Vendeur v in Vendeur.getVendeurs())
			Console.WriteLine(v.NoVendeur);
		while(true)
		{
			Console.WriteLine("Veuillez entrer le numero du vendeur pour faire l'attribution");
			reponse = Console.ReadLine().Trim(' ');
			foreach (Vendeur v in Vendeur.getVendeurs())
			{
				if (v.NoVendeur == reponse)
				{
					Vendeur = v;
					Console.WriteLine("Attribution effectuée");
					return;
				}
			}
			Console.WriteLine("Le numero entrer ne corespond pas a un vendeur");
		}
	}
	public void GenererFactureClient()
	{
		facture = new Facture();
		if(Vendeur == null)
			facture.SuiviFacture(client.NoClient, "Propriétaire", no, ListeArticles);
		else
			facture.SuiviFacture(client.NoClient, vendeur.NoVendeur, no, ListeArticles);
	}
}
