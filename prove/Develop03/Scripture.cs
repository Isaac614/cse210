using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _verse = new List<Word>();
    private List<int> _visibleWords = new List<int>();
    private bool _allHidden = false;



    public Scripture(Reference reference)
    {
        _reference = reference;
        ConvertFromCSV();
        for (int i = 0; i < _verse.Count; i++)
        {
            _visibleWords.Add(i);
        }
    }

    public bool CheckValidVerse()
    {
        if (_verse.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ConvertFromCSV()
    {
        TextFieldParser parser = new TextFieldParser("BookOfMormon.csv");

        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");
        parser.HasFieldsEnclosedInQuotes = true;
        parser.TrimWhiteSpace = true;

        bool found = false;
        parser.ReadFields();
        while (!parser.EndOfData && !found)
        {
            string[] fields = parser.ReadFields();

            string book = fields[1];
            string[] chAndVerse = fields[2].Split(":");
            int chapter = int.Parse(chAndVerse[0]);
            int verseNumber = int.Parse(chAndVerse[1]);

            if (book == _reference.Book && chapter == _reference.Chapter &&
            verseNumber == _reference.StartVerse)
            {
                string stringVerse = fields[3];
                _verse = CreateWordList(stringVerse);
                found = true;
            }
        }
    }

    public bool AllHidden
    {
        get { return _allHidden; }
    }

    public void DisplayScripture()
    {
        _reference.DisplayReference();
        foreach (Word word in _verse)
        {
            word.DisplayWord();
        }
    }

    private List<Word> CreateWordList(string verse)
    {
        string[] strings = verse.Split(" ");
        List<Word> wordList = new List<Word>();

        foreach (string str in strings)
        {
            Word newWord = new Word(str);
            wordList.Add(newWord);
        }
        return wordList;
    }

    public void HideWords()
    {
        int wordsToHide = (int)Math.Ceiling((double)_verse.Count / 6);
        Random randomGenerator = new Random();

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = randomGenerator.Next(0, _visibleWords.Count);
            Word randomWord = _verse[_visibleWords[randomIndex]];
            randomWord.IsVisbile = false;
            _visibleWords.RemoveAt(randomIndex);
            if (_visibleWords.Count == 0)
            {
                _allHidden = true;
                break;
            }
        }
    }
}