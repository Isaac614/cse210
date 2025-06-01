using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment mathAssignment = new("Isaac", "Fractions", "Section 7.1", "Problems 9 & 10");
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment = new("Isaac", "English", "Short Writing 13");
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}