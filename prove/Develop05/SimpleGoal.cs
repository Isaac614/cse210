public class SimpleGoal : Goal
{
    private bool _completed = false;

    public SimpleGoal(string desc, int points) : base(desc, points)
    { }

    public SimpleGoal(string desc, int points, bool completed) : base(desc, points)
    {
        _completed = completed;
    }

    public override string Type
    {
        get { return "Simple"; }
    }

    public bool Complete
    {
        get { return _completed; }
    }

    public override bool Completed()
    {
        return _completed;
    }

    public override void MarkComplete()
    {
        _completed = true;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine("SimpleGoal");
        base.DisplayGoal();
        Console.WriteLine($"completed: {_completed}");
    }

    public override string ConvertToString()
    {
        string goalInfo = "Type: SimpleGoal";
        goalInfo += "\n" + base.ConvertToString();
        goalInfo += $"\nCompleted: {_completed}";
        return goalInfo;
    }
}