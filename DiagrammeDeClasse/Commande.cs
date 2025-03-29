using Json.Net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Design;

public class Commande
{
	private int no;
	private static int dernierNumero = 0;
	List<Article> ListeArticles = new List<Article>();
	private static List<Commande> commandes = new List<Commande>();
	private Vendeur vendeur = null;
	private Facture facture = null;

	//Constructeur de Commande
	public Commande()
	{
		this.no = dernierNumero + 1;
		dernierNumero = this.no;
	}

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
	public void SelectionTypesFleurs(IDictionary<string, int> FleurParser)
	{
		bool ChoixFleurEnCours = true;
		while (ChoixFleurEnCours)
		{
			List<Fleur> fleurs = Fleur.Fleurs;
			Console.WriteLine("Voici les fleurs disponibles pour la sélection");
			foreach (Fleur f in fleurs)
				f.Afficher();
			Console.WriteLine("Veuillez entrer le nom des fleurs que nous désirer ajouter à votre commande ainsi que le nombre d'exemplaire de chacune.");
			Console.WriteLine("Voici un exemple : Rose 5, Hortensia 2, Camélia 1");
			string reponse = Console.ReadLine();
			ParserChoixFleur(FleurParser, reponse);
			Console.WriteLine("Voici les fleurs que vous avez choisi");
			foreach (KeyValuePair<string, int> fleur in FleurParser)
				Console.WriteLine("Fleur: {0} Nombre: {1}", fleur.Key, fleur.Value);
			ChoixFleurEnCours = Continuer("Voulez-vous ajouter d'autres fleurs individuelles à votre commande? O/N");
		}
	}

	//Fonction qui permet au client de sélectionner les bouquets qu'il veut commander
	public void SelectionBouquets(IDictionary<string, int> BouquetParser)
	{
		//personnaliser ou non
	}

	//Fonction qui permet au client de s/lectionner les articles qu'il veut commander
	public void SelectionDesArticles()
	{
		IDictionary<string, int> FleurParser = new Dictionary<string, int>();
		IDictionary<string, int> BouquetParser = new Dictionary<string, int>();
		bool commandeEnCours = true;
		while (commandeEnCours)
		{
			Console.WriteLine("Selection des articles");
			Console.WriteLine("Voulez-vous ajouter des fleurs individuels ou des bouquets F/B");
			Console.WriteLine("Pour terminer l'ajout d'article, veuillez entrer N");
			string reponse = Console.ReadLine();
			if (reponse == "F" || reponse == "f")
				SelectionTypesFleurs(FleurParser);
			else if (reponse == "B" || reponse == "b")
			{
				bool ChoixBouquetEnCours = true;
				while (ChoixBouquetEnCours)
				{
					Console.WriteLine("Voici les bouquets disponibles pour la sélection");
					//Afficher les bouquet qui ont été enregistrées dans le fichier json
					Console.WriteLine("Veuillez entrer le numéro des bouquets que vous désirez ajouter à votre commande ainsi que le nombre d'exemplaire de chacun.");
					Console.WriteLine("Voici un exemple : B01 5, B13 2");
					reponse = Console.ReadLine();
					//Traitement de la réponse
					ChoixBouquetEnCours = Continuer("Voulez-vous ajouter d'autres bouquets à votre commande? O/N");
				}
			}
			else if(reponse == "N" || reponse == "n")
				commandeEnCours = false;
			else
				Console.WriteLine("Choix invalide");
		}
		EntrerProduitCommande(FleurParser);
	}

	public void IndiquerPreferance()
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

	public void AjoutFleurDictionnaire(IDictionary<string, int> FleurParser, string nom, string nombre)
	{
		List<Fleur> fleurs = Fleur.Fleurs;
		foreach (Fleur f in fleurs)
		{
			if (f.Nom == nom)
			{
				while (true)
				{
					if(FleurParser.ContainsKey(nom))
					{
						FleurParser[nom] += int.Parse(nombre);
						break;
					}
					else
					if (VerificationNombre(nombre) && int.Parse(nombre) > 0)
					{
						FleurParser.Add(nom, int.Parse(nombre));
						break;
					}
					else
					{
						Console.WriteLine("La quantité est invalide pour la fleur {0}", f.Nom);
						Console.WriteLine("Veuillez entrer une quantité valide");
						nombre = Console.ReadLine();
					}
				}
			}
		}
	}

	//Parser la réponse de l'utilisateur pour les fleurs
	public void ParserChoixFleur(IDictionary<string, int> FleurParser, string reponse)
	{
		
		List<Fleur> fleurs = Fleur.Fleurs;
		string[] reponsesplit = reponse.Split(',');
		foreach (string s in reponsesplit)
		{
			if(s == "")
				continue;
			string strTrim = s.TrimEnd(' ').TrimStart(' ');
			string[] sSplit = strTrim.Split(' ');
			if (sSplit.Length == 2)
				AjoutFleurDictionnaire(FleurParser, sSplit[0], sSplit[1]);
			else if (sSplit.Length == 1)
			{
				if (FleurParser.ContainsKey(sSplit[0]))
					continue;
				foreach (Fleur f in fleurs)
				{
					if (f.Nom == sSplit[0])
						FleurParser.Add(sSplit[0], -1);
				}
			}
			else
			{
				string nom = "";
				string nombre = "";
				for (int i = 0;  i < sSplit.Length; i ++)
				{
					if (sSplit[i] == "")
						continue;
					if(nom == "")
						nom = sSplit[i];
					else if (nombre == "")
						nombre = sSplit[i];
				}
				if(nom != "" && nombre != "")
					AjoutFleurDictionnaire(FleurParser, nom, nombre);
			}
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

	public void EntrerProduitCommande(IDictionary<string, int> FleurParser)
	{
		List<Fleur> fleurs = Fleur.Fleurs;
		(string, double, string, string) Caracteristiques = ("", 0, "", "");
		foreach (KeyValuePair<string, int> fleur in FleurParser)
		{
			int nombre = fleur.Value;
			foreach (Fleur f in fleurs)
			{
				if (f.Nom == fleur.Key)
					Caracteristiques = (f.Nom, f.PrixUnitaire, f.Couleur, f.Description);
			}
			while (nombre > 0)
			{
				ListeArticles.Add(new Fleur(Caracteristiques.Item1, Caracteristiques.Item2, Caracteristiques.Item3, Caracteristiques.Item4));
				nombre--;
			}
		}
	}

	public void AttribuerVendeur()
	{
		if (vendeur == null)
		{
			Console.WriteLine("Voici les commandes auquelles aucun vendeur n'a été attribué");

			Console.WriteLine("Veuiller entrer le numéro du vendeur que vous voulez attribuer à la commande parmis les vendeurs disponibles");
			List<Vendeur> vendeurs = Vendeur.getVendeurs();
		}

	}
}
