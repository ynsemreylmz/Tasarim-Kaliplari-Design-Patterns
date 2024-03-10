

ProductManager productManager = new ProductManager(new LogNugetAdapter());
productManager.Save();
ProductManager productManager2 = new ProductManager(new Logger());
productManager2.Save();


class ProductManager
{
	private ILogger _logger;

	public ProductManager(ILogger logger)
	{
		_logger = logger;
	}

	public void Save()
	{
		_logger.Log("User Data");
		Console.WriteLine("Saved.");
		
	}
}

interface ILogger
{
	void Log(string message);

}

class Logger : ILogger
{
	public void Log(string message)
	{
        Console.WriteLine("Logged, {0}",message);
    }
}

//Nuget
class LogNuget
{
	public void LogMessage(string message)
	{
        Console.WriteLine("Logged with LogNugget, {0} ",message);
    }
}


class LogNugetAdapter : ILogger
{
	public void Log(string message)
	{
		LogNuget logNuget = new LogNuget();
		logNuget.LogMessage(message);
	}
}