namespace Kata;

abstract record Shape;
record Circle(double Radius) : Shape;
record Rectangle(double Width, double Height) : Shape;
record Triangle(double A, double B, double C) : Shape;

static class ShapeMath
{
    public static double Area(Shape shape) => shape switch
    {
        Circle(var r) => Math.PI * r * r,
        Rectangle(var w, var h) => w * h,
        Triangle(var a, var b, var c) => HeronFormula(a, b, c),
        _ => throw new ArgumentException($"Unknown shape: {shape.GetType().Name}"),
    };

    private static double HeronFormula(double a, double b, double c)
    {
        double s = (a + b + c) / 2.0;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public static string Classify(int n) => n switch
    {
        < 0 => "negative",
        0 => "zero",
        > 0 and < 10 => "small",
        _ => "large",
    };
}
