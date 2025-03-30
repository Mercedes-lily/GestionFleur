public class Carte
{
	private string message = "";

	//Constructeur
	public Carte()
	{

	}

	//Acesseur
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
}
