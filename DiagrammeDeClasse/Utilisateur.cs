using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Utilisateur
{
	protected string nom;
	protected string prenom;
	protected string adresse;
	protected string telephone;

	public abstract void EnregistrerDonneesUtilisateur();
}
