using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Proprietaire : Utilisateur, IVendeur, IFournisseur
{
	public Proprietaire(string n, string p, string addr, string tel)
	{
		this.nom = n;
		this.prenom = p;
		this.adresse = addr;
		this.telephone = tel;
	}
	public void AjouterUtilisateur()
	{
		throw new NotImplementedException();
	}

	public void AttribuerVendeur()
	{
		throw new NotImplementedException();
	}
}
