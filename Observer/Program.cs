ProductManager productManager = new ProductManager();
productManager.Attach(new CustomerObserver());
productManager.Attach(new EmployeeObserver());
productManager.Attach(new EmployeeObserver());
productManager.Attach(new CustomerObserver());
CustomerObserver customerObserver = new CustomerObserver();
productManager.Attach(customerObserver);
productManager.Detach(customerObserver);
productManager.UpdatePrice();

class ProductManager
{	List<Observer> _observers = new List<Observer>();
	public void UpdatePrice()
	{
        Console.WriteLine("Product Price Changed.");
		Notify();
    }

	public void Attach(Observer observer)
	{
		_observers.Add(observer);
	}

	public void Detach(Observer observer)
	{
		_observers.Remove(observer);
	}

	private void Notify()
	{
		foreach (var observer in _observers)
		{
			observer.Update();
		}
	}
}

abstract class Observer
{
	public abstract void Update();
}

class CustomerObserver : Observer
{
	public override void Update()
	{
        Console.WriteLine("Message to Customer : Product Price Changed.");
    }
}

class EmployeeObserver : Observer
{
	public override void Update()
	{
		Console.WriteLine("Message to Employee : Product Price Changed.");
	}
}