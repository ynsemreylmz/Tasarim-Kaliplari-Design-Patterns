

CustomerManager CustomerManager = new();

CustomerManager.Save();


internal interface ILogging
{
	void Log();
}
internal interface ICachig
{
	void Cache();
}
internal interface IAuthorize
{
	void CheckUser();
}
class Logging : ILogging
{
	public void Log()
	{
		Console.WriteLine("Logged");
	}
}

class Caching : ICachig
{
	public void Cache()
	{
		Console.WriteLine("Cached");
	}
}
class Authorize :IAuthorize	
{
	public void CheckUser()
	{
		Console.WriteLine("User Checked");
	}
}

class CustomerManager
{
	private CrossCuttingConcernsFacade _concerns;

	public CustomerManager()
	{
		_concerns = new CrossCuttingConcernsFacade();
	}

	public void Save()
	{
		_concerns._cachig.Cache();
		_concerns._authorize.CheckUser();
		_concerns._logging.Log();
		
		
		Console.WriteLine("Saved.");
	}
}

class CrossCuttingConcernsFacade
{
	public ILogging _logging;
	public ICachig _cachig;
	public IAuthorize _authorize;

    public CrossCuttingConcernsFacade()
    {
        _logging = new Logging();
		_cachig = new Caching();
		_authorize = new Authorize();
    }
}