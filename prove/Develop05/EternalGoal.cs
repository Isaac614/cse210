public class EternalGoal : Goal
{
    private int _numCompleted = 0;

    public EternalGoal(string desc, int points) : base(desc, points)
    { }

    public EternalGoal(string desc, int points, int numCompleted) : base(desc, points)
    {
        _numCompleted = numCompleted;
    }

    public override string Type
    {
        get { return "Eternal"; }
    }

    public override bool Completed()
    {
        return true;
    }

    public override void MarkComplete()
    {
        _numCompleted++;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine("Eternal Goal");
        base.DisplayGoal();
        Console.WriteLine($"times completed: {_numCompleted}");
    }

    public override string ConvertToString()
    {
        string goalInfo = "Type: EternalGoal";
        goalInfo += "\n" + base.ConvertToString();
        goalInfo += $"\nCompleted: {_numCompleted}";
        return goalInfo;
    }
}