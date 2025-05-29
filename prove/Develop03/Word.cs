public class Word
{
    private int _length;
    private bool _isVisible = true;
    private string _word;

    public Word(string word)
    {
        _word = word;
        _length = word.Length;
    }

    public void DisplayWord()
    {
        if (_isVisible)
        {
            Console.Write($"{_word} ");
        }
        else
        {
            Console.Write(" ");
            for (int i = 0; i < _length; i++)
            {
                Console.Write("_");
            }
            Console.Write(" ");
        }
    }

    public bool IsVisbile
    {
        get { return _isVisible; }
        set { _isVisible = value; }
    }

}