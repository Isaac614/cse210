using System.Diagnostics;

public class BreathingActivity : Activity
{

    public BreathingActivity() : base("Breathing Activity",
    "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }


    public void DipslayBreathing()
    {
        GetActivityDuration();
        DisplayStartMessage();

        // Instead of using datetime to keep track of the time passed I'm using a built in stopwatch class. 
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds <= _activityDuration) 
        {
            Console.WriteLine("Breath in...");
            Pause(1, 4000);
            Console.WriteLine("Breath out...");
            Pause(1, 4000);
        }
        stopwatch.Stop();


        DisplayEndMessage((int)stopwatch.ElapsedMilliseconds / 1000);
    }
}