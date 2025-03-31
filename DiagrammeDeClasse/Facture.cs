using System;
using System.Collections.Generic;


public class Facture
{
	private int no;
	private static int dernierNumeroFacture = 0;
	private double totalTransaction = 0;
	static List<Facture> factures = new List<Facture>();
	private string vendeur;
	private string client;
	private TypeDePaiement type;
	private int noCommande;
	bool paiementEffectue = false;
	
	//Constructeur
	public Facture()
	{
		this.no = dernierNumeroFacture + 1;
		dernierNumeroFacture++;
	}

	//Acesseur
	public int No { get { return no; } }
	public bool PaiementEffectue { get { return paiementEffectue; } }
	public double TotalTransaction { get { return totalTransaction; } }
	public string Vendeur { get { return vendeur; } }
	public string Client{ get { return client; } }
	public int NoCommande { get { return noCommande; } }
	public TypeDePaiement Type { get { return type; } }
	public static List<Facture> GetFactures(){ return factures; }

	/********************************************--Fonctions--**************************************************/

	//Fonction qui permet de fermer la facture une fois le paiement effectué
	public void FacturerClient()
	{
			paiementEffectue = true;
			Console.WriteLine("Fermeture de la facture");
	}

	//Fonction qui permet au client de choisir le mode de paiement par l'utilisateur
	public void ChoisirModePaiement()
	{
		Console.WriteLine("Veuillez choisir le mode de paiement qui sera utilisé");
		Console.WriteLine("1. Carte de crédit");
		Console.WriteLine("2. Carte de débit");
		Console.WriteLine("3. Argent Comptant");
		while (true)
		{
			string reponse = Console.ReadLine().Trim(' ');
			if (reponse == "1")
			{
				type = TypeDePaiement.Credit;
				return;
			}
			else if (reponse == "2")
			{
				type = TypeDePaiement.Debit;
				return;
			}
			else if (reponse == "3")
			{
				type = TypeDePaiement.Comptant;
				return;
			}
			else
				Console.WriteLine("Veuillez entrer un choix valide parmi 1, 2 ou 3");
		}
	}

	//Fonction qui permet de suivre la facture et de facturer le client
	public void SuiviFacture(string noClient, string noVendeur, int noCommande, List<Article> ArticlesCommandes)
	{
		this.vendeur = noVendeur;
		this.client = noClient;
		this.noCommande = noCommande;
		foreach (Article a in ArticlesCommandes)
			totalTransaction += a.PrixUnitaire;
		factures.Add(this);
		while(true)
		{
			Console.WriteLine("Effectuer la transaction O/N");
			string reponse = Console.ReadLine().Trim(' ');
			if (reponse == "O" || reponse == "o")
			{
				FacturerClient();
				ImpressionFacture(ArticlesCommandes);
				Console.Write(" (Entrée pour continuer)");
				Console.ReadLine();
				return;
			}
			else if (reponse == "N" || reponse == "n")
				return;
			else
				Console.WriteLine("Veuillez entrer une réponse valide");
		}
	}

	//Fonction qui permet d'imprimer la facture et de l'afficher
	public void ImpressionFacture(List<Article> ArticlesCommandes)
	{
		Console.WriteLine("Facture no: {0} pour la commande {1} vendu par :{2} au client {3}", dernierNumeroFacture, noCommande, vendeur, client);
		Console.WriteLine("No de commande: {0}", noCommande);
		Console.WriteLine("Les articles facturés sont:");
		Console.WriteLine();
		foreach (Article a in ArticlesCommandes)
		{
			if (a is Fleur)
				a.AfficherNomCout();
			a.Afficher();
			Console.WriteLine();
		}
		Console.WriteLine("Total de la transaction: {0}$ payé par {1}", totalTransaction, type);
	}
}
