using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Client : Utilisateur
{
	private string noClient;

	public Client(string n, string p, string addr, string tel, string no) : base(n, p, addr, tel)
	{
		this.nom = n;
		this.prenom = p;
		this.adresse = addr;
		this.telephone = tel;
		this.noClient = no;

		Console.WriteLine("Client créé");
	}
	public void PasserCommande()
	{
		throw new NotImplementedException();
	}

	public override void EnregistrerDonneesUtilisateur()
	{
		throw new NotImplementedException();
	}

}
