
ProductManager productManager = new ProductManager(new Factory1());
productManager.GetAll();
ProductManager productManager2 = new ProductManager(new Factory2());
productManager2.GetAll();


public abstract class Logging
{
	public abstract void Log(string message);
}



public class Logger1 : Logging
{
	public override void Log(string message)
	{
		Console.WriteLine("Logged with Logger1");
	}
}

public class Logger2 : Logging
{
	public override void Log(string message)
	{
		Console.WriteLine("Logged with Logger2");
	}
}


public abstract class Caching
{
	public abstract void Cache(string data);
}

public class Cache1 : Caching
{
	public override void Cache(string data)
	{
		Console.WriteLine("Cached with Cache1");
	}
}

public class Cache2 : Caching
{
	public override void Cache(string data)
	{
		Console.WriteLine("Cached with Cache2");
	}
}


public abstract class CrosCuttingConcernsFactory
{
	public abstract Logging CreateLogger();
	public abstract Caching CreateCaching();
}

public class Factory1 : CrosCuttingConcernsFactory
{
	public override Caching CreateCaching()
	{
		return new Cache1();
	}

	public override Logging CreateLogger()
	{
		return new Logger1();
	}
}

public class Factory2 : CrosCuttingConcernsFactory
{
	public override Caching CreateCaching()
	{
		return new Cache2();
	}

	public override Logging CreateLogger()
	{
		return new Logger1();
	}
}

public class ProductManager
{
	CrosCuttingConcernsFactory _crosCuttingConcernsFactory;
	private Logging _logging;
	private Caching _caching;

    public ProductManager(CrosCuttingConcernsFactory crosCuttingConcernsFactory)
    {
        _crosCuttingConcernsFactory = crosCuttingConcernsFactory;
		_logging = _crosCuttingConcernsFactory.CreateLogger();
		_caching = _crosCuttingConcernsFactory.CreateCaching();
    }
    public void GetAll()
	{
		_logging.Log("Message");
		_caching.Cache("Data");
		Console.WriteLine("Product Listed!");
	}
}