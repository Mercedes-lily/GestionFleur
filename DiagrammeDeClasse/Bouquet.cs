using Json.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;



public class Bouquet : Article
{
	private const int labeur = 2;
	private const int coutCarte = 1;
	static int dernierno = 0;
	private string noBouquet;
	private Carte carte = new Carte();
	//Contient la liste de toutes les fleurs dans le bouquet actuel
	private List<Fleur> fleurs = new List<Fleur>();
	//Contient la liste de tous les bouquets prédéfinis
	static private List<Bouquet> bouquetsPredefini = new List<Bouquet>();

	//Constructeur
	public Bouquet()
	{
		prixUnitaire = labeur + coutCarte;
		this.noBouquet = "B" + (dernierno + 1).ToString();
		dernierno++;
	}

	//Acesseur
	public  Carte CarteBouquet { get { return carte; } }
	private List<Fleur> Fleurs{ get { return fleurs; } }
	public string NoBouquet { get { return noBouquet; } }

	public static List<Bouquet> GetBouquetsPredefini() { return bouquetsPredefini; }

	/********************************************--Fonctions--**************************************************/

	//Parcourir la liste des fleurs et ajouter une copie de la fleur choisie dans le bouquet
	public void AjouterFleurs(Fleur fleur)
	{
		fleurs.Add(fleur);
		prixUnitaire += fleur.PrixUnitaire;
	}

	//Ajouter un message à la carte du bouquet
	public void AjouterMessageCarte()
	{
		Console.WriteLine("Quel message voulez-vous mettre sur la carte?");
		string message = Console.ReadLine();
		carte.Message = message;
	}

	//Afficher le bouquet
	public override void Afficher()
	{
		Console.Clear();
		Console.WriteLine("Numero du bouquet: {0}", noBouquet);
		Console.WriteLine("Message de la carte: {0}", carte.Message);
		foreach (Fleur f in fleurs)
		{
			f.AfficherNomCout();
		}
		Console.WriteLine("Cout total du bouquet: {0}$", PrixUnitaire);
	}

	public void CreerBouquetPersonnalise()
	{
		Console.Clear();
		bool ChoixFleurEnCours = true;
		while (ChoixFleurEnCours)
		{
			bool found = false;
			string reponse;
			while (!found)
			{
				Fleur.AfficherTout();
				Console.WriteLine("Veuillez entrer le nom de la fleur que vous voulez ajouter à votre bouquet");
				reponse = Console.ReadLine();
				foreach (Fleur f in Fleur.Fleurs)
				{
					if (reponse.Trim(' ') == f.Nom)
					{
						found = true;
						int nb = 0;
						while (nb <= 0)
						{
							Console.Write("Veuillez entrer la quantité : ");
							reponse = Console.ReadLine();
							for (int i = 0; i < reponse.Length; i++)
								if (reponse[i] < '0' || reponse[i] > '9')
									continue;
							nb = int.Parse(reponse);
						}
						while (nb > 0)
						{
							AjouterFleurs(f);
							nb--;
							f.Quantite--;
						}
						break;
					}
				}
				if (!found)
				{
					Console.Clear();
					Console.WriteLine("Nom de fleur invalide. Veuillez entrer un nom de la liste (Entrée pour continuer)");
					Console.ReadLine();
				}
			}
			Console.WriteLine("Voulez-vous ajouter d'autres fleurs à votre bouquet? O/N");
			reponse = Console.ReadLine(); ;
			while (reponse != "N" && reponse != "n" && reponse != "O" && reponse != "o")
			{
				Console.Clear();
				Console.WriteLine("Entrée invalide");
				Console.WriteLine("Voulez-vous ajouter d'autres fleurs à votre bouquet? O/N");
				reponse = Console.ReadLine();
			}
			if (reponse == "N" || reponse == "n")
			{
				ChoixFleurEnCours = false;
				if(fleurs.Count() != 0)
				{
					bouquetsPredefini.Add(this);
					AjouterMessageCarte();
				}
			}
			else if (reponse == "O" || reponse == "o")
				continue;
			else
				Console.WriteLine("Entrée invalide");
		}
		Afficher();
	}

	public static void AjouterBouquetListe(Bouquet bouquet)
	{
		bouquetsPredefini.Add(bouquet);
	}
}
