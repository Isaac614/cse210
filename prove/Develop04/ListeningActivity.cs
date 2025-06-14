using System.Diagnostics;
using System.Net;
using System.Security;

public class ListeningActivity : Activity
{
    private List<string> _prompts = new List<string>();

    public ListeningActivity() : base("Listening Activity",
    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }


    public void DisplayListening()
    {
        DisplayStartMessage();
        GetActivityDuration();

        Random random = new Random();
        int randomIndex = random.Next(0, _prompts.Count - 1);
        Console.WriteLine(_prompts[randomIndex]);
        Pause(1, 10000);


        List<string> responses = new List<string>();

        // Instead of using datetime to keep track of the time passed I'm using a built in stopwatch class. 
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        while (stopwatch.ElapsedMilliseconds < _activityDuration)
        {
            Console.WriteLine("> ");
            responses.Add(Console.ReadLine());
        }

        Pause(0, 5000);
        Console.WriteLine("Here is what you said - ");
        Pause(0, 2000);
        foreach (string response in responses)
        {
            Console.WriteLine($"> {response}");
        }
    }   
}