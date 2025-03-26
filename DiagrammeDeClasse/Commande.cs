using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Commande
{
	private int No;
	int NombreArticles;
	static int DernierNumero = 0;
	List<Article> ListeArticles = new List<Article>();

	public Commande()
	{
		this.No = DernierNumero + 1;
		DernierNumero = this.No;
		this.NombreArticles = 0;

	}
	public void SelectionDesArticles()
	{
		bool commandeEnCours = true;
		Console.WriteLine("Selection des articles");
		Console.WriteLine("Voulez-vous ajouter des fleurs individuels ou des bouquets F/B");
		String reponse = Console.ReadLine();
		while (commandeEnCours)
		{
			if (reponse == "F" || reponse == "f")
			{
				bool ChoixFleurEnCours = true;
				while (ChoixFleurEnCours) {
					Console.WriteLine("Nous allons ajouter des fleurs à votre commandes");
					Console.WriteLine("Veuiller choisir une des options suivantes");
					Console.WriteLine("A-Afficher les fleurs par couleur");
					Console.WriteLine("B-Afficher les fleurs par prix ascendant");
					Console.WriteLine("C-Afficher les fleurs par prix descendant");
					reponse = Console.ReadLine();
					if (reponse == "A" || reponse == "a")
					{
						while (ChoixFleurEnCours)
						{
							Console.WriteLine("Voici les fleurs disponibles pour la sélection");
							//Afficher les fleurs par couleur
							Console.WriteLine("Veuillez entrer le nom des fleurs que nous désirer ajouter à votre commande ainsi que le nombre d'exemplaire de chacune.");
							Console.WriteLine("Voici un exemple : Rose 5, Hortensia 2, Camélia 1");
							reponse = Console.ReadLine();
							IDictionary<string, int> FleurParser = ParserChoixFleur(reponse);
							//Traitement de la réponse
							ChoixFleurEnCours = Continuer();
						}
					}
					else if (reponse == "B" || reponse == "b")
					{
						while (ChoixFleurEnCours)
						{
							Console.WriteLine("Voici les fleurs disponibles pour la sélection");
							//Afficher les fleurs par prix ascendant
							Console.WriteLine("Veuillez entrer le nom des fleurs que nous désirer ajouter à votre commande ainsi que le nombre d'exemplaire de chacune.");
							Console.WriteLine("Voici un exemple : Rose 5, Hortensia 2, Camélia 1");
							reponse = Console.ReadLine();
							IDictionary<string, int> FleurParser = ParserChoixFleur(reponse);
							//Traitement de la réponse
							ChoixFleurEnCours = Continuer();
						}
					}
					else if (reponse == "C" || reponse == "c")
					{
						while (ChoixFleurEnCours)
						{
							Console.WriteLine("Voici les fleurs disponibles pour la sélection");
							//Afficher les fleurs par prix descendant
							Console.WriteLine("Veuillez entrer le nom des fleurs que nous désirer ajouter à votre commande ainsi que le nombre d'exemplaire de chacune.");
							Console.WriteLine("Voici un exemple : Rose 5, Hortensia 2, Camélia 1");
							reponse = Console.ReadLine();
							IDictionary<string, int> FleurParser = ParserChoixFleur(reponse);
							//Traitement de la réponse
							ChoixFleurEnCours = Continuer();
						}
					}
					else
					{
						Console.WriteLine("Veuillez choisir une option entre A, B ou C");
					}
				}
			}
			else if (reponse == "B" || reponse == "b")
			{
				Console.WriteLine("Ajouter des bouquets");
			}
			else
			{
				Console.WriteLine("Choix invalide");
			}
		}
	}

	public void IndiquerPreferance()
	{
		throw new NotImplementedException();
	}

	public void EnregistrerCommande()
	{
		throw new NotImplementedException();
	}

	public void Annuler()
	{
		throw new NotImplementedException();
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
		Console.WriteLine("Les details");
	}

	public bool Continuer()
	{
		Console.WriteLine("Voulez-vous ajouter d'autres articles à votre commande? O/N");
		string reponse = Console.ReadLine();
		while (true)
		{
			if (reponse == "O" || reponse == "o")
				return (true);
			else if (reponse == "N" || reponse == "n")
				return (false);
			else
				Console.WriteLine("Veuillez choisir une option entre O ou N");
		}
	}

	public IDictionary<string, int> ParserChoixFleur(String reponse)
	{
		IDictionary<string, int> FleurParser = new Dictionary<string, int>();
		//Attention au cas ou il y a plusieurs virgules entre les groupes
		string[] reponsesplit = reponse.Split(',');
		foreach (string s in reponsesplit)
		{
			//Attention au cas ou il y a plusieurs espaces entre les mots
			s.TrimEnd(' ').TrimStart(' ');
			string[] sSplit = s.Split(' ');
			if(sSplit.Length == 2)
				FleurParser.Add(sSplit[0], int.Parse(sSplit[1]));
			else if (sSplit.Length == 1)
				FleurParser.Add(sSplit[0], int.Parse(sSplit[1]));
			else 
				continue;
		}
		return FleurParser;
	}
}
