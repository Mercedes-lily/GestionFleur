using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

public class Bouquet : Article
{
	const int labeur = 2;
	const int coutCarte = 1;
	Carte carte = new Carte();
	List<Fleur> fleurs = new List<Fleur>();

	public Bouquet()
	{
		prixUnitaire = labeur + coutCarte;
		Console.WriteLine("Veuillez entrer un message pour la carte puis appuyer sur Entrée. Pour le message par défaut, laisser vider et appuyer sur Entrée.");
		this.carte.InscrireMessage();
	}
	public void CalculerPrix()
	{
		foreach (var fleur in fleurs)
		{
			prixUnitaire += fleur.PrixUnitaire;
		}
	}
	//Parcourir la liste des fleurs et ajouter une copie de la fleur choisie dans le bouquet
	public void AjouterFleurs()
	{
		throw new NotImplementedException();
	}

	public void EnregistrerModele()
	{
		throw new NotImplementedException();
	}
}
