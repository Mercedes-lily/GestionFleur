using System;
using System.Collections.Generic;

public class Vendeur : Utilisateur, IVendeur
{
	//Constructeur
	public Vendeur(string n, string p, string no) : base(n, p)
	{
		this.nom = n;
		this.prenom = p;
		this.noVendeur = no;
		vendeurs.Add(this);
		Console.WriteLine("Vendeur créé");
	}

	//Accesseur
	private string noVendeur;
	private static List<Vendeur> vendeurs = new List<Vendeur>();

	public string NoVendeur
	{
		get{return this.noVendeur;}
		set{this.noVendeur = value;}
	}

	public static List<Vendeur> GetVendeurs(){return vendeurs;}


	/********************************************--Fonctions--**************************************************/
	public void GestionCommande()
	{
		while (true)
		{
			Console.Clear();
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
			Console.WriteLine("Quelle commande voulez-vous facturer?");
			reponse = Console.ReadLine().Trim(' ');
			if (reponse == "N" || reponse == "n")
				return;
			foreach (Commande c in Commande.GetListCommande())
			{
				if (Convert.ToInt32(reponse) == c.No && c.FactureClient.PaiementEffectue == false)
				{
					if (c.Vendeur == null)
						c.Vendeur = this;
					c.ProcesserFactureClient();
					return;
				}
			}
			Console.WriteLine("Entrée Invalide");
		}
	}
}
