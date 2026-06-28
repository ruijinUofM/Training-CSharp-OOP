namespace Kata;

record Point(double X, double Y)
{
    public double DistanceTo(Point other) { throw new NotImplementedException(); }
}

record struct Color(byte R, byte G, byte B)
{
    public string ToHex() { throw new NotImplementedException(); }
}
