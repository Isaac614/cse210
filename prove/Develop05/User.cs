public class User
{
    private List<Goal> _goals = new List<Goal>();
    private int _points = 0;

    public User()
    {
        _goals.Add(new SimpleGoal("Go to the temple", 300));
        _goals.Add(new EternalGoal("Learn about something", 150));
        _goals.Add(new ChecklistGoal("Compliment somone", 200, 5));
        _goals.Add(new RecurringGoal("Read your scriptures", 100, 1));
    }

    public void DisplayGoals()
    {
        int counter = 1;
        foreach (Goal goal in _goals)
        {
            Console.Write($"{counter}. ");
            goal.DisplayGoal();
            Console.WriteLine();
            counter++;
        }
    }

    public void AddGoal(string desc, int points, string type)
    {
        if (type == "0")
        {
            _goals.Add(new SimpleGoal(desc, points));
        }
        else if (type == "1")
        {
            _goals.Add(new EternalGoal(desc, points));
        }
    }

    public void AddGoal(string desc, int points, int completeCondition)
    {
        _goals.Add(new ChecklistGoal(desc, points, completeCondition));
    }

    public void AddGoal(int refreshFrequency, string desc, int points)
    {
        _goals.Add(new RecurringGoal(desc, points, refreshFrequency));
    }

    public void MarkAsCompleted(int goalIndex)
    {
        Goal goal = _goals[goalIndex];
        if (goal.Completed())
        {
            return;
        }
        else
        {
            _goals[goalIndex].MarkComplete();
            if (goal.Completed())
            {
                _points += _goals[goalIndex].Points;
            }
        }
    }

    public void DipslayPoints()
    {
        Console.WriteLine($"You have {_points} points");
    }

    public void SaveToFile(string filepath)
    {
        List<string> stringGoals = new();
        foreach (Goal goal in _goals)
        {
            stringGoals.Add(goal.ConvertToString());
        }

        string saveData = "";
        saveData += $"UserPoints: {_points}\n\n";
        foreach (string stringGoal in stringGoals)
        {
            saveData += stringGoal + "\n\n";
        }
        saveData = saveData.Substring(0, saveData.Length - 2);


        using (StreamWriter outputFile = new StreamWriter(filepath))
        {
            outputFile.WriteLine(saveData);
        }
    }

    public void LoadFromFile(string filepath)
    {
        _goals.Clear();
        string fileContents = File.ReadAllText(filepath);
        List<string> stringObjects = new List<string>(fileContents.Split("\n\n"));


        foreach (string stringObject in stringObjects)
        {
            bool isGoal = true;
            List<string> stringFields = new List<string>(stringObject.Split("\n"));
            Dictionary<string, string> goalData = new Dictionary<string, string>();

            foreach (string field in stringFields)
            {
                if (!String.IsNullOrEmpty(field))
                {
                    int colonIndex = field.IndexOf(":");
                    string key = field.Substring(0, colonIndex);
                    string value = field.Substring(colonIndex + 2);
                    if (key == "UserPoints")
                    {
                        _points = int.Parse(value);
                        isGoal = false;
                    }
                    else
                    {
                        goalData[key] = value;
                    }
                }
            }

            if (isGoal)
            {
                if (goalData["Type"] == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(goalData["Description"], int.Parse(goalData["Points"]), bool.Parse(goalData["Completed"])));
                }
                else if (goalData["Type"] == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(goalData["Description"], int.Parse(goalData["Points"])));
                }
                else if (goalData["Type"] == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(goalData["Description"], int.Parse(goalData["Points"]),
                    int.Parse(goalData["Complete Requirement"]), int.Parse(goalData["Completed"])));
                }
                else if (goalData["Type"] == "RecurringGoal")
                {
                    _goals.Add(new RecurringGoal(goalData["Description"], int.Parse(goalData["Points"]), int.Parse(goalData["ResetFrequency"]),
                    DateTime.Parse(goalData["StartDate"]), bool.Parse(goalData["Completed"])));
                }
            }
        }
    }
}