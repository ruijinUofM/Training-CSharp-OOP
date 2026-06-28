namespace Kata;

abstract record Shape;
record Circle(double Radius) : Shape;
record Rectangle(double Width, double Height) : Shape;
record Triangle(double A, double B, double C) : Shape;

static class ShapeMath
{
    public static double Area(Shape shape) { throw new NotImplementedException(); }
    public static string Classify(int n) { throw new NotImplementedException(); }
}
