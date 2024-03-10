CustomerManager CustomerManager = new CustomerManager();
CustomerManager.creditCalculatorBase = new Before2005CreditCalculator();
CustomerManager.SaveCredit();
CustomerManager.creditCalculatorBase = new Before2015CreditCalculator();
CustomerManager.SaveCredit();
abstract class CreditCalculatorBase
{
	public abstract void Calculte();
}

class Before2005CreditCalculator : CreditCalculatorBase
{
	public override void Calculte()
	{
        Console.WriteLine("Credit Calculated using Before2005");
    }
}

class Before2015CreditCalculator : CreditCalculatorBase
{
	public override void Calculte()
	{
		Console.WriteLine("Credit Calculated using Before2015");
	}
}

class CustomerManager
{
    public CreditCalculatorBase creditCalculatorBase { get; set; }

   
    public void SaveCredit()
	{
		Console.WriteLine("Customer Manager Buisness");
		creditCalculatorBase.Calculte();
	}
}