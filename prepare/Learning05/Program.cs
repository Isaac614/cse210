using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new();
        shapes.Add(new Square(2, "white"));
        shapes.Add(new Rectangle(2, 4, "red"));
        shapes.Add(new Circle(2, "blue"));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetArea()} - {shape.GetColor()}");
        }
    }
}