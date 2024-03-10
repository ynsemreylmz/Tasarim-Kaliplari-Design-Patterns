
var customerManager = CustomerManager.CreateASingleton();

class CustomerManager
{

	private static CustomerManager? _customerManager;
	static object _customerManagerLock = new object();

	private CustomerManager()
	{

	}
	public static CustomerManager CreateASingleton()
	{
		lock (_customerManagerLock)
		{
			if (_customerManager == null)
			{
				_customerManager = new CustomerManager();
			}
			return _customerManager;
		}
	}
}

//class CustomerManager
//{

//	private static CustomerManager? _customerManager;


//	private CustomerManager()
//	{

//	}

//	static CustomerManager()
//	{
//		_customerManager = new CustomerManager();
//	}
//	public static CustomerManager CreateASingleton()
//	{
//		return _customerManager;

//	}
//}


