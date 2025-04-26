using System;

class Program
{
    static void Main(string[] args)
    {

        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNum = SquareNumber(userNumber);
        DisplayResult(userName, squaredNum);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("What is your name?");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("What is your favorite number?");
        int userFavoriteNumber = int.Parse(Console.ReadLine());
        return userFavoriteNumber;
    }

    static int SquareNumber(int num)
    {
        return num * num;
    }

    static void DisplayResult(string name, int squaredNum)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNum}");
    }
}