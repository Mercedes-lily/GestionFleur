using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Fleur : Article
{
	private int code;
	private string nom;
	private string couleur;
	private string description;

	public Fleur(float prixUnitaire, int code, string nom, string couleur, string description) : base(prixUnitaire)
	{
		this.code = code;
		this.nom = nom;
		this.couleur = couleur;
		this.description = description;
	}

	public void ImporterDonnées()
	{
		throw new NotImplementedException();
	}
}
