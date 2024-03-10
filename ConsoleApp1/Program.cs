

CustomerManager customerManager = new CustomerManager();
customerManager.Save();

public class LoggerFactory: ILoggerFactory
{
	public ILogger CreatLogger()
	{
		return new MyLogger();
	}

	
}
public interface ILoggerFactory
{
	public ILogger CreatLogger();

}
public interface ILogger
{
	void Log();
}

public class MyLogger : ILogger
{
	public void Log()
	{
		Console.WriteLine("Logged with MyLogger");
	}
}

public class CustomerManager
{
	public void Save()
	{
		Console.WriteLine("Saved.");
		ILogger logger  = new LoggerFactory().CreatLogger();
	}
}