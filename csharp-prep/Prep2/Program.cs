using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string strGradePercent = Console.ReadLine();
        int gradePercent = int.Parse(strGradePercent);

        string letter;
        if (gradePercent >= 90)
        {
            // Console.WriteLine("You have an A");
            letter = "A";
        }
        else if (gradePercent >= 80)
        {
            // Console.WriteLine("You have a B");
            letter = "B";
        }
        else if (gradePercent >= 70)
        {
            // Console.WriteLine("You have a C");
            letter = "C";
        }
        else if (gradePercent >= 60)
        {
            // Console.WriteLine("You have a D");
            letter = "D";
        }
        else 
        {
            // Console.WriteLine("You have an F");
            letter = "F";
        }

        Console.WriteLine(letter);

        if (gradePercent >= 70)
        {
            Console.WriteLine("Congrats, you passed the class");
        }
        else
        {
            Console.WriteLine("Sorry, you failed the class");
        }
    }
}