﻿
CreditManager creditManager = new CreditManager();
Console.WriteLine(creditManager.Calculate());
Console.WriteLine(creditManager.Calculate());
Console.WriteLine(creditManager.Calculate());
Console.WriteLine(creditManager.Calculate());

Console.WriteLine("\n Proxy:");
CreditManagerProxy creditManagerProxy = new CreditManagerProxy();
Console.WriteLine(creditManagerProxy.Calculate());
Console.WriteLine(creditManagerProxy.Calculate());
Console.WriteLine(creditManagerProxy.Calculate());
Console.WriteLine(creditManagerProxy.Calculate());

abstract class CreditBase
{
	public abstract int Calculate();
}

class CreditManager : CreditBase
{
	public override int Calculate()
	{
		int result = 1;
		for (int i = 1; i < 5; i++)
		{
			result *= i;
			Thread.Sleep(1000);
		}
		return result;
	}
}

class CreditManagerProxy : CreditBase
{
	private CreditManager _creditManager;
	private int _cachedValue;
	public override int Calculate()
	{
		if(_creditManager == null)
		{
			_creditManager = new CreditManager();
			_cachedValue = _creditManager.Calculate();
		}
		return _cachedValue;

	}
}