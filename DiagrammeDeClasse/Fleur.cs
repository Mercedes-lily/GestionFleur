using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Fleur : Article
{
	private string nom;
	private string couleur;
	private string description;
	private int quantite = 10;
	static private List<Fleur> fleurs = new List<Fleur>();

	public Fleur(): base()
	{ }
	public Fleur(string nom, double prixUnitaire,  string couleur, string description) : base(prixUnitaire)
	{
		this.nom = nom;
		this.couleur = couleur;
		this.description = description;
	}
	public int Quantite { get { return quantite; } set { quantite = value; } }
	public static List<Fleur> Fleurs { get { return fleurs; } }
	public string Nom { get { return nom; } }
	public string Description { get { return description; } }
	public string Couleur { get { return couleur; } }
	public override void Afficher()
	{
		Console.WriteLine($"Nom: {nom} Prix unitaire: {prixUnitaire} Couleur {couleur} Description {description}");
	}
	static public void ImporterDonnees(string path)
	{	
		using (var reader = new StreamReader(path))
		using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
		{
			csv.Context.RegisterClassMap<FleurMap>();
			var records = csv.GetRecords<Fleur>();
			foreach (var record in records)
			{
				fleurs.Add(record);
			}
		}
	}
	public sealed class FleurMap : ClassMap<Fleur>
	{
		public FleurMap()
		{
			Map(m => m.nom).Name("Nom");
			Map(m => m.prixUnitaire).Name("Prix Unitaire (CAD)");
			Map(m => m.couleur).Name("Couleur");
			Map(m => m.description).Name("Caractéristiques");
		}
	}
}
