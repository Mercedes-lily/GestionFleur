using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Article
{
	protected float prixUnitaire;

	public Article(float prixUnitaire)
	{
		this.prixUnitaire = prixUnitaire;
	}
}
