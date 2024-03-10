Mediator mediator = new Mediator();
Teacher teacher = new Teacher(mediator);
teacher.Name = "Emre";
mediator.teacher = teacher;

Student student1 = new Student(mediator);
student1.Name = "Yunus";
Student student2 = new Student(mediator);
student2.Name = "Yılmaz";


mediator.students = new List<Student> { student1, student2 };


teacher.SendNewImageUrl("1.jpg");

teacher.RecieveQuestion("is it true?",student1);

abstract class CourseMember
{
	protected Mediator Mediator;
	public CourseMember(Mediator mediator)
	{
		Mediator = mediator;
	}
}

class Teacher : CourseMember
{
	public Teacher(Mediator mediator) : base(mediator)
	{
	}

    public string Name { get; set; }

    public void RecieveQuestion(string question, Student student)
	{
        Console.WriteLine("{2} recieved a question from {0}, '{1}'", student.Name, question,Name);
    }

	public void SendNewImageUrl(string url)
	{
        Console.WriteLine("{1} changed slide: '{0}'", url,Name);
		Mediator.UpadateImange(url);
    }

	public void AnswerQuestion(string answer, Student student)
	{
        Console.WriteLine("{2} answered question {0}, '{1}'",student.Name, answer, Name);
    }
}

class Student : CourseMember
{
	public Student(Mediator mediator) : base(mediator)
	{
	}

	public string Name { get; set; }

	internal void ReciveImage(string url)
	{
        Console.WriteLine("{1} received image : '{0}'",url, Name);
    }

	internal void ReciveAnswer(string answer)
	{
        Console.WriteLine("{1} recive answer '{0}'",answer,Name);
    }
}

class Mediator
{
    public Teacher teacher { get; set; }
    public List<Student> students { get; set; }
    public void UpadateImange(string url)
    {
        foreach (var student in students)
        {
            student.ReciveImage(url);
        }
    }

    public void SendQuestion(string question, Student student)
    {
        teacher.RecieveQuestion(question,student);
    }

    public void SendAnswer(string answer, Student student)
    {
        student.ReciveAnswer(answer);
    }
}