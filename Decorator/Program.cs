
var personelCar = new PersonelCar { Make = "BMW", Model = "3.20", HirePrice = 2500 };
SpecialOffer specialOffer = new SpecialOffer(personelCar);
specialOffer.DiscountPercentage = 10;
Console.WriteLine("Concrate: {0}",personelCar.HirePrice);
Console.WriteLine("Special Offer: {0}",specialOffer.HirePrice);

abstract class CarBase
{
    public abstract string Make { get; set; }
    public abstract string Model { get; set; }
    public abstract decimal HirePrice { get; set; }
}

class PersonelCar : CarBase
{
	public override string Make { get; set; }
	public override string Model { get; set; }
	public override decimal HirePrice { get; set; }
}

class CommercialCar : CarBase
{
	public override string Make { get; set; }
	public override string Model { get; set; }
	public override decimal HirePrice { get; set; }
}

abstract class CarDecarotBase : CarBase
{
	private CarBase _CarBase;

	protected CarDecarotBase(CarBase carBase)
	{
		_CarBase = carBase;
	}
}

class SpecialOffer : CarDecarotBase
{
    public int DiscountPercentage { get; set; }
    private readonly CarBase _CarBase;
	public SpecialOffer(CarBase carBase) : base(carBase)
	{
		_CarBase = carBase;
	}

	public override string Make { get; set; }
	public override string Model { get; set; }
	public override decimal HirePrice 
	{ 
		get 
		{ 
			return _CarBase.HirePrice - (_CarBase.HirePrice * DiscountPercentage / 100);
		} 
		set 
		{ 

		} 
	} 
}