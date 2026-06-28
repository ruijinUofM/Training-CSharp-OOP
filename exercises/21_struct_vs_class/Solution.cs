using Xunit;

public struct Point
{
    public int X;
    public int Y;
    public Point(int x, int y) { X = x; Y = y; }
}

public class Box
{
    public int Value { get; set; }
    public Box(int value) { Value = value; }
}

public static class Demos
{
    public static bool StructsAreCopied()
    {
        Point a = new Point(1, 2);
        Point b = a;
        b.X = 99;
        return a.X == 1; // true: struct was copied, a is unchanged
    }

    public static bool ClassesAreShared()
    {
        Box a = new Box(1);
        Box b = a; // same reference
        b.Value = 99;
        return a.Value == 99; // true: a.Value was changed through b
    }

    public static bool IsValueType(Type t) => t.IsValueType;
    public static bool IsReferenceType(Type t) => !t.IsValueType;
}
