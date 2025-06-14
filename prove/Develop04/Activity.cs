public class Activity
{
    private string _activityName;
    protected int _activityDuration;
    private string _activityDescription;

    public Activity()
    { }
    public Activity(string name, string description)
    {
        _activityName = name;
        _activityDescription = description;
    }

    protected void DisplayStartMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName}!");
        Console.WriteLine(_activityDescription);
    }

    protected void GetActivityDuration()
    {
        int duration = 0;
        while (true)
        {
            Console.WriteLine("How long do you want this activity to be in seconds? ");
            try
            {
                duration = int.Parse(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Please input a valid number");
            }
        }

        _activityDuration = duration * 1000;
    }

    protected void Pause(int loadType, int duration)
    {
        if (loadType == 0)
        {
            DisplayLoadingIcon(duration);
        }
        else if (loadType == 1)
        {
            DisplayLoadingNumbers(duration);
        }
        else if (loadType == 2)
        {
            DislpayLoadingDots(duration);
        }
    }

    private void DisplayLoadingIcon(int duration)
    {
        for (int i = 0; i < duration; i += 600)
        {
            Console.Write("\r|");
            Thread.Sleep(150);
            Console.Write("\r/");
            Thread.Sleep(150);
            Console.Write("\r-");
            Thread.Sleep(150);
            Console.Write("\r\\");
            Thread.Sleep(150);
        }
        Console.WriteLine("\r ");
    }

    private void DisplayLoadingNumbers(int duration)
    {
        int startNum = duration / 1000;
        while (startNum != 0)
        {
            Console.Write($"\r{startNum}");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write(".");
            Thread.Sleep(250);
            Console.Write("\r    ");
            startNum -= 1;
        }
        Console.WriteLine("\r ");
    }

    private void DislpayLoadingDots(int duration)
    {
        for (int i = 0; i < duration; i += 4500)
        {
            Console.Write("\r.");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write("\r    ");
            Console.Write("\r");
            Thread.Sleep(500);

            Console.Write("\r.");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write("\r    ");
            Console.Write("\r");
            Thread.Sleep(500);

            Console.Write("\r.");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write("\r    ");
            Console.Write("\r");
            Thread.Sleep(500);
        }
        Console.WriteLine("\r ");
    }

    protected void DisplayEndMessage(int elapsedSeconds)
    {
        Console.WriteLine($"Good job, you've finished the activity!");
        Pause(0, 3000);
        Console.WriteLine($"The activity you just completed was {elapsedSeconds} seconds long.");
        Pause(0, 3000);
    }

}