

CustomerManager customerManager = new CustomerManager(new LoggerFactory());
customerManager.Save();

CustomerManager customerManager2 = new CustomerManager(new LoggerFactory2());
customerManager2.Save();

public interface ILoggerFactory
{
	ILogger CreatLogger();

}
public interface ILogger
{
	void Log();
}
public class LoggerFactory : ILoggerFactory
{
	public ILogger CreatLogger()
	{	
		//Business to decide factory
		return new MyLogger();
	}


}

public class LoggerFactory2 : ILoggerFactory
{
	public ILogger CreatLogger()
	{
		//Business to decide factory
		return new MyLogger2();
	}


}
public class MyLogger : ILogger
{
	public void Log()
	{
		Console.WriteLine("Logged with MyLogger");
	}
}
public class MyLogger2 : ILogger
{
	public void Log()
	{
		Console.WriteLine("Logged with MyLogger2");
	}
}



public class CustomerManager
{	private ILoggerFactory _loggerFactory;
	public CustomerManager(ILoggerFactory loggerFactory)
	{
		_loggerFactory = loggerFactory;
	}
	public void Save()
	{
		Console.WriteLine("Saved.");
		ILogger logger = _loggerFactory.CreatLogger();
		logger.Log();
	}
}