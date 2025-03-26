using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Fournisseur : Utilisateur, IFournisseur
{
	private string noFournisseur;

	public Fournisseur(string nom, string prenom, string adresse, string telephone, string noFournisseur) : base(nom, prenom, adresse, telephone)
	{
		this.noFournisseur = noFournisseur;
	}

	public override void EnregistrerDonneesUtilisateur()
	{
		throw new NotImplementedException();
	}
	public void EffectuerApprovisionnement()
	{
		throw new NotImplementedException();
	}
}
