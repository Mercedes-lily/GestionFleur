using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bouquet : Article
{
	const int labeur = 2;
	const int coutCarte = 1;
	Carte carte = new Carte();

	public Bouquet(float prixUnitaire) : base(prixUnitaire)
	{

	}
	public void CalculerPrix()
	{
		throw new NotImplementedException();
	}

	public void AjouterFleurs()
	{
		throw new NotImplementedException();
	}

	public void EnregistrerModèle()
	{
		throw new NotImplementedException();
	}
}
