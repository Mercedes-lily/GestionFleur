using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class Carte
{
	private string message;

	public Carte()
	{
		this.message = "Revenez-nous vite en pleine forme! Amitiés ";
	}
	public Carte(string message)
	{
		this.message = message;
	}
	public void InscrireMessage()
	{
		throw new NotImplementedException();
	}
}
