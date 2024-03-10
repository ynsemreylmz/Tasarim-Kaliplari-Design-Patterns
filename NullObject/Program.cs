

CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
customerManager.Save();



class CustomerManager
{
	private ILogger _logger;

	public CustomerManager(ILogger logger)
	{
		_logger = logger;
	}

	public void Save()
	{
        Console.WriteLine("Saved");
		_logger.Log();
    }
}

interface ILogger
{
	void Log();
}


class Log4NetLogger : ILogger
{
	public void Log()
	{
        Console.WriteLine("Logged with Log4Net");
    }
}

class NLogLogger : ILogger
{
	public void Log()
	{
		Console.WriteLine("Logged with NLogger");

	}
}


class StubLogger : ILogger
{
	private static StubLogger _stubLogger;
	private static Object _lock = new Object();

	private StubLogger() { }
	public static StubLogger GetLogger()
	{
		lock (_lock)
		{
			if(_stubLogger == null)
			{
				_stubLogger = new StubLogger();
			}
		}
		return _stubLogger;
	}

    public void Log()
	{
		
	}
}

class CustomerManagerTest
{
	public void Test()
	{
		CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
		customerManager.Save();
	}
}