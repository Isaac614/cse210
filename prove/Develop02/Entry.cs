public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    // Without this paramaterless constructor the Journal.ReadFile() method doesn't work
    public Entry() 
    {
    }
    
    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"\nDate - {_date}\nPrompt - {_prompt}\nResponse - {_response}");
    }
}