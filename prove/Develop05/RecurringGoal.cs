public class RecurringGoal : Goal
{

    private bool _completed = false;
    private int _resetFrequency = 1;
    private DateTime _startDate;
    private DateTime _currentDate;
    public RecurringGoal(string desc, int points, int resetFrequency) : base(desc, points)
    {
        _resetFrequency = resetFrequency;
        _startDate = DateTime.Now;
        _currentDate = DateTime.Now;
    }

    public RecurringGoal(string desc, int points, int resetFrequency, DateTime startDate, bool completed) : base(desc, points)
    {
        _resetFrequency = resetFrequency;
        _completed = completed;
        _startDate = startDate;
        _currentDate = DateTime.Now;
        Refresh();
    }

    public override string Type
    {
        get { return "Recurring"; }
    }

    public bool Complete
    {
        get { return _completed; }
    }

    public override bool Completed()
    {
        return _completed;
    }

    public void Refresh()
    {
        int daysPassed = (_currentDate - _startDate).Days;
        if (daysPassed >= _resetFrequency)
        {
            _completed = false;
        }
    }

    public override void MarkComplete()
    {
        _completed = true;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine("Recurring Goal");
        base.DisplayGoal();
        Console.WriteLine($"reset frequency: {_resetFrequency}");
        Console.WriteLine($"last reset: {_startDate.Date}");
        Console.WriteLine($"next reset: {_startDate.AddDays(5).Date}");
        Console.WriteLine($"completed: {_completed}");
    }

    public override string ConvertToString()
    {
        string goalInfo = "Type: RecurringGoal";
        goalInfo += "\n" + base.ConvertToString();
        goalInfo += $"\nCompleted: {_completed}";
        goalInfo += $"\nResetFrequency: {_resetFrequency}";
        goalInfo += $"\nStartDate: {_startDate}";
        return goalInfo;
    }
}