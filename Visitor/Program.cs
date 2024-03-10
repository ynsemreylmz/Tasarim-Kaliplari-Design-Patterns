
Manager yunus = new Manager { Name = "Yunus", Salary=60000};
Manager emre = new Manager { Name = "Emre", Salary = 45000 };

Worker merve = new Worker {Name="Merve", Salary=40000 };
Worker ali = new Worker { Name = "Ali", Salary = 30000 };


yunus.Subordinates.Add(emre);
emre.Subordinates.Add(merve);
emre.Subordinates.Add(ali);

OrganisationStructure organisationStructure = new OrganisationStructure(yunus);

PayrollVisiter payrollVisiter = new PayrollVisiter();
PayriseVisiter payriseVisiter = new PayriseVisiter();


organisationStructure.Accept(payrollVisiter);
organisationStructure.Accept(payriseVisiter);


class OrganisationStructure
{
	public EmployeeBase Employee;

    public OrganisationStructure(EmployeeBase firstEmployee)
    {
		Employee = firstEmployee;
    }

    public void Accept(VisitorBase visitor)
    {
		Employee.Accept(visitor);
    }
}

abstract class EmployeeBase
{
    public abstract void Accept(VisitorBase visitor);
    public string Name { get; set; }
    public decimal Salary { get; set; }

}

class Manager : EmployeeBase
{
    public Manager()
    {
        Subordinates = new List<EmployeeBase>();
    }

    public List<EmployeeBase> Subordinates { get; set; }
	

	public override void Accept(VisitorBase visitor)
	{
		visitor.Visit(this);
		foreach (var employee in Subordinates)
		{
			employee.Accept(visitor);
		}
	}
}

class Worker : EmployeeBase
{
	public override void Accept(VisitorBase visitor)
	{
		visitor.Visit(this);

	}
}

abstract class VisitorBase
{
	public abstract void Visit(Worker worker);
	public abstract void Visit(Manager manager);
}

class PayrollVisiter : VisitorBase
{
	public override void Visit(Worker worker)
	{
        Console.WriteLine("{0}, paid {1}",worker.Name,worker.Salary);
    }

	public override void Visit(Manager manager)
	{
		Console.WriteLine("{0}, paid {1}", manager.Name, manager.Salary);

	}
}


class PayriseVisiter : VisitorBase
{
	public override void Visit(Worker worker)
	{
		Console.WriteLine("{0}, salary increased to {1}", worker.Name, worker.Salary*(decimal)1.1);
	}

	public override void Visit(Manager manager)
	{
		Console.WriteLine("{0}, salary increased to {1}", manager.Name, manager.Salary*(decimal)1.2);
	}
}