public class Goal
{
    private string _description;
    private int _points;


    // This is a shorthand syntax for creating a getter.
    public virtual string Type
    {
        get { return "base"; }
    }
    public int Points
    {
        get { return _points; }
    }

    public string Description
    {
        get { return _description; }
    }

    public Goal(string desc, int points)
    {
        _description = desc;
        _points = points;
    }

    public virtual bool Completed()
    {
        return false;
    }

    public virtual void DisplayGoal()
    {
        Console.WriteLine($"{_description} - {_points} points");
    }

    public virtual void MarkComplete() { }

    public virtual string ConvertToString()
    {
        return $"Description: {_description}\n" +
        $"Points: {_points}";
    }
    

}