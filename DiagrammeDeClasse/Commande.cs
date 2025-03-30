using Json.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Commande
{
	private int no;
	private static int dernierNumero = 0;
	//Contient la liste des articles dnas la commande actuelles
	private List<Article> listeArticles = new List<Article>();
	//Contient la liste de toutes les commandes 
	private static List<Commande> commandes = new List<Commande>();
	private Vendeur vendeur = null;
	private Facture facture = new Facture();
	private Client client = null;
	private string preference;

	//Constructeur
	public Commande()
	{
		this.no = dernierNumero + 1;
		dernierNumero = this.no;
	}

	//Acesseur
	public int No { get { return no; } }
	public Vendeur Vendeur { get { return vendeur; } set { vendeur = value; } }
	public Client Client { get { return client; } }
	public Facture FactureClient { get { return facture; } }
	public List<Article> ListeArticles { get { return listeArticles; } }

	public string Preference { get { return preference; } }

	public static List<Commande> getListCommande(){return commandes;}


	/********************************************--Fonctions--**************************************************/

	//Fonction qui permet au client de sélectionner les fleurs qu'il désire commander
	public void SelectionTypesFleurs()
	{
		Console.Clear();
		bool ChoixFleurEnCours = true;
		List<Fleur> fleurs = Fleur.Fleurs;
		while (ChoixFleurEnCours)
		{
			bool entreeValide = false;
			Fleur.AfficherTout();
			Console.WriteLine("Veuillez entrer le nom de la fleur que vous voulez ajouter à votre commande. Entrez N pour annuler.");
			string reponse = Console.ReadLine();
			if (reponse == "n" || reponse == "N")
				return;
			foreach (Fleur f in fleurs)
			{
				if (reponse.Trim(' ') == f.Nom)
				{
					entreeValide = true;
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
						listeArticles.Add(f);
						nb--;
						f.Quantite--;
					}
					break;
				}
			}
			if (!entreeValide)
			{
				Console.Clear();
				Console.WriteLine("Veuillez n'entrer que le nom de la fleur et vérifier son orthographe (Entrée pour continuer)");
				Console.ReadLine();
			}
			else
			{
				ChoixFleurEnCours = Continuer("Voulez-vous ajouter d'autres fleurs individuelles à votre commande? O/N");
				Console.Clear();
			}
		}
	}

	//Fonction qui permet au client de sélectionner les bouquets qu'il désire commander
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
					listeArticles.Add(bouquet);
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
					listeArticles.Add(bouquet);
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
							listeArticles.Add(b);//enlever les lfeur de l<inventaire   attetion le message va etre changer s<il ajoute le mem bouquet
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

	//Fonction qui permet au client de sélectionner les articles qu'il désire commander
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
		if(listeArticles.Count() != 0)
		{
			IndiquerPreferance();
			commandes.Add(this);
			client = c;
		}

	}

	//Fonction qui permet au client d'indiquer ses préférence pour la commande
	public void IndiquerPreferance()
	{
		Console.WriteLine("Veuillez entrer tout commentaire qui vous semble pertinent pour la commande");
		preference = Console.ReadLine();
	}

	//Fonction qui permet d'annuler une commande et de la retirer des listes de commandes
	public void Annuler()
	{
		commandes.Remove (this);
		Console.WriteLine("Commande Annule");
	}

	//Fonction qui permet d'afficher les détails de la commande
	public void AfficherDetailsCommandes()
	{
		throw new NotImplementedException();
	}

	//Fonction qui vérifie si l'utilisateur veut continuer ou non
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

	//Fonction qui verifie si c'est bien un nombre
	public bool VerificationNombre(string str)
	{
		for (int i = 0; i < str.Length; i++)
			if(str[i] < '0' || str[i] > '9')
				return false;
		return true;
	}

	//Fonction qui permet d'attribuer un vendeur à une commande
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

	//Fonction qui permet de générer la facture du client
	public void GenererFactureClient()
	{
		facture = new Facture();
		if(Vendeur == null)
			facture.SuiviFacture(client.NoClient, "Propriétaire", no, listeArticles);
		else
			facture.SuiviFacture(client.NoClient, vendeur.NoVendeur, no, listeArticles);
	}
}
