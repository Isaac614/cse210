public class ChecklistGoal : Goal
{
    private int _completeRequirement = 1;
    private int _numCompleted = 0;

    public ChecklistGoal(string desc, int points, int completeRequirement) : base(desc, points)
    {
        _completeRequirement = completeRequirement;
    }

    public ChecklistGoal(string desc, int points, int completeRequirement, int numCompleted) : base(desc, points)
    {
        _completeRequirement = completeRequirement;
        _numCompleted = numCompleted;
    }

    public override string Type
    {
        get { return "Checklist"; }
    }

    public override bool Completed()
    {
        return _numCompleted == _completeRequirement;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine("Checklist Goal");
        base.DisplayGoal();
        if (_numCompleted == _completeRequirement)
        {
            Console.WriteLine("goal complete!");
        }
        Console.WriteLine($"completed: {_numCompleted} / {_completeRequirement}");
    }

    public override void MarkComplete()
    {
        if (_numCompleted < _completeRequirement)
        {
            _numCompleted++;
        }
    }

    public override string ConvertToString()
    {
        string goalInfo = "Type: ChecklistGoal";
        goalInfo += "\n" + base.ConvertToString();
        goalInfo += $"\nCompleted: {_numCompleted}" +
        $"\nComplete Requirement: {_completeRequirement}";
        return goalInfo;
    }
}