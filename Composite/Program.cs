using System.Collections;

internal class Program
{
	private static void Main(string[] args)
	{
		Employee yunus = new Employee { Name = "Yunus Yılmaz"};
		Employee emre = new Employee { Name = "Emre Yılmaz"};
		
		yunus.AdSubordinate(emre);

		Employee merve = new Employee { Name = "Merve Yılmaz" };
	
		yunus.AdSubordinate(merve);
		Employee muhammet = new Employee { Name = "Muhammet Yılmaz" };
		emre.AdSubordinate(muhammet);

		Contractor onur = new Contractor { Name = "Onur Dağ"};

		merve.AdSubordinate(onur);

		Console.WriteLine("{0}", yunus.Name);
		foreach (Employee manager in yunus)
		{
            Console.WriteLine("  {0}",manager.Name);

			foreach (IPerson employee in manager)
			{
                Console.WriteLine("    {0}", employee.Name);
            }
        }

	}
}

interface IPerson
{
	string Name { get; set; }
}

class Contractor : IPerson
{
	public string Name { get; set; }
}

class Employee : IPerson, IEnumerable<IPerson>
{
	List<IPerson> _subordinates = new List<IPerson>();

	public void AdSubordinate(IPerson person)
	{
		_subordinates.Add(person);
	}

	public void RemoveSubordinate(IPerson person)
	{
		_subordinates.Remove(person);
	}

	public IPerson GetSubordinate(int index)
	{
		return _subordinates[index];
	}

	public string Name { get; set; }

	public IEnumerator<IPerson> GetEnumerator()
	{
		foreach(var subordinate in _subordinates)
		{
			yield return subordinate;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}