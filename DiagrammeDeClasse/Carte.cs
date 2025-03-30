public class Carte
{
	private string message = "";

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

	}
}
