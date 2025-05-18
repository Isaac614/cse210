using System.Text.Json;
using System.IO;
using System.Runtime.CompilerServices;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }


    public void SaveToFile(string fileName)
    {
        var json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
        File.WriteAllText(fileName, json);
    }

    public void ReadFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            var entries = JsonSerializer.Deserialize<List<Entry>>(json, new JsonSerializerOptions { IncludeFields = true });
            _entries = entries;
        }

        else 
        {
            throw new FileNotFoundException("File not found.", fileName);
        }
    }
    
}