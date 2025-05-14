/* In order to "exceed requirements" I chose to save the list of entries to a json rather than a csv or txt file. I 
also inlcuded an option for the user to select a specific prompt, or to just have no prompt at all. Additionally, I've 
included many safegaurds for bad input; the program should never crash because of bad input. */

using System;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Security.Principal;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptPicker promptPicker = new PromptPicker();

        bool keepGoing = true;
        while (keepGoing)
        {
            Console.WriteLine("\nPlease select an option:");
            Console.WriteLine("1. Write in journal");
            Console.WriteLine("2. View journal");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. quit");
            Console.Write("> ");
            int userInput;
            // Prevents program from crashing in case of bad input.
            try
            {
                userInput = int.Parse(Console.ReadLine());
            }
            catch
            {
                userInput = 0;
            }

            switch(userInput)
            {
                case 1:
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    string prompt;

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Would you like to select a prompt (1) or generate a random one (2)?");
                            Console.Write("> ");
                            int randomPrompt = int.Parse(Console.ReadLine());
                            if (randomPrompt == 1)
                            {
                                prompt = promptPicker.GetSelectedPrompt();
                                break;
                            }
                            else if (randomPrompt == 2)
                            {
                                prompt = promptPicker.GetRandomPrompt();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please input 1 or 2");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please input 1 or 2");
                        }
                    }

                    Console.WriteLine();
                    if (prompt != "None")
                    {
                        Console.WriteLine(prompt);
                    }
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    journal.AddEntry(new Entry(date, prompt, response));
                    break;
                    
                case 2:
                    journal.DisplayJournal();
                    break;
                
                case 3:
                    Console.WriteLine("What is the name of the file you'd like to save your journal to?");
                    Console.Write("> ");
                    string fileToSave = $"{Console.ReadLine()}.json";
                    journal.SaveToFile(fileToSave);
                    Console.WriteLine($"Your journal has been saved to {fileToSave}");
                    break;

                case 4:
                    try
                    {
                        Console.WriteLine("What is the name of the file you'd like to load your journal from?");
                        Console.Write("> ");
                        string fileToRead = $"{Console.ReadLine()}.json";
                        journal.ReadFile(fileToRead);
                        Console.WriteLine($"Your journal has been loaded from {fileToRead}");
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("Sorry the requested file could not be found.");
                    }
                    catch
                    {
                        Console.WriteLine("Sorry, something went wrong. The file has likely been corrupted or has no data.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Exiting program. Your journal has been saved.");
                    keepGoing = false;
                    break;

                default:
                    Console.WriteLine("Please input a valid option");
                    break;
            }
        }
    }       
}