using Xunit;

public readonly struct Vector2
{
    public double X { get; init; }
    public double Y { get; init; }

    public Vector2(double x, double y)
    {
        throw new NotImplementedException();
    }

    public double Length
    {
        get { throw new NotImplementedException(); }
    }

    public Vector2 Add(Vector2 other)
    {
        throw new NotImplementedException();
    }

    public Vector2 Scale(double factor)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Vector2 other)
    {
        throw new NotImplementedException();
    }

    public static Vector2 Zero => new Vector2(0, 0);
}
