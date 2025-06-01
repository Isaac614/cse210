using System.Data.SqlTypes;

public class Assignment
{
    private string _studentName;
    private string _topic;

    public string StudentName
    {
        get { return _studentName; }
    }

    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}