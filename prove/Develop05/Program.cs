public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the goal program");
        bool keepRunning = true;
        User user = new User();

        while (keepRunning)
        {
            Console.WriteLine("1. View goals");
            Console.WriteLine("2. View points");
            Console.WriteLine("3. Create new Goal");
            Console.WriteLine("4. Mark a goal as complete");
            Console.WriteLine("5. Save data to file");
            Console.WriteLine("6. Load data from file");
            Console.WriteLine("7. quit");

            string action = Console.ReadLine();
            Console.WriteLine();

            switch (action)
            {
                case "1":
                    user.DisplayGoals();
                    break;

                case "2":
                    user.DipslayPoints();
                    break;

                case "3":
                    Console.WriteLine("What type of goal would you like to create? " +
                    "\n1. Simple goal\n2. Eternal goal\n3. Checklist goal\n4. Recurring goal");
                    int goalType;

                    while (true)
                    {
                        try
                        {
                            goalType = int.Parse(Console.ReadLine()) - 1;
                            if (goalType >= 0 && goalType <= 3)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please select a valid goal type");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please select a valid goal type");
                        }
                    }

                    Console.WriteLine("What would you like the description of the goal to be?");
                    string goalDesc = Console.ReadLine();

                    Console.WriteLine("How many points would you like this goal to be worth?");
                    int goalPoints;

                    while (true)
                    {
                        try
                        {
                            goalPoints = int.Parse(Console.ReadLine());
                            if (goalPoints >= 0)
                            {
                                break;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please input a valid number");
                        }
                    }


                    if (goalType == 2)
                    {
                        int completeCondition;
                        while (true)
                        {
                            Console.WriteLine("How many times does this goal need to be completed before it's fully complete?");
                            try
                            {
                                completeCondition = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Please input a valid number");
                            }
                        }
                        user.AddGoal(goalDesc, goalPoints, completeCondition);
                    }
                    else if (goalType == 3)
                    {
                        int refreshFrequency;
                        while (true)
                        {
                            Console.WriteLine("How often do you want this goal to reset (days)?");
                            try
                            {
                                refreshFrequency = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Please input a valid number");
                            }
                        }

                        user.AddGoal(refreshFrequency, goalDesc, goalPoints);
                    }
                    else
                    {
                        user.AddGoal(goalDesc, goalPoints, goalType.ToString());
                    }
                    break;

                case "4":
                    bool continuePrompting = true;

                    while (continuePrompting)
                    {
                        Console.WriteLine("Which goal would you like to mark as complete? Please type the number " +
                        "that appears next to it when displayed. If you would like to view your goals simply hit enter.");
                        string completeInput = Console.ReadLine();

                        if (completeInput == "")
                        {
                            user.DisplayGoals();
                        }
                        else
                        {
                            try
                            {
                                int goalToComplete = int.Parse(completeInput) - 1;
                                user.MarkAsCompleted(goalToComplete);
                                continuePrompting = false;
                            }
                            catch
                            {
                                Console.WriteLine("Please input a valid option");
                            }
                        }
                    }
                    break;

                case "5":
                    Console.WriteLine("What is the name or path of the file you'd like to save to?");
                    string fileToSave = Console.ReadLine();
                    try
                    {
                        user.SaveToFile(fileToSave);
                    }
                    catch
                    {
                        Console.WriteLine("Sorry, something went wrong. Please try again.");
                    }
                    break;

                case "6":
                    Console.WriteLine("What is the name or path of the file you'd like to load from?");
                    string fileToLoad = Console.ReadLine();
                    // try
                    // {
                    user.LoadFromFile(fileToLoad);
                    // }
                    // catch
                    // {
                    //     Console.WriteLine("Sorry, something went wrong. Please try again.");
                    // }
                    break;

                case "7":
                    Console.WriteLine("Exiting program");
                    keepRunning = false;
                    break;

                default:
                    Console.WriteLine("Please select a valid option");
                    break;
            }
        }
    }
}