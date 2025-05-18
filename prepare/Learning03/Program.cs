using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction(3, 4);
        Console.WriteLine(fraction.GetTop());
        Console.WriteLine(fraction.GetBottom());
        fraction.SetTop(5);
        fraction.SetBottom(10);
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}