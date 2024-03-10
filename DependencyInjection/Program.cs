
ProductManager productManager = new ProductManager(new NhProductDal());
productManager.Save();

interface IProductDal
{
	void Save();
}

class EfProductDal : IProductDal
{
	public void Save()
	{
		Console.WriteLine("Saved with Ef");
	}
}
class NhProductDal : IProductDal
{
	public void Save()
	{
		Console.WriteLine("Saved with Nh");
	}
}

class ProductManager
{
	private IProductDal _product;

	public ProductManager(IProductDal product)
	{
		_product = product;
	}

	public void Save()
	{
		//Buisness Code
		_product.Save();


	}
}