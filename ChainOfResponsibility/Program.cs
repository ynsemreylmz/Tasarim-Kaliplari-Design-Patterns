
Manager manager = new Manager();
VicePresident vicePresident = new VicePresident();
President president = new President();

manager.SetSuccessor(vicePresident);
vicePresident.SetSuccessor(president);

Expence expence1 = new Expence {Detail="Traning", Amount=1708 };
manager.HandleExpence(expence1);

class Expence
{
    public string Detail { get; set; }
    public decimal Amount { get; set; }

}

abstract class ExpenceHandlerBase
{
    protected ExpenceHandlerBase Successor;
    public abstract void HandleExpence(Expence expence);

    public void SetSuccessor(ExpenceHandlerBase successor)
    {
        Successor = successor;
    }
}

class Manager : ExpenceHandlerBase
{
	public override void HandleExpence(Expence expence)
	{
		if(expence.Amount <= 100)
		{
            Console.WriteLine("Manager handled the expence!");
        }
		else if (Successor != null)
		{
			Successor.HandleExpence(expence);
		}
	}
}


class VicePresident : ExpenceHandlerBase
{
	public override void HandleExpence(Expence expence)
	{
		if (expence.Amount > 100 && expence.Amount <=1000)
		{
			Console.WriteLine("Vice President handled the expence!");
		}
		else if (Successor != null)
		{
			Successor.HandleExpence(expence);
		}
	}
}


class President : ExpenceHandlerBase
{
	public override void HandleExpence(Expence expence)
	{
		if (expence.Amount > 1000)
		{
			Console.WriteLine("President handled the expence!");
		}
		
	}
}