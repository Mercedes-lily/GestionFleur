using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Proprietaire : Utilisateur, IVendeur, IFournisseur
{
	private List<Utilisateur> utilisateurs = new List<Utilisateur>();

	public Proprietaire(string n, string p, string addr, string tel) : base(n, p, addr, tel)
	{
		this.nom = n;
		this.prenom = p;
		this.adresse = addr;
		this.telephone = tel;
	}

	public Utilisateur AjouterUtilisateur(string nom, string prenom, string addresse, string telephone, string numero)
	{
		Utilisateur nouvelUtilisateur;
		if (numero[0] == 'C')
			nouvelUtilisateur = new Client(nom, prenom, addresse, telephone, numero);
		else if (numero[0] == 'F')
			nouvelUtilisateur = new Fournisseur(nom, prenom, addresse, telephone, numero);
		else if (numero[0] == 'V')
			nouvelUtilisateur = new Vendeur(nom, prenom, addresse, telephone, numero);
		else
			return null;
		utilisateurs.Add(nouvelUtilisateur);
		return nouvelUtilisateur;
	}

	public override void EnregistrerDonneesUtilisateur()
	{
		throw new NotImplementedException();
	}
	

	public void AttribuerVendeur()
	{
		throw new NotImplementedException();
	}

	public void GestionCommande()
	{
		throw new NotImplementedException();
	}

	public void EffectuerTransaction()
	{
		throw new NotImplementedException();
	}

	public void EffectuerApprovisionnement()
	{
		throw new NotImplementedException();
	}
}
