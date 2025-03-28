using Json.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class Facture
{
	private int no;
	static int dernierNumeroFacture = 0;
	int totalTransaction;
	List<Facture> Factures = new List<Facture>();

	Facture()
	{
		this.no = dernierNumeroFacture + 1;
		dernierNumeroFacture++;

	}

	public void EnregistrerFacture()
	{
		string PathFile = "../../Facture/Factures.json";
		if (!File.Exists(PathFile))
			File.Create(PathFile);
		Console.WriteLine("Enregistrement des données du client");
		string ClientJSON = JsonNet.Serialize(Factures);
		//Ajouter une separation avec des \n
		File.WriteAllText(PathFile, ClientJSON);
	}

	public void Payer()
	{
		throw new NotImplementedException();
	}

	public void ChoisirModePaiement()
	{
		throw new NotImplementedException();
	}
}
