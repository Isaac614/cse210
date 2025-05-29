using System.Data;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse = -1;

    // These are a shorthand way of creating getters and setters for private fields. Essentially you 
    // "wrap" the field in a public method. This that someone can access the private field via the 
    // public method by calling the method.
    public string Book
    {
        get { return _book; }
    }

    public int Chapter
    {
        get { return _chapter; }
    }

    public int StartVerse
    {
        get { return _startVerse; }
    }

    public int EndVerse
    {
        get { return _endVerse; }
    }

    public Reference()
    { }

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public void GetReference()
    {
        string book;
        int chapter;
        int verse;
        while (true)
        {
            try
            {
                Console.WriteLine("What book does the verse belong to? ");
                book = Console.ReadLine();
                Console.WriteLine("What what chapter is the verse in? ");
                chapter = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the verse number? ");
                verse = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Something went wrong. Make sure that chapter and verse numbers" +
                " are numbers.");
            }
        }
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
    }

    public void DisplayReference()
    {
        if (_endVerse != -1)
        {
            Console.WriteLine($"{_book} {_chapter}:{_startVerse} - {_endVerse}");
        }
        else
        {
            Console.WriteLine($"{_book} {_chapter}:{_startVerse}");
        }
    }
}