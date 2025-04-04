using System;
using System.Collections.Generic;

public class Client : Utilisateur
{
	private string noClient;
	//Contient la liste de tous les clients
	static List<Client> Clients = new List<Client>();

	//Acesseur NoClient
	public string NoClient
	{
		get{return this.noClient;}
		set{this.noClient = value;}
	}

	public static List<Client> GetClients() { return Clients; }

	//Constructeur
	public Client(string n, string p, string no) : base(n, p)
	{
		this.noClient = no;

		//Comparer s'il existe deja
		Console.WriteLine("Client créé");
		Clients.Add(this);
	}

	/********************************************--Fonctions--**************************************************/

	//Fonction qui permet au client de passer une commande
	public void PasserCommande()
	{
		Console.Clear();
		Console.WriteLine("Choisissons ensembles les articles de votre commande, {0} {1}.", prenom, nom);
		Console.WriteLine();
		Commande commande = new Commande();
		commande.SelectionDesArticles(this);
		if (commande.ListeArticles.Count > 0)
			commande.FactureClient.ChoisirModePaiement();
	}

	public void ActionClient()
	{
		Console.Clear();
		Console.WriteLine("Bonjour {0} {1}, que voulez-vous faire?", prenom, nom);
		Console.WriteLine("Effectuons la commande");
		while (true)
		{
			PasserCommande();
			Console.WriteLine("Voulez-vous effectuer une autre commande? O/N");
			while (true)
			{
				string reponse = Console.ReadLine().Trim(' ');
				if (reponse == "O" || reponse == "o")
					break;
				else if (reponse == "N" || reponse == "n")
					return;
				else
					Console.WriteLine("Veuillez entrer une réponse valide");
			}
		}
	}
}
