using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class Carte
{
	private string message;

	public string Message
	{
		get 
		{ 
			return message; 
		}
		set 
		{
			if (!string.IsNullOrEmpty(value))
				message = value; 
		}
	}
	public Carte()
	{
		this.message = "Revenez-nous vite en pleine forme! Amitiés ";
	}
	public void InscrireMessage()
	{
		Message = Console.ReadLine();
	}
}
