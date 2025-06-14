using System.Diagnostics;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _reflections = new List<string>();

    public ReflectionActivity() : base("Reflection Activity",
    "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _reflections.Add("Why was this experience meaningful to you?");
        _reflections.Add("Have you ever done anything like this before?");
        _reflections.Add("How did you get started?");
        _reflections.Add("How did you feel when it was complete?");
        _reflections.Add("What made this time different than other times when you were not as successful?");
        _reflections.Add("What is your favorite thing about this experience?");
        _reflections.Add("What could you learn from this experience that applies to other situations?");
        _reflections.Add("What did you learn about yourself through this experience?");
        _reflections.Add("How can you keep this experience in mind in the future?");
    }

    public void DisplayReflection()
    {
        GetActivityDuration();
        DisplayStartMessage();
        Pause(0, 7000);

        List<int> completedPrompts = new List<int>();

        // Instead of using datetime to keep track of the time passed I'm using a built in stopwatch class. 
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.ElapsedMilliseconds <= _activityDuration && completedPrompts.Count != _prompts.Count)
        {
            Random random = new Random();
            int promptIndex = random.Next(0, _prompts.Count - 1);

            while (completedPrompts.Contains(promptIndex))
            {
                if (promptIndex == _prompts.Count - 1)
                {
                    promptIndex = 0;
                }
                else
                {
                    promptIndex++;
                }
            }


            Console.WriteLine(_prompts[promptIndex]);
            Pause(0, 7000);

            int reflectionIndex = random.Next(0, _reflections.Count - 1);
            Console.WriteLine(_reflections[reflectionIndex]);
            Pause(0, 7000);
        }
        stopwatch.Stop();

        DisplayEndMessage((int)stopwatch.ElapsedMilliseconds / 1000);
    }
}