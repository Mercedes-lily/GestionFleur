using System;
using System.Collections.Generic;
using Json.Net;
using System.IO;



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

	public Client(string n, string p, string no) : base(n, p)
	{
		this.noClient = no;

		//Comparer s'il existe deja
		Console.WriteLine("Client créé");
		Clients.Add(this);
	}
	public void PasserCommande()
	{
		Console.WriteLine("Bonjour {0} {1}, choissions ensembles les fleurs de votre commande.", prenom, nom);
		Commande commande = new Commande();
		commande.SelectionDesArticles(this);
		if (commande.ListeArticles.Count > 0)
			commande.FactureClient.ChoisirModePaiement();
	}
}
