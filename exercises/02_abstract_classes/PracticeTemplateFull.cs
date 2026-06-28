namespace Kata;

abstract class Shape
{
    public abstract double Area();
    public abstract double Perimeter();
    public virtual string Describe() => throw new NotImplementedException();
}

class Circle : Shape
{
    public double Radius { get; }
    public Circle(double radius) { throw new NotImplementedException(); }
    public override double Area() { throw new NotImplementedException(); }
    public override double Perimeter() { throw new NotImplementedException(); }
}

class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }
    public Rectangle(double width, double height) { throw new NotImplementedException(); }
    public override double Area() { throw new NotImplementedException(); }
    public override double Perimeter() { throw new NotImplementedException(); }
}
