class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;
        Console.WriteLine("Welcome to the Mindfulness Program. Please select an option.");
        while (keepRunning)
        {
            int userChoice;
            Console.WriteLine("1. Breathing activity");
            Console.WriteLine("2. Reflection activity");
            Console.WriteLine("3. Listening activity");
            try
            {
                userChoice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please input a valid option");
                continue;
            }

            switch (userChoice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.DipslayBreathing();
                    break;

                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.DisplayReflection();
                    break;

                case 3:
                    ListeningActivity listeningActivity = new ListeningActivity();
                    listeningActivity.DisplayListening();
                    break;

                default:
                    Console.WriteLine("Please input a valid option");
                    break;
            }
        }
    }
}