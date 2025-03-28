using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFleur.DiagrammeDeClasse
{
	internal class Boutique
	{
		string nom;
		private List<Fleur> Fleurs;
		private List<Bouquet> Bouquets;
		private List<Commande> Commandes;

		private List<Client> Clients;
		private List<Vendeur> Vendeurs;
		private List<Fournisseur> Fournisseurs;
		private Proprietaire Proprietaire;

		public Boutique(string nom)
		{
			this.nom = nom;
			this.Proprietaire = new Proprietaire("Vincent", "Boulanger", "123 rue des fleurs", "514-123-4567");
		}

	}
}
