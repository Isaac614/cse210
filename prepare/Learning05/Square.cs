public class Square : Shape
{

    private double _size;


    public Square(double size, string color) : base(color)
    {
        _size = size;
    }

    public override double GetArea()
    {
        return _size * _size;
    }
}