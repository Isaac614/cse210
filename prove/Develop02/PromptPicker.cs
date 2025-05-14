using System.Security.Cryptography;

public class PromptPicker
{
    public List<string> _prompts = new List<string>();
    
    public PromptPicker()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");

    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int promptIndex = random.Next(0, _prompts.Count);


        return _prompts[promptIndex];
    }

    public string GetSelectedPrompt()
    {
        while (true)
            try
            {
                DisplayPrompts();
                Console.WriteLine("\nWhich prompt would you like to choose? If you would like to create an entry without a prompt, input '0'");
                Console.Write("> ");
                int selectedPrompt = int.Parse(Console.ReadLine()) - 1;
                if (selectedPrompt == -1)
                {
                    return "None";
                }
                else
                {
                    return _prompts[selectedPrompt];
                }
            }
            catch
            {
                Console.WriteLine("Please input a valid prompt");
            }
    }

    public void DisplayPrompts()
    {
        for (int i = 0; i < _prompts.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            Console.WriteLine(_prompts[i]);
        }
    }
}