using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json.Net;
using System.IO;

public class Client : Utilisateur
{
	private string noClient;

	public string NoClient
	{
		get
		{
			return this.noClient;
		}
		set
		{
			this.noClient = value;
		}
	}

	public Client(string n, string p, string addr, string tel, string no) : base(n, p, addr, tel)
	{
		this.noClient = no;

		//Comparer s<il existe deja
		Console.WriteLine("Client créé");
		EnregistrerDonneesUtilisateur(this);
	}
	public void PasserCommande()
	{
		Console.WriteLine("Bonjour {0} {1}, choissions ensembles les fleurs de votre commande.", prenom, nom);
		Commande commande = new Commande();
		commande.SelectionDesArticles();
	}

	public override void EnregistrerDonneesUtilisateur(Utilisateur c)
	{
		string PathFile = "../../Client/Client.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		string ClientinJSON = File.ReadAllText(PathFile);
			ClientinJSON += JsonNet.Serialize(c);
		File.WriteAllText(PathFile, ClientinJSON);
	}

}
