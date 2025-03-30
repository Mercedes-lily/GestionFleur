using Json.Net;
using System;
using System.Collections.Generic;
using System.IO;


public class Facture
{
	private int no;
	private static int dernierNumeroFacture = 0;
	private double totalTransaction = 0;
	List<Facture> Factures = new List<Facture>();
	private string vendeur;
	private string client;
	private TypeDePaiement type;
	private int noCommande;
	bool paiementEffectue = false;

	public Facture()
	{
		this.no = dernierNumeroFacture + 1;
		dernierNumeroFacture++;
	}

	public bool PaiementEffectue { get; }

	public void EnregistrerFacture()
	{
		string PathFile = "../../Facture/Factures.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données du client");
		string ClientJSON = JsonNet.Serialize(Factures);
		//Ajouter une separation avec des \n
		File.WriteAllText(PathFile, ClientJSON);
	}

	public void FacturerClient()
	{
			paiementEffectue = true;
			Console.WriteLine("Fermeture de la facture");
	}

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

	public void SuiviFacture(string noClient, string noVendeur, int noCommande, List<Article> ArticlesCommandes)
	{
		this.vendeur = noVendeur;
		this.client = noClient;
		this.noCommande = noCommande;
		foreach (Article a in ArticlesCommandes)
			totalTransaction += a.PrixUnitaire;
		Factures.Add(this);
		while(true)
		{
			Console.WriteLine("Effectuer la transaction O/N");
			string reponse = Console.ReadLine().Trim(' ');
			if (reponse == "O" || reponse == "o")
			{
				FacturerClient();
				ImpressionFacture(ArticlesCommandes);
				return;
			}
			else if (reponse == "N" || reponse == "n")
				return;
			else
				Console.WriteLine("Veuillez entrer une réponse valide");
		}
	}

	public void ImpressionFacture(List<Article> ArticlesCommandes)
	{
		Console.WriteLine("Facture no: {0} pour la commande {1} vendu par :{2} au client {3}", no, noCommande, vendeur, client);
		Console.WriteLine("No de commande: {0}", noCommande);
		Console.WriteLine("Les articles factures sont");
		foreach (Article a in ArticlesCommandes)
		{
			a.Afficher();
		}
		Console.WriteLine("Total de la transaction: {0} payer par {1}", totalTransaction, type);
	}
}
