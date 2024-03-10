
StockManager stockManager = new();
BuyStock buyStock = new(stockManager);
SellStock sellStock = new(stockManager);


StockController stockController = new();
stockController.TakeOrder(buyStock);
stockController.TakeOrder(sellStock);
stockController.TakeOrder(sellStock);
stockController.TakeOrder(buyStock);
stockController.TakeOrder(sellStock);
stockController.PlacesOrders();


class StockManager
{
	private string _name = "Laptop";
	private int _quality = 10;

	public void Buy()
	{
		_quality += 1;

		Console.WriteLine("Stock: {0}, {1} bought!",_name,_quality);
    }

	public void Sell()
		
	{
		_quality -= 1;
		Console.WriteLine("Stock: {0}, {1} sold!", _name, _quality);

	}
}


interface IOrder
{
	void Execute();
}

class BuyStock : IOrder
{	
	private StockManager _stockManager;

    public BuyStock(StockManager stockManager)
    {
        _stockManager = stockManager;
    }

    public void Execute()
	{
		_stockManager.Buy();
	}
}

class SellStock : IOrder
{
	private StockManager _stockManager;

	public SellStock(StockManager stockManager)
	{
		_stockManager = stockManager;
	}
	public void Execute()
	{
		_stockManager.Sell();

	}
}


class StockController
{
	List<IOrder> _orders = new List<IOrder>();

	public void TakeOrder(IOrder order)
	{
		_orders.Add(order);
	}

	public void PlacesOrders()
	{
		foreach (IOrder order in _orders)
		{
			order.Execute();
		}

		_orders.Clear();

	}
}