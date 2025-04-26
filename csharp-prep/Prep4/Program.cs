using System;

class Program
{
    static void Main(string[] args)
    {
        int userInput = -1;
        List<int> numbers = new List<int>();
        Console.WriteLine(numbers);
        while (userInput != 0)
        {
            Console.WriteLine("Please enter a number");
            userInput = int.Parse(Console.ReadLine());
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }

        int total = 0;
        int largest = -1;
        foreach (int num in numbers)
        {
            if (num > largest)
            {
                largest = num;
            }
            total += num;
        }
        int average = total / numbers.Count();

        Console.WriteLine($"The sum is {total}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is {largest}");


    }
}