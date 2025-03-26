using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Client : Utilisateur
{
	private string noClient;

	public Client(string n, string p, string addr, string tel, string no) : base(n, p, addr, tel)
	{
		this.nom = n;
		this.prenom = p;
		this.adresse = addr;
		this.telephone = tel;
		this.noClient = no;

		Console.WriteLine("Client créé");
	}
	public void PasserCommande()
	{
		Console.WriteLine("Bonjour {0}, choissions ensembles les fleurs de votre commande.");
		Commande commande = new Commande();
		commande.SelectionDesArticles();
	}

	public override void EnregistrerDonneesUtilisateur()
	{
		throw new NotImplementedException();
	}

}
