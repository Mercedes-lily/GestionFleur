using Json.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

public class Bouquet : Article
{
	private const int labeur = 2;
	private const int coutCarte = 1;
	private string noBouquet;
	private Carte carte = new Carte();
	private List<Fleur> fleurs = new List<Fleur>();
	static private List<Bouquet> bouquetsPredefini = new List<Bouquet>();

	public Bouquet(string noBouquet)
	{
		prixUnitaire = labeur + coutCarte;
		this.noBouquet = noBouquet;
	}
	//Parcourir la liste des fleurs et ajouter une copie de la fleur choisie dans le bouquet
	public void AjouterFleurs(Fleur fleur)
	{
		fleurs.Add(fleur);
		prixUnitaire += fleur.PrixUnitaire;
	}
	public void EnregistrerModele()
	{
		string PathFile = "../../Modele/Modeles.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données du modele de bouquet");
		string BouquetJSON = JsonNet.Serialize(bouquetsPredefini);
		//Ajouter une separation avec des \n
		File.WriteAllText(PathFile, BouquetJSON);
	}
	public void AjouterMessageCarte()
	{
		Console.WriteLine("Quel message voulez-vous mettre sur la carte?");
		string message = Console.ReadLine();
		carte.Message = message;
	}

	public void Afficher()
	{
		Console.WriteLine("Numero du bouquet: {0}", noBouquet);
		Console.WriteLine("Message de la carte: {0}", carte.Message);
		foreach (Fleur f in fleurs)
		{
			f.Afficher();
		}
		Console.WriteLine("Cout total du bouquet: {0}", PrixUnitaire);
	}
}
