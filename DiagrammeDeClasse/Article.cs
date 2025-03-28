using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Article
{
	protected double prixUnitaire;

	public double PrixUnitaire
	{
		get { return prixUnitaire; }
	}
	public Article()
	{

	}
	public Article(double prixUnitaire)
	{
		this.prixUnitaire = prixUnitaire;
	}
}
