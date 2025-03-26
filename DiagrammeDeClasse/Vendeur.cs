using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Vendeur : Utilisateur, IVendeur
{
	private string noVendeur;
	public Vendeur(string n, string p, string addr, string tel, string no) : base(n, p, addr, tel)
	{
		this.nom = n;
		this.prenom = p;
		this.adresse = addr;
		this.telephone = tel;
		this.noVendeur = no;
		Console.WriteLine("Vendeur créé");
	}
	public void GestionCommande()
	{
		throw new NotImplementedException();
	}

	public void EffectuerTransaction()
	{
		throw new NotImplementedException();
	}

	public override void EnregistrerDonneesUtilisateur(Utilisateur v)
	{
		throw new NotImplementedException();
	}	
}
