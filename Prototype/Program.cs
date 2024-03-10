Customer customer1 = new() { FirstName="Yunus", LastName="Yılmaz",City="İstanbul", Id=1};

Customer customer2 = (Customer)customer1.Clone();

customer2.FirstName = "Emre";

Console.WriteLine(customer1.FirstName);
Console.WriteLine(customer2.FirstName);


//Prototype class
public abstract class Person 
{
    public abstract Person Clone();
    public int Id { get; set; }
    public  string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Customer : Person
{
    public string City { get; set; }

	public override Person Clone()
	{
		return (Person) MemberwiseClone(); 
	}
}


public class Employee : Person
{
	public decimal Salary { get; set; }

	public override Person Clone()
	{
		return (Person)MemberwiseClone();
	}
}

