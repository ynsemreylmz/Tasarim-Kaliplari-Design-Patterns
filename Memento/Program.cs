﻿
Book book = new Book
{
	Isbn = "12345",
	Title= "Sefiller",
	Author= "Victor Hugo"
};

book.ShowBook();
CareTaker history = new();

history.memento = book.CreateUndo();
book.Isbn = "54321";
book.Title = "SEFİLLER";
book.ShowBook();

book.RestoreFromUndo(history.memento);
book.ShowBook();


class Book
{
	private string _title;
	private string _author;
	private string _isbn;
	private DateTime _lastEdited;

	public string Title 
	{
		get { return _title; }
		set 
		{ 
			_title = value; 
			SetLastEdited();
		}
	}
	public string Author
	{
		get { return _author; }
		set
		{
			_author = value;
			SetLastEdited();

		}
	}
	public string Isbn
	{
		get { return _isbn; }
		set
		{
			_isbn = value;
			SetLastEdited();

		}
	}

	private void SetLastEdited()
	{
		_lastEdited = DateTime.UtcNow;
	}
	public Memento CreateUndo()
	{
		return new Memento(_isbn, _title,_author,_lastEdited);
	}

	public void RestoreFromUndo(Memento memento)
	{
		_title=memento.Title;
		_author=memento.Author;
		_isbn=memento.Isbn;
		_lastEdited=memento.LastEdited;

	}

	public void ShowBook()
	{
		Console.WriteLine("{0}, {1}, {2}   edited: {3}",Title,Author,Isbn,_lastEdited);
    }
}

class Memento
{
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime LastEdited { get; set; }

    public Memento(string isbn, string title, string author, DateTime lastEdited)
    {
        Isbn = isbn;
		Title = title;
		Author = author;
		LastEdited = lastEdited;
    }
}

class CareTaker
{
    public Memento memento { get; set; }
}