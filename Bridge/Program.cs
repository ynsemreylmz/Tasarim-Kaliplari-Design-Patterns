

CustomerManager customerManager = new CustomerManager();
customerManager.messageSenderBase = new SmsSender();// MailSender();
customerManager.UpdateCustomer();
abstract class MessageSenderBase
{
	public void Save()
	{
		Console.WriteLine("Message Saved!");
	}
	public abstract void Send(Body body);

}
class Body
{
    public string Title { get; set; }
	public string Text { get; set; }

}
class MailSender : MessageSenderBase
{
	public override void Send(Body body)
	{
		Console.WriteLine("{0} was sent via MailSender.",body.Title);
	}
}

class SmsSender : MessageSenderBase
{
	public override void Send(Body body)
	{
		Console.WriteLine("{0} was sent via SmsSender.",body.Title);
	}
}


class CustomerManager
{
    public MessageSenderBase messageSenderBase { get; set; }
    public void UpdateCustomer()
	{
		messageSenderBase.Send(new Body { Title= "'About the Job!'"});

		Console.WriteLine("Customer Updated.");
    }
}