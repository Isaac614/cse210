using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("What is the magic number?");
        // int magicNumber = int.Parse(Console.ReadLine());
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 11);
        int userGuess = -1;

        while (userGuess != magicNumber)
        {
            Console.WriteLine("\nWhat is your guess?");
            userGuess = int.Parse(Console.ReadLine());
            if (magicNumber < userGuess)
            {
                Console.WriteLine("Lower");
            }
            else if (magicNumber > userGuess)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}